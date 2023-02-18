using AppMVC.Domain.Entities;
using AppMVC.Infrastructure.Contexts;

namespace AppMVC.Infrastructure.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(AppDbContext dbContext)
		: base(dbContext)
	{
	}
}
