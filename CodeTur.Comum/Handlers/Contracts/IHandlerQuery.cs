﻿using CodeTur.Comum.Commands;
using CodeTur.Comum.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum.Handlers.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        ICommandResult Handle(T query); 
    }
}
