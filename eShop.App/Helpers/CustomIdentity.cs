using System.Security.Principal;

namespace eShop.App.Helpers;

public class CustomIdentity : IIdentity
{
    public string AuthenticationType { get; }
    public bool IsAuthenticated { get; }
    public string Name { get; }

    public CustomIdentity(string name, bool isAuthenticated)
    {
        Name = name;
        IsAuthenticated = isAuthenticated;
        AuthenticationType = "CustomAuthentication";
    }
}