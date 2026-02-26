namespace Scaffold.Application.Responses
{
  public sealed class LoginResponse
  {
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
    public DateTime ExpiresAt { get; init; }
  }
}
