using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppMVC.Domain.Entities;

namespace AppMVC.Infrastructure.EntityTypeConfigurations;

public class ProductAuditConfiguration : IEntityTypeConfiguration<ProductAudit>
{
    public void Configure(EntityTypeBuilder<ProductAudit> builder)
    {
        builder.HasKey(productAudit => productAudit.Id);

        builder.Property(productAudit => productAudit.Title)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(productAudit => productAudit.Quantity)
            .IsRequired(false);

        builder.Property(productAudit => productAudit.Price)
            .IsRequired(false);

        builder.Property(productAudit => productAudit.ChangedDate) 
            .IsRequired(true);

        builder.HasOne<User>(productAudit => productAudit.User)
            .WithMany(user => user.ProductAudits)
            .HasForeignKey(productAudit => productAudit.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Product>(productAudit => productAudit.Product)
            .WithMany(product => product.ProductAudits)
            .HasForeignKey(productAudit => productAudit.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
