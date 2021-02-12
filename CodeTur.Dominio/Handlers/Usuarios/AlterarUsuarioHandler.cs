using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class AlterarUsuarioHandler : Notifiable, IHandlerCommand<AlterarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public AlterarUsuarioHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(AlterarUsuarioCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", command.Notifications);

            var usuario = _repositorio.BuscarPorId(command.IdUsuario);

            if (usuario == null)
                return new GerencCommandResult(false, "Usuário não encontrado", null);


            if (usuario.Email != command.Email)
            {
                var emailExiste = _repositorio.BuscarPorEmail(command.Email);

                if (emailExiste != null)
                    return new GerencCommandResult(false, "Email já cadastrado", null);
            }

            usuario.AlterarUsuario(command.Nome, command.Email);


            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AlterarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", usuario.Notifications);

            _repositorio.Alterar(usuario);

            return new GerencCommandResult(true, "Conta alterada com Sucesso", null);
        }
    }
}
