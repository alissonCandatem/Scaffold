using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared.Enums;

namespace Scaffold.Mediator.Shared
{
  public sealed class ResultNotification
  {
    public bool IsSuccess { get; }

    public IReadOnlyCollection<Notification> Notifications { get; }

    private ResultNotification(IReadOnlyCollection<Notification> notifications)
    {
      Notifications = notifications;
      IsSuccess = !notifications.Any(x => x.Type == ENotificationType.Error);
    }

    public static ResultNotification Ok() => new([]);

    public static ResultNotification Fail(IReadOnlyCollection<Notification> notifications) => new(notifications);

    public static ResultNotification FromContext(INotificationContext context)
       => new(context.Notifications);
  }
}
