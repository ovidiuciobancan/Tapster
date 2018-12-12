using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Mappings
{
    public class ManagerMap : IEntityTypeMapping<Manager>
    {
        public void Map(EntityTypeBuilder<Manager> entity)
        {
             
        }
    }
}
