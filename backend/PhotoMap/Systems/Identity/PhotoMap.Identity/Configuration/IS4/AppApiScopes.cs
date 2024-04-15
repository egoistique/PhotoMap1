namespace PhotoMap.Identity.Configuration;

using PhotoMap.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.PointsRead, "Read"),
            new ApiScope(AppScopes.PointsWrite, "Write")
        };
}