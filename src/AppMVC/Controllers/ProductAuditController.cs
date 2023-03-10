using AppMVC.Application.Services;
using AppMVC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[ApiController]
[Route("api/productAudits")]
[Authorize]
public class ProductAuditController : ControllerBase
{
    private readonly IProductAuditService productAuditService;

    public ProductAuditController(IProductAuditService productAuditService)
    {
        this.productAuditService = productAuditService;
    }

    [HttpGet]
    public List<ProductAudit> GetHistory(DateTime from, DateTime to)
    {
        var productAudits = productAuditService
            .RetrieveProductAudits()
            .Where(productAudit => productAudit.ChangedDate.Date >= from &&
            productAudit.ChangedDate.Date <= to);

        return productAudits.ToList();
    }
}
