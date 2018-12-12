using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Mappings
{
    public class ClientSessionMap : IEntityTypeMapping<ClientSession>
    {
        public void Map(EntityTypeBuilder<ClientSession> entity)
        {
            entity.HasOne(e => e.Client)
                .WithMany(e => e.ClientSessions)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Session)
                .WithMany(e => e.ClientSessions)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
