using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Mappings
{
    public class VenueMap : IEntityTypeMapping<Venue>
    {
        public void Map(EntityTypeBuilder<Venue> entity)
        {
            entity.HasOne(e => e.Manager)
                .WithMany(e => e.Venues)
                .HasForeignKey(e => e.MangerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
