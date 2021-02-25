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
            [FromServices] AlterarPacoteHandler handler
            )
        {
            if (id == Guid.Empty)
                return new GerencCommandResult(false, "Informe o Id do Pacote", "");
            command.IdPacote = id;

            return (GerencCommandResult)handler.Handle(command);
        }

        [HttpPut("{id}/image")]
        [Authorize(Roles = "Admin")]
        public GerencCommandResult UpdateImage(Guid id,
            [FromBody] AlterarImagemPacoteCommand command,
            [FromServices] AlterarImagemHandler handler
        )
        {
            if (id == Guid.Empty)
                return new GerencCommandResult(false, "Informe o Id do Pacote", "");

            command.IdPacote = id;

            return (GerencCommandResult)handler.Handle(command);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public GerencCommandResult UpdateStatus(Guid id,
            [FromBody] AlterarStatusCommand command,
            [FromServices] AlterarStatusHandler handler
        )
        {
            if (id == Guid.Empty)
                return new GerencCommandResult(false, "Informe o Id do Pacote", "");

            command.IdPacote = id;

            return (GerencCommandResult)handler.Handle(command);
        }

    
        [HttpGet()]
        [Authorize]
        public  GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandlers handle)
        {
            ListarPacotesQuery query = new ListarPacotesQuery();
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role);
            if(tipoUsuario.Value.ToString() == EnTipoUsuario.Admin.ToString())
            {
                query.Ativo = true;
            }
            return (GenericQueryResult)handle.Handle(query);

        }

        [HttpGet("{id}")]
        [Authorize]
        public GerencCommandResult GetById(Guid id, [FromServices] BuscarPacotePorIdQuerryHandler handle)
        {
            BuscarPacotesPorId query = new BuscarPacotesPorId();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            query.IdPacote = id;
            query.TipoUsuario = (EnTipoUsuario)Enum.Parse(typeof(EnTipoUsuario), tipoUsuario.Value);

            return (GerencCommandResult)handle.Handle(query);
        }

    }
}
