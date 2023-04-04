using eShop.Core.Enums;

namespace eShop.App.ViewModels.User;

public class UserUpdateViewModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
}