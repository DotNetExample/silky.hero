using System.ComponentModel.DataAnnotations;

namespace Silky.Account.Application.Contracts.Account.Dtos;

public class LoginInput
{
    [Required(ErrorMessage = "账号不允许为空")]
    public string Account { get; set; }

    [Required(ErrorMessage = "密码不允许为空")]
    public string Password { get; set; }
}