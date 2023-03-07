
using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Repositories.ProductAudits;

namespace AppMVC.Application.Services.ProductAudits;

public class ProductAuditService : IProductAuditService
{

    private readonly IProductAuditRepository productAuditRepository;

    public ProductAuditService(IProductAuditRepository productAuditRepository)
    {
        this.productAuditRepository = productAuditRepository;
    }

    public async ValueTask<ProductAudit> CreateProductAuditAsync(
        ProductAudit productAudit)
    {
        return await productAuditRepository.InsertAsync(productAudit);
    }

    public async ValueTask<ProductAudit> RemoveProductAuditAsync(int id)
    {
        var productAudit = await productAuditRepository.SelectByIdAsync(id);

        return await productAuditRepository.RemoveAsync(productAudit);
    }

    public IQueryable<ProductAudit> RetrieveProductAudits()
    {
        return productAuditRepository.SelectAll();
    }

    public IQueryable<ProductAudit> RetrieveProductAuditsSortByDate(DateTime date)
    {
        var productAudits = productAuditRepository.SelectAll();

        var sortedProductAudits = productAudits.Where( 
                                item => item.ChangedDate.Year == date.Year &&
                                item.ChangedDate.Month == date.Month &&
                                item.ChangedDate.Day == date.Day);

        return sortedProductAudits;
    }
}
