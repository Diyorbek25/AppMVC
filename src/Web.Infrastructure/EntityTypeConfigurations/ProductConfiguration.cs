using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppMVC.Domain.Entities;

namespace AppMVC.Infrastructure.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(product => product.Quantity)
            .IsRequired();

        builder.Property(product => product.Quantity)
            .IsRequired();

        builder.Property(product => product.TotalPrice)
            .IsRequired(false);

        builder.HasData(GenenrateProducts());
    }

    public List<Product> GenenrateProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Title = "HDD 1TB",
                Quantity = 55,
                Price = 74.09
            },
            new Product()
            {
                Id = 2,
                Title = "HDD SSD 512GB",
                Quantity = 102,
                Price = 190.99
            },
            new Product()
            {
                Id = 3,
                Title = "RAM DDR4 16GB",
                Quantity = 47,
                Price = 80.32
            }
        };
    }
}
