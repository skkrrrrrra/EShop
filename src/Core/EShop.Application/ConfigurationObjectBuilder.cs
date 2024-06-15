using EShop.Common.Helpers;
using EShop.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace EShop.Application
{
	public class ConfigurationObjectBuilder
	{
		private readonly IConfiguration _configuration;
		public ConfigurationObjectBuilder(IConfiguration configuration) 
		{
			_configuration = configuration;
		}

		public ConfigurationObject Configure()
		{
			return new()
			{
				ConnectionString = _configuration.GetConnectionString("PostgresConnection"),
				Jwt = new()
				{
					Issuer = _configuration["Jwt:Issuer"],
					Audience = _configuration["Jwt:Audience"],
					Key = _configuration["Jwt:Key"],
					ExpirationDate = DateHelper.GetCurrentDateTime().AddSeconds(long.Parse(_configuration["Jwt:ExpirationDate"])),
				}
			};
		}
	}
}
