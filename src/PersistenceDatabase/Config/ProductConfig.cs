using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.ClientNumber).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
