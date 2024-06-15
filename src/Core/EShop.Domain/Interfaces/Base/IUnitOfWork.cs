using EShop.Domain.Interfaces.Users;

namespace EShop.Domain.Interfaces.Base;

public interface IUnitOfWork
{
	IUserRepository Users { get; }
	Task CompleteAsync();
}