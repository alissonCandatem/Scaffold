using Scaffold.Domain.Primitives.Interfaces;

namespace Scaffold.Domain.Events.Usuario
{
  public sealed record UsuarioSenhaAlteradaEvent : IDomainEvent
  {
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
    public Guid UserId { get; init; }
  }
}
