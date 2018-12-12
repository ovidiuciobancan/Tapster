using System;
using System.Collections;
using System.Collections.Generic;
using Tapster.DomainEntities.Enums;

namespace Tapster.DomainEntities.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public TableSessionStatusTypes Status { get; set; }

        public Table Table { get; set; }

        public ICollection<ClientSession> ClientSessions { get; set; }

    }
}
