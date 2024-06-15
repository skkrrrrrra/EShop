using AutoMapper;
using EShop.Application.Requests.Auth;
using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using EShop.Application.Services.Interfaces;
using EShop.Common.Helpers;
using EShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ControllerBase
{
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	private readonly IMapper _mapper;
	private readonly IUserAccountManager _userAccountManager;
	private readonly ILogger<AuthController> _logger;

	public AuthController(
		SignInManager<User> signInManager,
		UserManager<User> userManager,
		IMapper mapper,
		IUserAccountManager userAccountManager,
		ILogger<AuthController> logger)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_mapper = mapper;
		_userAccountManager = userAccountManager;
		_logger = logger;
	}
	//TODO переписать userManager и SignInManager на свои реализации

	public async Task<Result<IdentityResult>> Register(RegisterRequest request)
	{
		if(ModelState.IsValid == false)
		{
			return new InvalidResult<IdentityResult>(ModelState); 
			// TODO: посмотреть какое есть свойство в модел стейте 
			//отвечающее за ошибки и отдавать его в еррор респонс
		}

		try
		{
			var user = await _userAccountManager.ComposeUserAsync(request);
			var result = await _userManager.CreateAsync(user);
			return new SuccessResult<IdentityResult>(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			return new InvalidResult<IdentityResult>(ex.Message);
		}
	}

	public async Task<Result<LoginResponse>> Login(LoginRequest request)
	{
		if(ModelState.IsValid == false)
		{
			return new InvalidResult<RegisterResponse>(ModelState.ToString());
			// TODO: посмотреть какое есть свойство в модел стейте 
			//отвечающее за ошибки и отдавать его в еррор респонс
		}

		var result = await _signInManager.CheckPasswordSignInAsync(request.Username, request.Password, false);

	}

}
