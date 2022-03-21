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

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

    }
}
