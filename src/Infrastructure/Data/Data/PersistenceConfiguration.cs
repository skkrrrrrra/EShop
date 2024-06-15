using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Data
{
	public class PersistenceConfiguration
	{
		public static void AddServices(IServiceCollection serviceCollection, string connectionString)
		{
			serviceCollection.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(connectionString));
		}
	}
}
