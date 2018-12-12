using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class ProductMap : IEntityTypeMapping<Product>
    {
        public void Map(EntityTypeBuilder<Product> entity)
        {
            entity.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}