using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(bool tipo = true)
        {
            //var ids = new List<int> { 2, 5};
            return await _context.Products
                //.Where(x => ids.Contains(x.ProductId))
                //.Where(x => x.Name.Contains("Memoria"))
                //.Where(x => x.Name.StartsWith("P"))
                //.Where(x => x.Name.EndsWith("B"))
                .Where(x => !tipo || x.Name.StartsWith("Mem"))
                .ToListAsync();
        }


        public IEnumerable<Product> GetAll(bool tipo = true)
        {
            //var ids = new List<int> { 2, 5};
            return _context.Products
                //.Where(x => ids.Contains(x.ProductId))
                //.Where(x => x.Name.Contains("Memoria"))
                //.Where(x => x.Name.StartsWith("P"))
                //.Where(x => x.Name.EndsWith("B"))
                .Where(x => !tipo || x.Name.StartsWith("Mem"))
                .ToList();
        }


    }
}
