using eShop.Core.Enums;

namespace eShop.App.ViewModels.User;

public class UserDetailsViewModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
}