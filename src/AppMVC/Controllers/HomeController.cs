using AppMVC.Application.Services;
using AppMVC.Controllers.Factories;
using AppMVC.Domain.Entities;
using AppMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppMVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService productService;
    private readonly IProductAuditService productAuditService;

    public HomeController(
        ILogger<HomeController> logger,
        IProductService productService,
        IProductAuditService productAuditService)
    {
        _logger = logger;
        this.productService = productService;
        this.productAuditService = productAuditService;
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var product = ProductFactory.MapToProduct(model);
        await productService.CreateProductAsync(product);

        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        var models = productService.RetrieveProducts();

        return View(models);
    }

    [HttpGet]
    public async Task<IActionResult> EditProduct(int productId)
    {
        var product = await productService
            .RetrieveProductByIdAsync(productId);

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductViewModel model, int id)
    {
        if (ModelState.IsValid is false)
        {
            return View();
        }

        Product newProduct = ProductFactory.MapToProduct(model);
        newProduct.Id = id;

        var oldProduct = await productService
            .RetrieveProductByIdAsync(id);

        int userId = int.Parse(User.Claims.ToArray()[2].Value);

        ProductAudit productAudit = ProductAuditFactory
            .MapToProductAudit(
            newProduct: newProduct,
            oldProduct: oldProduct,
            userId: userId);

        var modifiedProduct = await productService
            .ModifyProductAsync(newProduct);

        await productAuditService
            .CreateProductAuditAsync(productAudit);

        return View(modifiedProduct);
    }


    public async Task<IActionResult> Delete(int id)
    {
        await productService.RemoveProductAsync(id);
        
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult History()
    {
        return View();
    }

    [HttpPost]
    public IActionResult History(Sort model)
    {
        var productAudits = productAuditService
            .RetrieveProductAuditsSortByDate(model.Date);

        ViewData["productAudits"] = productAudits.ToList();

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}