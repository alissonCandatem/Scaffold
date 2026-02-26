namespace Scaffold.Domain.Primitives.Interfaces
{
  public interface IDomainEvent
  {
    Guid EventId { get; }
    DateTime OccurredAt { get; }
  }
}
