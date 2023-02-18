using AppMVC.Application.DataTransferObjects.Users;
using AppMVC.Domain.Entities;

namespace AppMVC.Domain.Services;

public interface IUserService
{
    ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
    IQueryable<UserDto> RetrieveUser();
    IQueryable<User> RetrieveUserByUserNameAndPassword();
    ValueTask<UserDto> RetrieveUserByIdAsync(int id);
    ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
    ValueTask<UserDto> RemoveUserAsync(int id);
}
