using EShop.Application.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Services.Interfaces;

public interface ICustomerAppService : IDisposable
{
	Task<CustomerViewModel> GetById(Guid id);

	Task<ValidationResult> Register(CustomerViewModel customerViewModel);
	Task<ValidationResult> Update(CustomerViewModel customerViewModel);
	Task<ValidationResult> Remove(Guid id);
}