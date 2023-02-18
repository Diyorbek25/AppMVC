using AppMVC.Application.Services;
using AppMVC.Application.Services.Products;
using AppMVC.Infrastructure.Repositories.Products;
using Moq;

namespace AppMVC.UnitTests.Services.ProductServiceTests;

public partial class ProductServiceTests
{
    private readonly Mock<IProductRepository> productRepositoryMock;
    
    private readonly IProductService productServiceMock;

    public ProductServiceTests(
        Mock<IProductRepository> productRepositoryMock, 
        IProductService productServiceMock)
    {
        this.productRepositoryMock = productRepositoryMock;
        this.productServiceMock = productServiceMock;
    }
}
