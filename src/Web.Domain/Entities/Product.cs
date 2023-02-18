namespace AppMVC.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double? TotalPrice { get; set; }

    public ICollection<ProductAudit> ProductAudits { get; set; }
}
