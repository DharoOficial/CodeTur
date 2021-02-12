using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Queries.Pacote;
using CodeTur.Dominio.Repositorios;
using System.Linq;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class ListarPacoteQueryHandlers : IHandlerQuery<ListarPacotesQuery>
    {
        private readonly IPacotesRespositorio _pacotesRespositorio;

        public ListarPacoteQueryHandlers(IPacotesRespositorio pacotesRespositorio)
        {
            _pacotesRespositorio = pacotesRespositorio;
        }

        public ICommandResult Handle(ListarPacotesQuery query)
        {
            var pacotes = _pacotesRespositorio.Listar(query.Ativo);

            var retornoPacotes = pacotes.Select
            (
                x =>
                {
                    return new ListarPacotesResult()
                    {
                        Id = x.Id,
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        Ativo = x.Ativo,
                        QuantidadeComentario = x.Comentarios.Count
                    };
                }
            );

            return new GerencCommandResult(true, "Pacotes", retornoPacotes);
        }
    }
}
