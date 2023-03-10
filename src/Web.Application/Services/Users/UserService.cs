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


    public async ValueTask<User> CreateUserAsync(
        User user)
    {
        var createdUser = await userRepository.InsertAsync(user);

        return createdUser;
    }

    public IQueryable<User> RetrieveUsers() => 
        userRepository.SelectAll();

    public async ValueTask<User> RetrieveUserByIdAsync(int id) => 
        await userRepository.SelectByIdAsync(id);

    public async ValueTask<User> ModifyUserAsync(User user)
    {
        User storageUser = await userRepository.SelectByIdAsync(user.Id);

        userFactory.MapToUser(storageUser, user);

        var modifyUser = await userRepository.UpdateAsync(storageUser);

        return modifyUser;
    }

    public async ValueTask<User> RemoveUserAsync(int id)
    {
        var user = await userRepository.SelectByIdAsync(id);

        var removedUser = await userRepository.RemoveAsync(user);

        return removedUser;
    }

    public User RetrieveUserByUserNameAndPassword(
        string userName,
        string password)
    {
        var storageUser = userRepository
            .SelectAll()
            .FirstOrDefault(
            user => user.UserName == userName &&
            user.PasswordHash == password);

        return storageUser;
    }
}
