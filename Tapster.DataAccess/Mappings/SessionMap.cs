using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Mappings
{
    public class SessionMap : IEntityTypeMapping<Session>
    {
        public void Map(EntityTypeBuilder<Session> entity)
        {
            entity.HasOne(e => e.Table)
                .WithMany(e => e.Sessions)
                .HasForeignKey(e => e.TableId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
