using EShop.Application.Users.Commands.Base;

namespace EShop.Application.Users.Commands;

public class RemoveByIdUserCommand : UserCommand
{
	public RemoveByIdUserCommand(long id)
	{
		Id = id;
	}
}