using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utils.EntityFrameworkCore.Extensions;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Mappings
{
    public class OrderProductMap : IEntityTypeMapping<OrderProduct>
    {
        public void Map(EntityTypeBuilder<OrderProduct> entity)
        {
            entity.HasOne(e => e.Product)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Order)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}