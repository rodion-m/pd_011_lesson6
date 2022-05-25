using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers;

public class CatalogController : Controller
{
    private static ConcurrentBag<Product> _catalog = new();
    
    [HttpPost]
    public IActionResult ProductAdding([FromForm] Product product)
    {
        _catalog.Add(product);
        return View(_catalog);
    }
    
    [HttpGet]
    public IActionResult ProductAdding()
    {
        return View(_catalog);
    }
}