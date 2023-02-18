using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Contexts;

namespace AppMVC.Infrastructure.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
	public ProductRepository(AppDbContext dbContext)
		: base(dbContext)
	{
	}
}
