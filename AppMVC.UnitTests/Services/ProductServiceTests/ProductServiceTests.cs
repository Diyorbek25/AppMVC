using AppMVC.Application.Services;
using AppMVC.Application.Services.Products;
using AppMVC.Domain.Services;
using AppMVC.Infrastructure.Repositories.Products;
using AppMVC.Infrastructure.Repositories.Users;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AppMVC.UnitTests.Services.ProductServiceTests;

public partial class ProductServiceTests
{
    private readonly Mock<IProductRepository> productRepositoryMock;
    private readonly IProductService productService;

    public ProductServiceTests()
    {
        this.productRepositoryMock = new Mock<IProductRepository>();
        var inMemorySettings = new Dictionary<string, string> 
        { 
            {"VAT:Value", "0.2"} 
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        this.productService = new ProductService(
            productRepository: productRepositoryMock.Object,
            configuration: configuration);
    }
}
