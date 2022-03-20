using System.Collections.Generic;

namespace Models
{
    public class Client
    {
        public int ClientId { get; set; }
        List<Order> Orders { get; set; }
        
        public string ClientNumber { get; set; }
        public string Name { get; set; }
    }
}
