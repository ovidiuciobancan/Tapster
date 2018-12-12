using System;
using System.Collections.Generic;

namespace Tapster.DomainEntities.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ClientSession> ClientSessions { get; set; } = new List<ClientSession>();
    }
}
