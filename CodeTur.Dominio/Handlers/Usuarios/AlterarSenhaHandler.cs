using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
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
    public class AlterarSenhaHandler : Notifiable, IHandlerCommand<AlterarSenha>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public AlterarSenhaHandler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(AlterarSenha command)
        {
            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(false, "Senha inválida", command.Notifications);

            var usuarioexiste = _repositorio.BuscarPorId(command.IdUsuario);

            if (usuarioexiste == null)
                return new GerencCommandResult(false, "Usuário não encontrado", command.Notifications);

            command.Senha = Senha.Criptografar(command.Senha);
            usuarioexiste.AlterarSenha(command.Senha);

            _repositorio.Alterar(usuarioexiste);

            return new GerencCommandResult(true, "Senha Alterada", null);
        }
    }
}
