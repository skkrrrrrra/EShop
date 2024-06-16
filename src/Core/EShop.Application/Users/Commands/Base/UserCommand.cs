using EShop.Domain.Enums;
using MediatR;

namespace EShop.Application.Users.Commands.Base;

public class UserCommand<TEntity> : IRequest<TEntity>
{
	public long Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string First { get; set; }
	public string Last { get; set; }
	public Sex Sex { get; set; }
}