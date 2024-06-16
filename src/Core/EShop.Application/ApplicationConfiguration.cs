using EShop.Application.Services;
using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands;
using EShop.Application.Users.Commands.CommandHandler;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShop.Application;

public class ApplicationConfiguration
{
	public static void AddServices(IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IUserAccountManager, UserAccountManager>();
		//serviceCollection.AddMediatR(item => 
		//	{
		//		//item.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly();
		//		//item.Lifetime = ServiceLifetime.Scoped;
		//		typeof(UserCommandHandler).Assembly, typeof(RegisterNewUserCommand).Assembly
		//	});

		serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
	}
}
