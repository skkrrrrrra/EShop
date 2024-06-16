namespace EShop.API;

public static class Program
{
	public static void Main(string[] args) =>
		CreateHostBuilder(args)
			.Build();

	private static IHostBuilder CreateHostBuilder(string[] args)
	{
		return Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(builder =>
			{
				builder.UseStartup<Startup>();
			});
	}
}