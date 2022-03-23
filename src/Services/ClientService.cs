using Microsoft.EntityFrameworkCore;
using Models;
using PersistenceDatabase;
using Services.QueryHelpers;
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


        public void Update(List<Client> clients)
        {
            var ids = clients.Select(x => x.ClientId);
            var originalClients = _context.Clients.Where(x => ids.Contains(x.ClientId))
                                                  .ToList();

            foreach (var client in originalClients)
            {
                var updateClient = clients.Single(x => x.ClientId == client.ClientId);
                client.Name = updateClient.Name;
            }
            
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            var originalClient = _context.Clients.Single(x => x.ClientId == client.ClientId);
            originalClient.Name = client.Name;

            //_context.Clients.Update(client); --> no hace falya ya que EFCore se da cuenta que tiene que actualizar
            _context.SaveChanges();
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Create(List<Client> clients)
        {
            _context.Clients.AddRange(clients);
            _context.SaveChanges();
        }

        public Client Get(int id)
        {
            //return _context.Clients.Single(x => x.ClientId == id);
            //return _context.Clients.First(x => x.ClientId == id);
            return _context.Clients.GetBaseQuery().SingleOrDefault(x => x.ClientId == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                .GetBaseQuery()
                .OrderByDescending(x => x.ClientId)
                .ToList();
        }

    }
}
