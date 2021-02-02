using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Commands
{
    public class GerencCommandResult : ICommandResult
    {
        public GerencCommandResult(bool sucesso, string mensagem, Object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public Object Data { get; set; }

        
    }
}
