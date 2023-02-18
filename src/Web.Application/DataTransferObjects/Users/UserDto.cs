using AppMVC.Domain.Enums;

namespace AppMVC.Application.DataTransferObjects.Users;

public record UserDto(
    int id,
    string userName,
    Role userRole);
