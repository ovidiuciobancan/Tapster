using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class WaiterTableMap : IEntityTypeMapping<WaiterTable>
    {
        public void Map(EntityTypeBuilder<WaiterTable> entity)
        {
            entity.HasOne(e => e.Waiter)
                .WithMany(e => e.WaiterTables)
                .HasForeignKey(e => e.WaiterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Table)
                .WithMany(e => e.WaiterTables)
                .HasForeignKey(e => e.TableId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}