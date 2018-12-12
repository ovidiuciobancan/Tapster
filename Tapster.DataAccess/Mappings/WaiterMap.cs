using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class WaiterMap : IEntityTypeMapping<Waiter>
    {
        public void Map(EntityTypeBuilder<Waiter> entity)
        {
            entity.HasOne(e => e.Venue)
                .WithMany(e => e.Waiters)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}