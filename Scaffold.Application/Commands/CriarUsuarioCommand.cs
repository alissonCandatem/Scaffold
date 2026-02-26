using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Application.Commands
{
  public record CriarUsuarioCommand : ICommand<ResultNotification>
  {
    public string Nome { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Senha { get; init; } = null!;
  }
}
