using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Querries;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Queries.Pacote;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacoteController : ControllerBase
    {

        /// <summary>
        /// Este metodo Cria Pacotes
        /// </summary>
        /// <returns>Retorna o Pacote</returns>
        /// <response code="200">Retorna o item cadastrados</response>
        [HttpPost]
        [Authorize(Roles = "Admin")]        
        public GerencCommandResult Create(
            [FromBody] CriarPacoteCommand command,
            [FromServices] CriarPacoteCommandHandle handle)
        {
            return (GerencCommandResult)handle.Handle(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public  GerencCommandResult Update (Guid id,
            [FromBody] AlterarPacoteCommand command,
            [FromServices] AlterarPacoteHandle
            )

        [HttpPost()]
        [Authorize]
        public  GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandlers handle)
        {
            ListarPacotesQuery query = new ListarPacotesQuery();
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role);
            if(tipoUsuario.Value.ToString() == EnTipoUsuario.Admin.ToString())
            {
                query.Ativo = true;
            }
            return (GenericQueryResult)handle.Handler(query);

        }
    }
}
