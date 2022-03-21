using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class ProductExtraInformationConfig
    {
        public ProductExtraInformationConfig(EntityTypeBuilder<ProductExtraInformation> entityBuilder)
        {
            entityBuilder.Property(x => x.SKU).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
