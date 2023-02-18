using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Contexts;
using AppMVC.Infrastructure.Repositories.ProductAudits;

namespace AppMVC.Infrastructure.Repositories.ProductAuditRepository;

public class ProductAuditRepository : GenericRepository<ProductAudit>,
    IProductAuditRepository
{
	public ProductAuditRepository(AppDbContext dbContext)
		: base(dbContext)
	{
	}
}
