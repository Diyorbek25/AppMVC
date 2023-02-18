using AppMVC.Application.DataTransferObjects.Users;
using AppMVC.Domain.Entities;
using AppMVC.Domain.Enums;

namespace AppMVC.Application.Services;

public class UserFactory : IUserFactory
{
    public User MapToUser(UserDto userDto)
    {
        return new User()
        {
            Id = userDto.id,
            UserName = userDto.userName,
            UserRole = userDto.userRole
        };
    }

    public User MapToUser(UserForCreationDto userForCreationDto)
    {
        return new User()
        {
            UserName = userForCreationDto.userName,
            PasswordHash = userForCreationDto.passwordHash,
            UserRole = Role.User
        };
    }

    public void MapToUser(User storageUser,
        UserForModificationDto userForModificationDto)
    {
        storageUser.UserName = userForModificationDto.userName 
            ?? storageUser.UserName;

        storageUser.PasswordHash = userForModificationDto.password 
            ?? storageUser.PasswordHash;
    }

    public UserDto MapToUserDto(User user)
    {
        return new UserDto(
            id: user.Id,
            userName: user.UserName,
            userRole: user.UserRole);
    }
}
