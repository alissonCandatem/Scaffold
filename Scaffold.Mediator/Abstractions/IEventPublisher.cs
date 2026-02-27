using Scaffold.Domain.Primitives.Interfaces;

namespace Scaffold.Mediator.Abstractions
{
  public interface IEventPublisher
  {
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
  }
}
