namespace AppMVC.Application.DataTransferObjects.Users;

public record UserForCreationDto(
    string userName,
    string passwordHash);
