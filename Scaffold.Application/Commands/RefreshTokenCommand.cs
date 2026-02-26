using Scaffold.Application.Responses;
using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Application.Commands
{
  public sealed class RefreshTokenCommand : ICommand<Result<LoginResponse>>
  {
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
  }
}
