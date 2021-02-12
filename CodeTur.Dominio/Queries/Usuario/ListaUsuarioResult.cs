using CodeTur.Comum.Querries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Queries.Usuario
{
    public class ListaUsuarioResult : IQuery
    {
        public void Validar()
        {

        }
    }
        
    public class ListarQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public int QuantidadeComentarios { get; set; }
    }
}
