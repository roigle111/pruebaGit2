using BetterConsoleTables;
using Common;
using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using Services;
using System;
using System.Collections.Generic;

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
            var warehouseService = new WarehouseService(context);
            var OrderService = new OrderService(context);

            var newOrder = new Order
            {
                ClientId = 1,
                Items = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        ProductId = 1,
                        UnitPrice = 700,
                        Quantity = 2,

                    },
                    new OrderDetail
                    {
                        ProductId = 2,
                        UnitPrice = 1400,
                        Quantity = 1,

                    }
                }
            };

            using (context)
            {
                OrderService.Create(newOrder);
                //warehouseService.Delete(new List<int> {3, 4, 5, 6});
                //UpdateClients(clientService);
                //UpdateClient(clientService);
                //CreateClients(clientService);
                //CreateClient(clientService);
                //PrintWaewhouseAndProductsOrder(warehouseService);
                //PrintProductsTable(productService);
                //PrintClientTable(clientService, 1);
                //PrintClientsTable(clientService);
                //TestConnection(context);
            }

            Console.WriteLine("Fin.");
            Console.Read();
        }

        static void UpdateClients(ClientService clientService)
        {
            var originalClients = new List<Client>();

            originalClients.Add(new Client
            {
                ClientId = 1,
                Name = "Client111-UPDATE"
            });

            originalClients.Add(new Client
            {
                ClientId = 2,
                Name = "Client222-UPDATE"
            });

            clientService.Update(originalClients);
        }
        static void UpdateClient(ClientService clientService)
        {
            var originCLient = new Client
            {
                ClientId = 1,
                Name = "Client1-MOD"
            };

            clientService.Update(originCLient);
        }

        static void CreateClient(ClientService clientService)
        {
            var newClient = new Client
            {
                ClientNumber = "001",
                Country_Id = 1,
                Name = "Grido"
            };

            clientService.Create(newClient);
        }

        static void CreateClients(ClientService clientService)
        {
            var newClients = new List<Client>();

            newClients.Add(new Client
            {
                ClientNumber = "002",
                Country_Id = 2,
                Name = "Kokyno"
            });
            
            newClients.Add(new Client
            {
                ClientNumber = "003",
                Country_Id = 2,
                Name = "Tello"
            });

            clientService.Create(newClients);
        }

        static void PrintWaewhouseAndProductsOrder(WarehouseService warehouseService)
        {
            var products = warehouseService.GetAllWithProducts();

            var table = new Table("Almacen", "Producto", "Precio");

            foreach (var product in products)
            {
                table.AddRow(product.WerhouseName, product.ProductName, product.ProducrPrice );
            }

            Console.Write(table.ToString());
        }

        static void PrintWaewhouseAndProducts(WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAll();

            var table = new Table("Warehouse", "Product");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.Name, "-");
                foreach (var warehouseProduct in warehouse.Products)
                {
                    table.AddRow("Producto", warehouseProduct.Product.Name);
                }
            }

            Console.Write(table.ToString());

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
