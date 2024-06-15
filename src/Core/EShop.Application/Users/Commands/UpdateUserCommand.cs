using EShop.Application.Users.Commands.Base;
using EShop.Domain.Enums;

namespace EShop.Application.Users.Commands;

public class UpdateUserCommand : UserCommand
{
	public UpdateUserCommand(long id, string username, string email, string phoneNumber,
		string first, string last, Sex sex)
	{
		Id = id;
		Username = username;
		Email = email;
		PhoneNumber = phoneNumber;
		First = first;
		Last = last;
		Sex = sex;
	}
}