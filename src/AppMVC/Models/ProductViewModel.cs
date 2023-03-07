using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models;

public class ProductViewModel
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }
}
