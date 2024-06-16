using EShop.Application.Requests.Auth;
using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using EShop.Application.Users.Commands;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Services.Interfaces;

public interface IUserAccountManager
{
	Task<Result<LoginResponse>> LoginAsync(LoginUserCommand request);
	Task<Result<IdentityResult>> RegisterAsync(RegisterNewUserCommand request);

}