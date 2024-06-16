using AutoMapper;
using EShop.Application.Requests.Auth;
using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	private readonly IUserAccountManager _userAccountManager;
	private readonly ILogger<AuthController> _logger;

	public AuthController(
		IMediator mediator,
		IMapper mapper,
		IUserAccountManager userAccountManager,
		ILogger<AuthController> logger)
	{
		_mediator = mediator;
		_mapper = mapper;
		_userAccountManager = userAccountManager;
		_logger = logger;
	}
	//TODO переписать userManager и SignInManager на свои реализации

	public async Task<Result<IdentityResult>> RegisterAsync(RegisterRequest request)
	{
		if(ModelState.IsValid == false)
		{
			return new InvalidResult<IdentityResult>(string.Join(";\n", ModelState.Select(item => item.Value))); 
		}

		try
		{
			var registerCommand = new RegisterNewUserCommand(request.Username, request.Email, request.PhoneNumber,
				request.First, request.Last, request.Sex);
			var result = await _mediator.Send(registerCommand);
			return new InvalidResult<IdentityResult>(result.ToString());
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return new InvalidResult<IdentityResult>(ex.Message);
		}
	}

	public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
	{
		if(ModelState.IsValid == false)
		{
			return new InvalidResult<LoginResponse>(string.Join(";\n", ModelState.Select(item => item.Value)));
		}

		try
		{
			return await _mediator.Send(new LoginUserCommand());
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return new InvalidResult<LoginResponse>(ex.Message);
		}
	}
}
