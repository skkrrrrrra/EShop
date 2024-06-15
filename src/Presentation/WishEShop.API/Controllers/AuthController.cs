using EShop.Application.Requests.Auth;
using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ControllerBase
{
	public AuthController()
	{

	}

	public async Task<Result<RegisterResponse>> Register(RegisterRequest request)
	{

	}

	public async Task<Result<LoginResponse>> Login(LoginRequest request)
	{

	}

}
