using Scaffold.Mediator.Shared;

namespace Scaffold.Mediator.Abstractions
{
  public interface ICommandResultValidator<TCommand>
  {
    Error? Validate(TCommand command);
  }
}
