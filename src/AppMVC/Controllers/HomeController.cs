using AppMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Repositories.ProductAudits;
using AppMVC.Infrastructure.Repositories.Products;

namespace AppMVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepository productRepository;
    private readonly IProductAuditRepository productAuditRepository;

    public HomeController(
        ILogger<HomeController> logger, 
        IProductRepository productRepository, 
        IProductAuditRepository productAuditRepository)
    {
        _logger = logger;
        this.productRepository = productRepository;
        this.productAuditRepository = productAuditRepository;
    }

    public IActionResult Index()
    {
        var models = productRepository.SelectAll();

        return View(models);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(ProductViewModel model, int id)
    {
        Product product = null;
        if (ModelState.IsValid)
        {
            product = await productRepository.SelectByIdAsync(id);
            ProductAudit productAudit = new ProductAudit()
            {
                Title = model.Title != product.Title ? model.Title : null,
                Quantity = model.Quantity != product.Quantity ? model.Quantity : null,
                Price = model.Price != product.Price ? model.Price : null,
                ChangedDate = DateTime.Now,
                UserId = int.Parse(User.Claims.ToArray()[2].Value),
                ProductId = id
            };

            product.Title = model.Title;
            product.Quantity = model.Quantity;
            product.Price = model.Price;

            await productRepository.UpdateAsync(product);
            await productAuditRepository.InsertAsync(productAudit);
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> EditProduct(int productId)
    {
        var product = await productRepository.SelectByIdAsync(productId);
        return View(product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await productRepository.SelectByIdAsync(id);
        await productRepository.RemoveAsync(product);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var product = new Product()
            {
                Title = model.Title,
                Quantity = model.Quantity,
                Price = model.Price
            };
            await productRepository.InsertAsync(product);
        }

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
        var productAudits = productAuditRepository.SelectAll()
            .Where(
            history => history.ChangedDate.Year == model.Date.Year &&
            history.ChangedDate.Month == model.Date.Month &&
            history.ChangedDate.Day == model.Date.Day);

        ViewData["productAudits"] = productAudits.ToList();

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}