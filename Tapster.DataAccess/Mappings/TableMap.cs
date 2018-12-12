using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Mappings
{
    public class TableMap : IEntityTypeMapping<Table>
    {
        public void Map(EntityTypeBuilder<Table> entity)
        {
            entity.HasOne(e => e.Venue)
                .WithMany(e => e.Tables)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
