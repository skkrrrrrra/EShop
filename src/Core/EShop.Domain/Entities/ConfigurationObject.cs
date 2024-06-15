namespace EShop.Domain.Entities;

public class ConfigurationObject
{
	public required string ConnectionString { get; init; }
	public required JwtOptions Jwt { get; init; }
}

public class JwtOptions
{
	public required string Issuer { get; init; }
	public required string Audience { get; init; }
	public required string Key { get; init; }
	public required DateTime ExpirationDate { get; init; }
}
