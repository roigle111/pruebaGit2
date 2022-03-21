using Common;
using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase.Config;

namespace PersistenceDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetail{ get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<OrderNumber> OrderNumbers{ get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarewhouseProduct> WarewhouseProducts { get; set; }
        public DbSet<ProductExtraInformation> ProductExtraInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(Parameter.ConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ClientConfig(builder.Entity<Client>());
            new OrderConfig(builder.Entity<Order>());
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new ProductConfig(builder.Entity<Product>());
            new SaleConfig(builder.Entity<Sale>());
            new OrderNumberConfig(builder.Entity<OrderNumber>());
            new CountryConfig(builder.Entity<Country>());
            new WarehouseConfig(builder.Entity<Warehouse>());
            new ProductExtraInformationConfig(builder.Entity<ProductExtraInformation>());
        }
    }    

}
