using CodeTur.Comum.Commands;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Dominio.Queries.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public IConfiguration Configuration { get; }

        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("users")]
        [HttpGet]
        public GerencCommandResult GetAll(
            [FromServices] ListarUsuarioQueryHandler handler
        )
        {
            var query = new ListaUsuarioResult();
            return (GerencCommandResult)handler.Handle(query);
        }

        [Route("signup")]
        [HttpPost]
        public GerencCommandResult SignUp(
               CriarUsuarioCommand command, 
               [FromServices] CriarUsuarioHandle handle
            )
        {
            return (GerencCommandResult)handle.Handle(command);
        }

        [Route("signin")]
        [HttpPost]
        public GerencCommandResult SignIn(
            [FromBody] LogarCommand command,
            [FromServices] LogarHandle handler
        )
        {
            var resultado = (GerencCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                Usuario usuario = (Usuario)resultado.Data;
                var token = new Token(
                                        Configuration["Token:issuer"],
                                        Configuration["Token:audience"],
                                        Configuration["Token:secretKey"]
                                     )
                                     .GerarJsonWebToken(
                                        usuario.Id,
                                        usuario.Nome,
                                        usuario.Email,
                                        usuario.TipoUsuario.ToString()
                                     );

                return new GerencCommandResult(true, "Usuário logado", new { token = token });
            }

            return resultado;
        }

        [Route("users/{id}")]
        [HttpGet]
        public GerencCommandResult GetByIdUser(Guid id,
            [FromServices] BuscarUsuarioPorIdQueryHandler handler
        )
        {
            var query = new BuscarUsuarioPorIdQuery();
            query.IdUsuario = id;
            return (GerencCommandResult)handler.Handle(query);
        }

        [Route("reset-password")]
        [HttpPut]
        public GerencCommandResult ResetPassword(
            [FromBody] EsqueciSenhaCommadn command,
            [FromServices] EsqueciSenhaHadler handler
        )
        {
            var resultado = (GerencCommandResult)handler.Handle(command);

            return resultado;
        }


        [Route("update-Passowrd")]
        [Authorize]
        [HttpPut]

        public GerencCommandResult UpdatePassword(
            [FromBody] AlterarSenha command,
            [FromServices] AlterarSenhaHandler handler
            )
        {
            var idUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            command.IdUsuario = new Guid(idUsuario.Value);

            return (GerencCommandResult)handler.Handle(command);
        }

        [Route("")]
        [Authorize]
        [HttpPut]
        public GerencCommandResult UpdateAccount(
           [FromBody] AlterarUsuarioCommand command,
           [FromServices] AlterarUsuarioHandler handler
       )
        {
            var idUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            command.IdUsuario = new Guid(idUsuario.Value);

            return (GerencCommandResult)handler.Handle(command);
        }

    }
}
