namespace RazorPagesPD011.Models;

public class InMemoryCatalog : ICatalog
{
    private readonly List<Product> _products = new();
    

    public List<Product> GetProducts()
    {
        return _products;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}