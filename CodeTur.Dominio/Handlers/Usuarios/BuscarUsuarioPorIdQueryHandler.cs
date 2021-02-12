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
    public class BuscarUsuarioPorIdQueryHandler : IHandlerQuery<BuscarUsuarioPorIdQuery>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public BuscarUsuarioPorIdQueryHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio; 
        }

        public ICommandResult Handle(BuscarUsuarioPorIdQuery query)
        {
            var usuario = _repositorio.BuscarPorId(query.IdUsuario);

            var retornar = new BuscarUsuarioPorIdQueryResult()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                QuantidadeComentarios = usuario.Comentarios.Count,
                Comentarios = usuario.Comentarios.ToList()
            };

            return new GerencCommandResult(true, "Dados do usuário", retornar);
        }
    }
}
