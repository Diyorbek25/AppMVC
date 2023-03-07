using AppMVC.Domain.Entities;
using AppMVC.Models;

namespace AppMVC.Controllers;

public class ProductFactory
{
    public static Product MapToProduct(ProductViewModel model)
    {
        return new Product()
        {
            Title = model.Title,
            Quantity = model.Quantity,
            Price = model.Price
        };
    }
}
