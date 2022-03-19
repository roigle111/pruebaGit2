using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Price).IsRequired();

            entityBuilder.HasData(
            new Product
            {
                ProductId = 1,
                Name = "Disco SDD 480 GB",
                Price = 4800,
            },
            new Product
            {
                ProductId = 2,
                Name = "Memoria RAM 4GB DDR 4",
                Price = 2500,
            }
            );

        }
    }
}
