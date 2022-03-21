using System.Collections.Generic;

namespace Models
{
    public class Client
    {
        public int ClientId { get; set; }
        List<Order> Orders { get; set; }

        public int? Country_Id { get; set; }
        public Country Country { get; set; }

        public string ClientNumber { get; set; }
        public string Name { get; set; }
    }
}
