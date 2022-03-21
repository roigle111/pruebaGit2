using BetterConsoleTables;
using Common;
using Microsoft.EntityFrameworkCore;
using PersistenceDatabase;
using Services;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(Parameter.ConectionString);

            var context = new ApplicationDbContext(optionBuilder.Options);
            //TestConnection(context);

            var clientService = new ClientService(context);
            var productService = new ProductService(context);


            using (context)
            {
                PrintProductsTable(productService);
                //PrintClientTable(clientService, 1);
                //PrintClientsTable(clientService);
            }

            Console.WriteLine("Fin.");
            Console.Read();
        }

        static void PrintProductsTable(ProductService productService)
        {
            var products = productService.GetAll();

            var table = new Table("ProductId", "Name", "Price");

            foreach (var product in products)
            {
                table.AddRow(product.ProductId, product.Name, product.Price);
            }

            Console.Write(table.ToString());

        }


        static void PrintClientTable(ClientService clientService, int id)
        {
            var client = clientService.Get(id);

            if(client != null)
            {
                // BetterConsoleTables (1.1.2)
                var table = new Table("ClientId", "ClientNumber", "Name", "Country");
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");

                //foreach (var client in clients)
                //{
                //    table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
                //}

                Console.Write(table.ToString());
            }
        }
        static void PrintClientsTable(ClientService clientService)
        {
            var clients = clientService.GetAll();

            // BetterConsoleTables (1.1.2)
            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            foreach (var client in clients)
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
            }

            Console.Write(table.ToString());

        }

        static void TestConnection(ApplicationDbContext context)
        {
            var isConnect = false;
            try
            {
                isConnect = context.Database.EnsureCreated();
            }
            catch (System.Exception)
            {
                //throw;
            }

            if (isConnect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SE ESTABLECIO LA CONEXION EXITOSA");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO SE PUDO ESTABLECER LA CONEXION");
            }
        }
    }
}
