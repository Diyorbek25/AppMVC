using AppMVC.Domain.Entities;

namespace AppMVC.Domain.Services;

public interface IUserService
{
    ValueTask<User> CreateUserAsync(User user);
    IQueryable<User> RetrieveUser();
    User RetrieveUserByUserNameAndPassword(string userName, string password);
    ValueTask<User> RetrieveUserByIdAsync(int id);
    ValueTask<User> ModifyUserAsync(User user);
    ValueTask<User> RemoveUserAsync(int id);
}
