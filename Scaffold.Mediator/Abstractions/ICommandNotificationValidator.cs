using Scaffold.Mediator.Shared;

namespace Scaffold.Mediator.Abstractions
{
  public interface ICommandNotificationValidator<TCommand>
  {
    IEnumerable<Notification> Validate(TCommand command);
  }
}
