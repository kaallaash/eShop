using eShop.Core.Entities;
using eShop.Core.Enums;

namespace eShop.DAL.Entities;

public class UserEntity : BaseEntity
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public List<OrderEntity> Orders { get; set; } = new();
}