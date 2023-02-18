
using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Repositories.Products;
using Microsoft.Extensions.Configuration;

namespace AppMVC.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IConfiguration configuration;

    public ProductService(IProductRepository productRepository,
        IConfiguration configuration)
    {
        this.productRepository = productRepository;
        this.configuration = configuration;
    }

    public async ValueTask<Product> CreateProductAsync(Product product)
    {
        var vat = double.Parse(configuration.GetSection("VAT:Value").Value);
        product.TotalPrice = (product.Price * product.Quantity) * (1 + vat);

        var createdProduct = await productRepository.InsertAsync(product);

        return createdProduct;
    }

    public async ValueTask<Product> ModifyProductAsync(
        Product product)
    {
        var storageProduct = await productRepository.SelectByIdAsync(product.Id);

        return await productRepository.UpdateAsync(product);
    }

    public async ValueTask<Product> RemoveProductAsync(int id)
    {
        var product = await productRepository.SelectByIdAsync(id);

        return await productRepository.RemoveAsync(product);
    }

    public IQueryable<Product> RetrieveProduct()
    {
        return productRepository.SelectAll();
    }

    public async ValueTask<Product> RetrieveProductByIdAsync(int id)
    {
        return await productRepository.SelectByIdAsync(id);
    }
}
