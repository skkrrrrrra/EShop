using AutoMapper;
using EShop.Application.Requests.Auth;
using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands;
using EShop.Common.Helpers;
using EShop.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace EShop.Application.Services;

public class UserAccountManager : IUserAccountManager
{
	private readonly ConfigurationObject _configurationObject;
	private readonly IMapper _mapper;

	public UserAccountManager(ConfigurationObject configurationObject, IMapper mapper)
	{
		_configurationObject = configurationObject;
		_mapper = mapper;
	}

	public async Task<User> ComposeUserAsync(RegisterRequest request)
	{
		var now = DateHelper.GetCurrentDateTime();
		var user = new User(0, now, now, false, null, request.Username, string.Empty, request.Email, false, request.PhoneNumber);

		var saltAndHash = CalculateSaltWithCash(Guid.NewGuid().ToString(), request.Password);
		user.PasswordSalt = saltAndHash.Item1;
		user.PasswordHash = saltAndHash.Item2;
		return user;
	}

	private (string, string) CalculateSaltWithCash(string saltString, string password)
	{
		var salt = Encoding.UTF8.GetBytes(saltString);
		using (var hmac = new HMACSHA512(salt))
		{
			var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			return (string.Join("", salt), string.Join("", passwordHash));
		}
	}
}