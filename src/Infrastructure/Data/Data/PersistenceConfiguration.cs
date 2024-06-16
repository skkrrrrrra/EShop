using Data;
using EShop.Data.Repositories.Users;
using EShop.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Data;

public class PersistenceConfiguration
{
	public static void AddServices(IServiceCollection serviceCollection, string connectionString)
	{
		serviceCollection.AddScoped<IUserRepository, UserRepository>();
		serviceCollection.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(connectionString));
	}
}
