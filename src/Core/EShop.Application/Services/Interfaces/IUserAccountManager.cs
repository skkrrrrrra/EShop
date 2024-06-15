using EShop.Application.Requests.Auth;
using EShop.Application.Users.Commands.CreateUser;
using EShop.Domain.Entities;

namespace EShop.Application.Services.Interfaces
{
	public interface IUserAccountManager
	{
		Task<User> CreateAsync(CreateUserCommand request);
	}
}