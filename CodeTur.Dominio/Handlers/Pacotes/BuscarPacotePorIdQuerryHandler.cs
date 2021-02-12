using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Querries;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Queries.Pacote;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class BuscarPacotePorIdQuerryHandler : IHandlerQuery<BuscarPacotesPorId>
    {
        private readonly IPacotesRespositorio _repositorio;

        public BuscarPacotePorIdQuerryHandler(IPacotesRespositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(BuscarPacotesPorId query)
        {
            var pacote = _repositorio.BuscarPorId(query.IdPacote);

            if (pacote == null)
                return new GerencCommandResult(false, "Pacote não encontrado", null);

            var retorno = new BuscarPacotePorIdQueryResult()
            {
                Id = pacote.Id,
                Titulo = pacote.Titulo,
                Descricao = pacote.Descricao,
                Ativo = pacote.Ativo,
                QuantidadeComentarios = pacote.Comentarios.Count,
                Comentarios = (query.TipoUsuario == EnTipoUsuario.Admin ? GerarResultadoComentarios(pacote.Comentarios.ToList()) : GerarResultadoComentarios(pacote.Comentarios.Where(x => x.Status == EnStatusComentario.Publicado).ToList()))
            };

            return new GerencCommandResult(true, "Dados do pacote", retorno);
        }

        private List<ComentarioResult> GerarResultadoComentarios(List<Comentario> comentarios)
        {
            return comentarios.Select(c =>
            {
                return new ComentarioResult()
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Sentimento = c.Sentimento,
                    Status = c.Status.ToString(),
                    IdUsuario = c.IdUsuario,
                    IdPacote = c.IdPacote
                };
            }).ToList();
        }

    }
}
