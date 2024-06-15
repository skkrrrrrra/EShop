using EShop.Application.Services.Interfaces;
using EShop.Application.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Services;

public class UserAppService : ICustomerAppService //TODO реализовать класс
{
	public Task<CustomerViewModel> GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<ValidationResult> Register(CustomerViewModel customerViewModel)
	{
		throw new NotImplementedException();
	}

	public Task<ValidationResult> Remove(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<ValidationResult> Update(CustomerViewModel customerViewModel)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}