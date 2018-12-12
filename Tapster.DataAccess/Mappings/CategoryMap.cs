using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class CategoryMap : IEntityTypeMapping<Category>
    {
        public void Map(EntityTypeBuilder<Category> entity)
        {
            entity.HasOne(e => e.Venue)
                .WithMany(e => e.Categories)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ParentCategory)
                .WithMany(e => e.SubCategories)
                .HasForeignKey(e => e.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}