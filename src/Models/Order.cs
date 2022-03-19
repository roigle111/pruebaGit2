using System;

namespace Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public string OrderId { get; set; }
        
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

    }
}
