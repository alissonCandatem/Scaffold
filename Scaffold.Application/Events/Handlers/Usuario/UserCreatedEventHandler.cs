using Microsoft.Extensions.Logging;
using Scaffold.Domain.Events.Usuario;
using Scaffold.Mediator.Abstractions;

namespace Scaffold.Application.Events.Handlers.Usuario
{
  public sealed class UserCreatedEventHandler : IDomainEventHandler<UsuarioCriadoEvent>
  {
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
      _logger = logger;
    }

    public Task Handle(UsuarioCriadoEvent domainEvent, CancellationToken cancellationToken)
    {
      _logger.LogInformation(
          $"Usuário criado: {domainEvent.UserId} - {domainEvent.Email}");

      return Task.CompletedTask;
    }
  }
}
