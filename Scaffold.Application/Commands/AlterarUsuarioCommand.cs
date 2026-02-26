using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Application.Commands
{
  public record AlterarUsuarioCommand : ICommand<ResultNotification>
  {
    public string? Nome { get; set; }
    public int Idade { get; set; }
  }
}
