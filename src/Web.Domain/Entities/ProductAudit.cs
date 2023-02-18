namespace AppMVC.Domain.Entities;

public class ProductAudit
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Quantity { get; set; }
    public double? Price { get; set; }
    public DateTime ChangedDate { get; set; }

    public int UserId { get; set; }
    public int ProductId { get; set; }

    public User? User { get; set; }
    public Product? Product { get; set; }
}
