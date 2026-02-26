using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Entities.Usuario;
using Scaffold.Infrastructure.Dtos;

namespace Scaffold.Infrastructure
{
  public sealed class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
  }
}
