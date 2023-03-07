using AppMVC.Domain.Entities;

namespace AppMVC.Application.Services;

public class UserFactory : IUserFactory
{
   

    public void MapToUser(User storageUser,
        User userForModification)
    {
        storageUser.UserName = userForModification.UserName 
            ?? storageUser.UserName;

        storageUser.PasswordHash = userForModification.PasswordHash 
            ?? storageUser.PasswordHash;
    }
}
