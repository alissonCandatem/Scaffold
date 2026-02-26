using Microsoft.Extensions.DependencyInjection;
using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Pipeline;
using Scaffold.Mediator.Shared;

namespace Scaffold.Mediator
{
  public static class Startup
  {
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
      services.AddScoped<ICommandDispatcher, CommandDispatcher>();
      services.AddScoped<INotificationContext, NotificationContext>();
      return services;
    }
  }
}
