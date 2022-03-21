using Models;
using PersistenceDatabase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            //var ids = new List<int> { 2, 5};
            return _context.Products
                //.Where(x => ids.Contains(x.ProductId))
                .Where(x => x.Name.Contains("Memoria"))
                .ToList();
        }
    }
}
