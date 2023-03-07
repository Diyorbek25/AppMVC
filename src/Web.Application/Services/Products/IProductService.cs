using AppMVC.Domain.Entities;

namespace AppMVC.Application.Services;

public interface IProductService
{
    ValueTask<Product> CreateProductAsync(Product product);
    IQueryable<Product> RetrieveProducts();
    ValueTask<Product> RetrieveProductByIdAsync(int id);

    ValueTask<Product> ModifyProductAsync(Product product);

    ValueTask<Product> RemoveProductAsync(int id);
}
