using EShop.Domain.Enums;
using MediatR;

namespace EShop.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public Sex Sex { get; set; }
    }
}
