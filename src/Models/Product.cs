using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<WarehouseProduct> Warehouses;

        public ProductExtraInformation ExtraInformation { get; set; }
    }
}
