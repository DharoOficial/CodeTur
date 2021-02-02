using CodeTur.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
