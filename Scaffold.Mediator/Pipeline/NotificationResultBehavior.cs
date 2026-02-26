using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Mediator.Pipeline
{
  public sealed class NotificationResultBehavior<TCommand> : INotificationBehavior<TCommand> where TCommand : ICommand<ResultNotification>
  {
    private readonly INotificationContext _notification;

    public NotificationResultBehavior(INotificationContext notification)
    {
      _notification = notification;
    }

    public async Task<ResultNotification> Handle(TCommand command, CancellationToken cancellationToken, Func<Task<ResultNotification>> next)
    {
      var result = await next();

      if (!_notification.Notifications.Any())
        return result;

      return ResultNotification.FromContext(_notification);
    }
  }
}
