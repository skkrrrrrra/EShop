using EShop.Application.Services.Interfaces;
using EShop.Common.Helpers;
using EShop.Domain.Entities;
using EShop.Domain.Interfaces.Base;
using EShop.Domain.Interfaces.Users;
using MediatR;

namespace EShop.Application.Users.Commands.CommandHandler
{
    public class UserCommandHandler
        : IRequestHandler<RegisterNewUserCommand, long>
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

        public async Task<long> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userAccountManager.CreateAsync(request);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user.Id;
        }
        //TO DO реализовать
		public async Task<long> Handle(RemoveByIdUserCommand request, CancellationToken cancellationToken)
		{
		}

		public async Task<long> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
		{
		}

		public async Task<long> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
		}
	}
}
