using Data;
using EShop.Application;
using EShop.Application.Services;
using EShop.Data;
using EShop.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;

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
			//TODO добавить все классы и интерфейсы в DI
			PersistenceConfiguration.AddServices(services, configurationObject.ConnectionString);
			ApplicationConfiguration.AddServices(services);

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Diary API",
					Version = "v1"
				});
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                  Enter 'Bearer' [space] and then your token in the text input below.
                  \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "oauth2",
							Name = "Bearer",
							In = ParameterLocation.Header,

						},
						new List<string>()
					}
				});
			});

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

		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseForwardedHeaders();
			if (env.IsDevelopment())
			{
				app.UseCors("MyAllowedOrigins");
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(
			endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		private void AddAuthorizationServices(IServiceCollection services, ConfigurationObject configObject)
		{
			services.AddHttpContextAccessor()
				.AddAuthorization()
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = configObject.Jwt.Issuer,
						ValidAudience = configObject.Jwt.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configObject.Jwt.Key)),
					};
					options.RequireHttpsMetadata = false;
				});
		}
	}
}