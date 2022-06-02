using Microsoft.AspNetCore.Mvc;
using RazorPagesPD011.Models;

namespace RazorPagesPD011.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalog _catalog;

    public CatalogController(ICatalog catalog)
    {
        _catalog = catalog;
    }
    
    [HttpPost]
    public IActionResult ProductAdding([FromForm] Product product)
    {
        _catalog.AddProduct(product);
        return View(_catalog);
    }
    
    [HttpGet]
    public IActionResult ProductAdding()
    {
        return View(_catalog);
    }
}