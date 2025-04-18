namespace Ms1.Models;

public class Product
{
    public int id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
}