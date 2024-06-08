namespace OAuthLoginAPI.Services
{
    public interface IJwtAuthService
    {
        string GenerateJwtToken(string username, IEnumerable<string> roles, IEnumerable<string> scopes);
    }
}
