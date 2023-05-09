namespace eShop.BLL.Models.Token;

public class TokenDetailsModel
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}