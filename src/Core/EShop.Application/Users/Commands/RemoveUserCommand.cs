using EShop.Application.Users.Commands.Base;
using EShop.Domain.Enums;

namespace EShop.Application.Users.Commands;

public class RemoveUserCommand : UserCommand<long>
{
	public RemoveUserCommand(long id, string username, string email, string phoneNumber)
	{
		Id = id;
		Username = username;
		Email = email;
		PhoneNumber = phoneNumber;
	}
}