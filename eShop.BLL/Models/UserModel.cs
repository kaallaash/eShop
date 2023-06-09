﻿using eShop.Core.Enums;

namespace eShop.BLL.Models;

public class UserModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role? Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public List<OrderModel> Orders { get; set; } = new();
}
