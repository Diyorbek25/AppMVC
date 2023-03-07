using AppMVC.Domain.Entities;
using Moq;

namespace AppMVC.UnitTests.Services.ProductServiceTests;

public partial class ProductServiceTests
{
    [Fact]
    public async Task Should_EditeProductAsync()
    {
        Product storageProduct = new Product()
        {
            Id = 123,
            Title = "Test",
            Quantity = 12,
            Price = 14.05,
            TotalPrice = (12 * 14.05) * (1 + 0.2)
        };

        Product product = new Product()
        {
            Id = 123,
            Title = "Test",
            Quantity = 5,
            Price = 20.1
        };

        double productTotalPrice = (product.Price * product.Quantity) * (1 +  0.2);

        productRepositoryMock
            .Setup(mock => mock.SelectByIdAsync(product.Id))
            .ReturnsAsync(storageProduct);

        productRepositoryMock
            .Setup(mock => mock.UpdateAsync(storageProduct))
            .ReturnsAsync(storageProduct);

        storageProduct = await productService
            .ModifyProductAsync(product);

        Assert.Equal(productTotalPrice, storageProduct.TotalPrice);
    }
}
