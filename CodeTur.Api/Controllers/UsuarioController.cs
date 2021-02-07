using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("signup")]
        [HttpPost]
        public GerencCommandResult SignUp(
               CriarUsuarioCommand command, 
               [FromServices] CriarUsuarioHandle handle
            )
        {
            return (GerencCommandResult)handle.Handle(command);
        }

        [Route("signup")]
        [HttpPost]
        public GerencCommandResult SignIn(LogarCommand command, [FromServices]LogarHandle handler)
        {
            var resultado = (GerencCommandResult)handler.Handle(command);
            return new GerencCommandResult(false, resultado.Mensagem, resultado.Data);
            
            if(resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);
                return new GerencCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }
                
        }

        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCodeTurSenai132"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "codetur",
                    "codetur",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
