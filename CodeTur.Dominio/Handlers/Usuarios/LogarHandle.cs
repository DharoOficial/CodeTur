using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class LogarHandle : IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _repositorio;
        public LogarHandle(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;

        }
        public ICommandResult Handle(LogarCommand command)
        {
            command.Validar();

            if(command.Invalid)
                return new GerencCommandResult(false, "Dados Invalidos", command.Notifications);

            var usuario = _repositorio.BuscarPorEmail(command.Email);

            if(usuario == null)
                return new GerencCommandResult(false, "Email Invalido", null);

            if(!Senha.Validar(command.Senha, usuario.Senha))
                return new GerencCommandResult(false, "Senha Invalida", null);

            return new GerencCommandResult(true, "Usuario Logado", null);

        }
    }
}
