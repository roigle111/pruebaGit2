using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class WarehouseProductConfig
    {
        public WarehouseProductConfig(EntityTypeBuilder<WarehouseProduct> entityOptionsBuilder)
        {
            entityOptionsBuilder.HasData(
            new WarehouseProduct
            {
                WarehouseProductId = 1,
                WarehouseId = 1,
                ProductId = 1
            },
            new WarehouseProduct
            {
                WarehouseProductId = 2,
                WarehouseId = 1,
                ProductId = 2
            },
            new WarehouseProduct
            {
                WarehouseProductId = 3,
                WarehouseId = 1,
                ProductId = 3
            },
            new WarehouseProduct
            {
                WarehouseProductId = 4,
                WarehouseId = 2,
                ProductId = 4
            },
            new WarehouseProduct
            {
                WarehouseProductId = 5,
                WarehouseId = 2,
                ProductId = 5
            });
        }

    }
}
