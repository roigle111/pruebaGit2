using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class WarehouseConfig
    {
        public WarehouseConfig(EntityTypeBuilder<Warehouse> entityOptionsBuilder)
        {
            entityOptionsBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            entityOptionsBuilder.HasData(
            new Warehouse
            {
                WarehouseId = 1,
                Name = "Sector AA",
            },
            new Warehouse
            {
                WarehouseId = 2,
                Name = "Sector BB",
            });
        }

    }
}
