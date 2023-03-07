using AppMVC.Domain.Entities;

namespace AppMVC.Application.Services;

public interface IUserFactory
{
    void MapToUser(
        User storageUser, 
        User userForModification);
}
