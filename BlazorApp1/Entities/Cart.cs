namespace BlazorApp1.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<CartItem> Items { get; set; } = new();
}

public class CartItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    
    public Product? Product { get; set; }
    public Cart Cart { get; set; } = null!;

    public override string ToString()
    {
        return $"Product: {Product}, Quantity: {Quantity}";
    }
}