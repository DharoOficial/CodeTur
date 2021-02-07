using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Querries;
using CodeTur.Dominio.Queries.Pacote;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class ListarPacoteQueryHandlers : IHandlerQuery<ListarPacotesQuery>
    {
        private readonly IPacotesRespositorio _pacotesRespositorio;

        public ListarPacoteQueryHandlers(IPacotesRespositorio pacotesRespositorio)
        {
            _pacotesRespositorio = pacotesRespositorio;
        }

        public IQueryResult Handler(ListarPacotesQuery query)
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
                        DataCriacao = x.DataCriacao,
                        QuantidadeComentario = x.Comentarios.Count

                    };
                }
            );

            return new GenericQueryResult(true, "Pacotes", retornoPacotes);
        }
    }
}
