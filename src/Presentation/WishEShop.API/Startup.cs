using EShop.Application;
using EShop.Data;

namespace EShop.API
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration) => _configuration = configuration;

		public void ConfigureServices(IServiceCollection services)
		{
			ConfigurationObjectBuilder configObjectBuilder = new(_configuration);
			var configurationObject = configObjectBuilder.Configure();

			services.AddSingleton(configurationObject);
			PersistenceConfiguration.AddServices(services, configurationObject.ConnectionString);
			ApplicationConfiguration.AddServices(services);

			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("MyAllowedOrigins",
					policy =>
					{
						policy.WithOrigins("http://localhost:53157")
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});
		}
	}
}