using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class WarehouseService
    {
        private readonly ApplicationDbContext _context;
        public WarehouseService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _context.Warehouses
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ToList();
        }
    }
}
