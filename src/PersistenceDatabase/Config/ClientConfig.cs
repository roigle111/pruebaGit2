using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasData(
                new Client
                {
                    ClientId = 1,
                    ClientNumber = "1000001",
                    Name = "Fravega",
                },
                new Client
                {
                    ClientId = 2,
                    ClientNumber = "1000002",
                    Name = "Garvarino",
                }
                );
        }
    }
}
