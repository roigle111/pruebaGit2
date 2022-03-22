using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace PersistenceDatabase.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.HasOne(x => x.Country)
                         .WithMany(x => x.Clients)
                         .HasForeignKey(x => x.Country_Id);

            entityBuilder.HasData(
                new Client
                {
                    ClientId = 1,
                    ClientNumber = "1000001",
                    Name = "Fravega",
                    Country_Id = 1,
                },
                new Client
                {
                    ClientId = 2,
                    ClientNumber = "1000002",
                    Name = "Garvarino",
                    Country_Id = 2,
                });
        }
    }
}
