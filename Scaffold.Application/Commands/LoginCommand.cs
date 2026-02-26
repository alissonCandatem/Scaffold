using Scaffold.Application.Responses;
using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Application.Commands
{
  public sealed class LoginCommand : ICommand<Result<LoginResponse>>
  {
    public string Email { get; init; } = null!;
    public string Senha { get; init; } = null!;
  }
}
