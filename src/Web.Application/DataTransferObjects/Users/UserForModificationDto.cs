using AppMVC.Domain.Enums;

namespace AppMVC.Application.DataTransferObjects.Users;

public record UserForModificationDto(
    int id,
    string? userName,
    string? password);
