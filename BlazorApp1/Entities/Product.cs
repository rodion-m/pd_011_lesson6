namespace BlazorApp1.Entities;

public class Product
{
    public Product(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}";
    }
}
