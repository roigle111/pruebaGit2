using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class SaleConfig
    {
        public SaleConfig(EntityTypeBuilder<Sale> entityOptionsBuilder)
        {
            entityOptionsBuilder.HasKey(x => new { 
                x.Year,
                x.Month
            });
        }

    }
}
