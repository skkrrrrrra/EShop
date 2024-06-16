namespace EShop.Domain.Interfaces.Audit;

public interface IAuditUserProvider
{
	long? GetUserId();
	string GetUserRole();
}