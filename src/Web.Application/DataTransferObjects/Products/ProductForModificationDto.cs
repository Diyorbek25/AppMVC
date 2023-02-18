namespace AppMVC.Application.DataTransferObjects.Products;

public record ProductForModificationDto(
    int id,
    string? title,
    int? quantity,
    double? price);