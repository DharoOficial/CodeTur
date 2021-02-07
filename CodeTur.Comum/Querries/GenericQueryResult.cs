using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum.Querries
{
    public class GenericQueryResult : IQueryResult
    {
        public GenericQueryResult(bool sucesso, string mensagem, Object data)
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
