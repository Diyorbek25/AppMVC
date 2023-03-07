using AppMVC.Domain.Entities;

namespace AppMVC.Application.Services;

public interface IProductAuditService
{
    ValueTask<ProductAudit> CreateProductAuditAsync(ProductAudit productAudit);
    IQueryable<ProductAudit> RetrieveProductAudits();
    IQueryable<ProductAudit> RetrieveProductAuditsSortByDate(DateTime date);
    ValueTask<ProductAudit> RemoveProductAuditAsync(int id);
}
