using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scaffold.Application.Interfaces;
using Scaffold.Domain.Interfaces.Usuario;
using Scaffold.Infrastructure.Repositories;
using Scaffold.Infrastructure.Services;
using Scaffold.Mediator;

namespace Scaffold.Infrastructure
{
  public static class Startup
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IUsuarioRepository, UsuarioRepository>();
      services.AddScoped<IJwtService, JwtService>();

      return services;
    }
  }
}
