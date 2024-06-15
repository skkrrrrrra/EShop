using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands.CreateUser;
using EShop.Domain.Entities;

namespace EShop.Application.Services
{
	public class UserAccountManager : IUserAccountManager
	{
		private readonly ConfigurationObject _configurationObject;
		public UserAccountManager(ConfigurationObject configurationObject) 
		{
			_configurationObject = configurationObject;
		}

		public async Task<User> CreateAsync(CreateUserCommand request)
		{

		}
	}
}