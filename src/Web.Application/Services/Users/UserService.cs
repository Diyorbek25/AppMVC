using AppMVC.Application.DataTransferObjects.Users;
using AppMVC.Application.Services;
using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Repositories.Users;

namespace AppMVC.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;

    public UserService(IUserRepository userRepository, IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }


    public async ValueTask<UserDto> CreateUserAsync(
        UserForCreationDto userForCreationDto)
    {
        User user = userFactory.MapToUser(userForCreationDto);

        var createdUser = await userRepository.InsertAsync(user);

        return userFactory.MapToUserDto(createdUser);
    }

    public IQueryable<UserDto> RetrieveUser()
    {
        IQueryable<User> users = userRepository.SelectAll();

        return users.Select(user => userFactory.MapToUserDto(user));
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(int id)
    {
        User user = await userRepository.SelectByIdAsync(id);

        return userFactory.MapToUserDto(user);
    }

    public async ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        User user = await userRepository.SelectByIdAsync(userForModificationDto.id);

        userFactory.MapToUser(user, userForModificationDto);

        var modifyUser = await userRepository.UpdateAsync(user);

        return userFactory.MapToUserDto(modifyUser);
    }

    public async ValueTask<UserDto> RemoveUserAsync(int id)
    {
        var user = await userRepository.SelectByIdAsync(id);

        var removedUser = await userRepository.RemoveAsync(user);

        return userFactory.MapToUserDto(removedUser);
    }

    public IQueryable<User> RetrieveUserByUserNameAndPassword()
    {
        return userRepository.SelectAll();
    }
}
