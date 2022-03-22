using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using Services.ComplexModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class WarehouseService
    {
        private readonly ApplicationDbContext _context;
        public WarehouseService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _context.Warehouses
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ToList();
        }
        public IEnumerable<WerhouseProductReport> GetAllWithProducts()
        {
            var werhouses = this.GetAll();
            var werhouseProductss1 = _context.Warehouses.Select(x => x.Products).ToList();
            var werhouseProductss2 = _context.Warehouses.SelectMany(x => x.Products).ToList();

            return null;
        }
    }
}
