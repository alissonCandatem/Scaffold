using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scaffold.Infrastructure
{
  public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

      optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=scaffold;Username=postgres;Password=postgres");

      return new AppDbContext(optionsBuilder.Options);
    }
  }
}
