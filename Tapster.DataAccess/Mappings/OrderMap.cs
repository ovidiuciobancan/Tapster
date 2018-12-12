using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class OrderMap : IEntityTypeMapping<Order>
    {
        public void Map(EntityTypeBuilder<Order> entity)
        {
            entity.HasOne(e => e.ClientSession)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ClientSessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
