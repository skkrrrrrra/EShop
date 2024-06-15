using EShop.Application.Services.Interfaces;
using EShop.Application.Users.Commands.CreateUser;
using EShop.Common.Helpers;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using MediatR;

namespace EShop.Application.Users.Commands
{
    public class UserCommandHandler
		: IRequestHandler<CreateUserCommand, long>
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

		public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userAccountManager.CreateAsync(request);
			await _userRepository.AddAsync(user);
			await _unitOfWork.CompleteAsync();
			return user.Id;
		}
	}
}
