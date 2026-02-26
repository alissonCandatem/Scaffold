using Scaffold.Domain.Entities.Usuario;

namespace Scaffold.Application.Interfaces
{
  public interface IJwtService
  {
    string GerarAccessToken(User user);
    string GerarRefreshToken();
    Guid? ObterUserIdToken(string accessToken);
  }
}
