using AppMVC.Domain.Entities;

namespace AppMVC.Controllers.Factories;

public class ProductAuditFactory
{
    public static ProductAudit MapToProductAudit(
        Product newProduct, 
        Product oldProduct,
        int userId)
    {
        return new ProductAudit()
        {
            Title = newProduct.Title != oldProduct.Title ? newProduct.Title : null,
            Quantity = newProduct.Quantity != oldProduct.Quantity ? newProduct.Quantity : null,
            Price = newProduct.Price != oldProduct.Price ? newProduct.Price : null,
            ChangedDate = DateTime.Now,
            UserId = userId,
            ProductId = oldProduct.Id
        };
    }
}
