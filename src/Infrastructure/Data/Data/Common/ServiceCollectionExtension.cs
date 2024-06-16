﻿using FluentMigrator.Runner.Processors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShop.Data.Common;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddFluentMigrator(
		this IServiceCollection services,
		string connectionString,
		Assembly assembly)
	{
		services
			.AddFluentMigratorCore()
			.ConfigureRunner(
				builder => builder
					.AddPostgres()
					.ScanIn(assembly).For.Migrations())
			.AddOptions<ProcessorOptions>()
			.Configure(
				options =>
				{
					options.ProviderSwitches = "Force Quote=false";
					options.Timeout = TimeSpan.FromMinutes(10);
					options.ConnectionString = connectionString;
				});

		return services;
	}
}