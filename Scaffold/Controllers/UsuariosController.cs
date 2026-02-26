using Microsoft.AspNetCore.Mvc;
using Scaffold.Application.Commands;
using Scaffold.Application.Responses;
using Scaffold.Mediator.Abstractions;
using Scaffold.Mediator.Shared;

namespace Scaffold.Controllers
{
  [Route("api/usuario")]
  [ApiController]
  public class UsuariosController : ControllerBase
  {
    private readonly ICommandDispatcher _dispatcher;

    public UsuariosController(ICommandDispatcher dispatcher)
    {
      _dispatcher = dispatcher;
    }

    [HttpPost("registrar")]
    public async Task<ResultNotification> Registrar(CriarUsuarioCommand command)
      => await _dispatcher.Send(command);

    [HttpPost("login")]
    public async Task<Result<LoginResponse>> Login(LoginCommand command)
      => await _dispatcher.Send(command);

    [HttpPost("refresh-token")]
    public async Task<Result<LoginResponse>> RefreshToken(RefreshTokenCommand command)
      => await _dispatcher.Send(command);
  }
}
