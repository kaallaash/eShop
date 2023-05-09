namespace eShop.App.Models.Token;

public class TokenDetailsAppModel
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}