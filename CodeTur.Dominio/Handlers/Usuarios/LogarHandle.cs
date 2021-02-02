using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class LogarHandle : IHandler<LogarCommand>
    {
        public ICommandResult Handle(LogarCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
