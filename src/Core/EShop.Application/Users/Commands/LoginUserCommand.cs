using EShop.Application.Responses.Auth;
using EShop.Application.Results;
using EShop.Application.Users.Commands.Base;

namespace EShop.Application.Users.Commands;

public class LoginUserCommand : UserCommand<Result<LoginResponse>>
{
}