using EShop.Application.Results;
using EShop.Application.Users.Commands.Base;
using EShop.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Users.Commands;

public class RegisterNewUserCommand : UserCommand<Result<IdentityResult>>
{
	public RegisterNewUserCommand(string username, string email, string phoneNumber, 
        string first, string last, Sex sex) 
    {
        Username = username;
        Email = email;
        PhoneNumber = phoneNumber;
        First = first;
        Last = last;
        Sex = sex;
    }
}
