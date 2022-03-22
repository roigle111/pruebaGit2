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
            },
            new Product
            {
                ProductId = 3,
                Name = "Disco SDD 240 GB",
                Price = 2100,
            },
            new Product
            {
                ProductId = 4,
                Name = "Memoria RAM 8GB DDR 4",
                Price = 4700,
            },
            new Product
            {
                ProductId = 5,
                Name = "Disco HDD 1 TB",
                Price = 6800,
            },
            new Product
            {
                ProductId = 6,
                Name = "Memoria RAM 4GB DDR 3",
                Price = 2200,
            },
            new Product
            {
                ProductId = 7,
                Name = "Pendrive Kingston 4GB",
                Price = 1200,
            },
            new Product
            {
                ProductId = 8,
                Name = "Pendrive Kingston 8GB",
                Price = 3500,
            },
            new Product
            {
                ProductId = 9,
                Name = "Pendrive Kingston 16GB",
                Price = 5100,
            },
            new Product
            {
                ProductId = 10,
                Name = "Monitor 22´´ samsung",
                Price = 25000,
            },
            new Product
            {
                ProductId = 11,
                Name = "Mouse Genius USB",
                Price = 1400,
            },
            new Product
            {
                ProductId = 12,
                Name = "Mouse Logitech USB",
                Price = 2200,
            },
            new Product
            {
                ProductId = 13,
                Name = "Cable USB",
                Price = 900,
            },
            new Product
            {
                ProductId = 14,
                Name = "Cable HDMI 2 Mts.",
                Price = 1700,
            },
            new Product
            {
                ProductId = 15,
                Name = "Cable RED UTP5 5 Mts.",
                Price = 3600,
            },
            new Product
            {
                ProductId = 16,
                Name = "Parlantes Genius PC",
                Price = 4000,
            });

        }
    }
}
