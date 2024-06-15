using EShop.Application.Requests.Auth;
using EShop.Application.Users.Commands;
using EShop.Domain.Entities;

namespace EShop.Application.Services.Interfaces;

public interface IUserAccountManager
{
	Task<User> ComposeUserAsync(RegisterRequest request);
}