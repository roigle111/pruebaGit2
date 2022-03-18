using Microsoft.EntityFrameworkCore;
using PersistenceDatabase;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(@"data source=localhost\SQLEXPRESS;initial catalog=EFPrueba2;User ID=SisDialysisPub;Password=S1sD1alys1s@@733.;MultipleActiveResultSets=True;Application Name=EntityFramework");

            var context = new ApplicationDbContext(optionBuilder.Options);
            TestConnection(context);
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
