using Scaffold.Domain.Primitives.Interfaces;

namespace Scaffold.Mediator.Abstractions
{
  public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
  {
    Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
  }
}
