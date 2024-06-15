using EShop.API;

namespace Eshop.API;

public static class Program
{
	public static void Main(string[] args) =>
		CreateHostBuilder(args)
			.Build();

	//TODO ������������ ����������� ���������� ��� ��������
	private static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(builder =>
			{
				builder.UseStartup<Startup>();
			});
}