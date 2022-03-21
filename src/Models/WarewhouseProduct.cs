namespace Models
{
    public class WarewhouseProduct
    {
        public int WarewhouseProductId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WarehousrId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
