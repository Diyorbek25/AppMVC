using AppMVC.Domain.Entities;
using Moq;

namespace AppMVC.UnitTests.Services.ProductServiceTests;

public partial class ProductServiceTests
{
    [Fact]
    public async Task Should_CreateProductAsync()
    {
        Product product = new Product()
        {
            Id = 123,
            Title = "Test",
            Quantity = 12,
            Price = 14.05
        };
        double TotalPrice = (product.Price * product.Quantity) * (1 + 0.2);

        productRepositoryMock
            .Setup(mock => mock.InsertAsync(product))
            .ReturnsAsync(product);

        var storageProduct = await productService
            .CreateProductAsync(product);

        Assert.Equal(TotalPrice, storageProduct.TotalPrice);
    }
}
