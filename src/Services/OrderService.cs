using Models;
using PersistenceDatabase;
using System;
using System.Linq;

namespace Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        private const decimal Iva = 0.21m;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            // 01. Obtener el correlativo de la orden 2022-000001
            PrepareOrderNumber(order);

            // 02. Completar los campos pendientes
            PrepareDetail(order);
            PrepareOrderAmounts(order);

            order.RegisteredAt = DateTime.Now;

            // 03. Crear la orden
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        private void PrepareOrderAmounts(Order order)
        {
            order.SubTotal = order.Items.Sum(x => x.SubTotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }

        private void PrepareDetail(Order order)
        {
            foreach (var detail in order.Items)
            {
                detail.Total = detail.Quantity * detail.UnitPrice;
                detail.Iva = detail.Total * Iva;
                detail.SubTotal = detail.Total - order.Iva;
            }
        }

        private void PrepareOrderNumber(Order order)
        {
            var orderNumber = _context.OrderNumbers.Single(x => x.Year == DateTime.Now.Year);
            orderNumber.Value++;
            order.OrderId = order.RegisteredAt.Year.ToString() + "-" + orderNumber.Value.ToString().PadLeft(5, '0');
        }

    }
}
