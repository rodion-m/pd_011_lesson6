using Microsoft.AspNetCore.Mvc;
using RazorPagesPD011.Models;

namespace RazorPagesPD011.Controllers;

public sealed class CatalogController : Controller
{
    private readonly ICatalog _catalog;

    public CatalogController(ICatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog); //.NET 6+
        _catalog = catalog;
    }
    
    [HttpPost]
    public IActionResult ProductAdding([FromForm] Product type)
    {
        _catalog.AddProduct(type);
        return View(_catalog);
    }
    
    [HttpGet]
    public IActionResult ProductAdding()
    {
        return View(_catalog);
    }


}