using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ClientService
    {
        private readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Get(int id)
        {
            //return _context.Clients.Single(x => x.ClientId == id);
            //return _context.Clients.First(x => x.ClientId == id);
            return _context.Clients.SingleOrDefault(x => x.ClientId == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                .Include(x => x.Country)
                .OrderByDescending(x => x.ClientId)
                .ToList();
        }

    }
}
