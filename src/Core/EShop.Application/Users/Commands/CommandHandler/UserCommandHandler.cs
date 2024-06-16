using EShop.Application.Results;
using EShop.Application.Services.Interfaces;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Users.Commands.CommandHandler;

public class UserCommandHandler : IRequestHandler<RegisterNewUserCommand, Result<IdentityResult>>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserAccountManager _userAccountManager;
	private readonly IUnitOfWork _unitOfWork;

	public UserCommandHandler(IUserRepository userRepository, IUserAccountManager userAccountManager, IUnitOfWork unitOfWork)
	{
		_userRepository = userRepository;	
		_userAccountManager = userAccountManager;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<IdentityResult>> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
	{
		var result = await _userAccountManager.RegisterAsync(request);
		await _unitOfWork.CompleteAsync();
		return result;
	}
}
