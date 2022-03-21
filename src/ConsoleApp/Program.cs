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


            using (context)
            {
                PrintClientTable(clientService);
            }

            Console.Read();
        }

        static void PrintClientTable(ClientService clientService)
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
