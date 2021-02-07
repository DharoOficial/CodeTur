using CodeTur.Comum.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Queries.Pacote
{
    public class ListarPacotesQuery : IQuery
    {

        public bool? Ativo { get; set; } = null; 

        public void Validar()
        {

        }
    }

    public class ListarPacotesResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool  Ativo { get; set; }
        public int QuantidadeComentario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
