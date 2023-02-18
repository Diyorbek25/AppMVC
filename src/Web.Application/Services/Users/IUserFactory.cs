using AppMVC.Application.DataTransferObjects.Users;
using AppMVC.Domain.Entities;

namespace AppMVC.Application.Services;

public interface IUserFactory
{
    User MapToUser(UserDto userDto);
    UserDto MapToUserDto(User user);
    User MapToUser(UserForCreationDto userForCreationDto);
    void MapToUser(
        User storageUser, 
        UserForModificationDto userForModificationDto);
}
