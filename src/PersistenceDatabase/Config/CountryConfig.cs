using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class CountryConfig
    {
        public CountryConfig(EntityTypeBuilder<Country> entityOptionsBuilder)
        {
            entityOptionsBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityOptionsBuilder.HasData(
                new Country { 
                    CountryId = 1,
                    Name = "Argentina"
                },
                new Country { 
                    CountryId = 2,
                    Name = "Perú"
                });
        }

    }
}
