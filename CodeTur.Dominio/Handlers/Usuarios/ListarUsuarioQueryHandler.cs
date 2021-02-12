using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Queries.Usuario;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class ListarUsuarioQueryHandler : IHandlerQuery<ListaUsuarioResult>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public ListarUsuarioQueryHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(ListaUsuarioResult query)
        {
            var query1 = _repositorio.Listar();

            var usuarios = query1.Select(
                x =>
                {
                    return new ListarQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        Telefone = x.Telefone,
                        TipoUsuario = x.TipoUsuario.ToString(),
                        QuantidadeComentarios = x.Comentarios.Count
                    };
                }

            );

            return new GerencCommandResult(true, "Usuários", usuarios);
        }
    }
}