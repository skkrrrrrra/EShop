using AutoMapper;
using EShop.Application.Requests.Auth;
using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands;
using EShop.Domain;
using EShop.Domain.Entities;
using EShop.Domain.Enums;
using EShop.Domain.Interfaces.Audit;
using EShop.Domain.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EShop.Application.Services;

public class UserAccountManager : UserManager<User>, IUserAccountManager
{
	private readonly ConfigurationObject _configurationObject;
	private readonly IMapper _mapper;

	private readonly IUserRepository _userRepository;

	public UserAccountManager(IUserStore<User> store,
			IOptions<IdentityOptions> optionsAccessor,
			IPasswordHasher<User> passwordHasher,
			IEnumerable<IUserValidator<User>> userValidators,
			IEnumerable<IPasswordValidator<User>> passwordValidators,
			ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors,
			IServiceProvider services,
			ILogger<UserManager<User>> logger,
			IOptions<JwtOptions> jwtOptions,
			IAuditUserProvider provider,//TODO implement
			ConfigurationObject configurationObject,
			IMapper mapper,
			IUserRepository userRepository)
		: base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
	{
		_configurationObject = configurationObject;
		_mapper = mapper;
		_userRepository = userRepository;
	}

	public async Task<Result<IdentityResult>> RegisterAsync(RegisterNewUserCommand registerCommand)
	{
		var user = _mapper.Map<User>(registerCommand);
		var userProfile = _mapper.Map<UserProfile>(registerCommand);
		user.Profile = userProfile;

		var result = await CreateAsync(user, registerCommand.Password);
		if (result.Succeeded == false)
		{
			return new InvalidResult<IdentityResult>(string.Join(";\n", result.Errors));
		}

		return new SuccessResult<IdentityResult>(result);
	}

	public async Task<Result<LoginResponse>> LoginAsync(LoginUserCommand loginCommand)
	{
		var user = await FindByNameAsync(loginCommand.Username);
		if (user is null || !await CheckPasswordAsync(user, loginCommand.Password))
			return new InvalidResult<LoginResponse>("The username or password is incorrect");


		var roles = await GetRolesAsync(user);
		var claims = new List<Claim>
		{
			new(ClaimTypes.Sid, user.Id.ToString()),
			new(ClaimTypes.Email, user.Email),
			new(ClaimTypes.Role, roles.First())
		};

		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationObject.Jwt.Key));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
		var tokenDescriptor = new JwtSecurityToken(
			issuer: _configurationObject.Jwt.Issuer,
			audience: _configurationObject.Jwt.Audience,
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials);

		var result = new LoginResponse
		{
			Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor),
		};

		return new SuccessResult<LoginResponse>(result);
	}
}
