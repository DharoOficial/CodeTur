using CodeTur.Comum.Querries;
using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Queries.Usuario
{
    public class BuscarUsuarioPorIdQuery : Notifiable, IQuery
    {
        public BuscarUsuarioPorIdQuery()
        {

        }

        public BuscarUsuarioPorIdQuery(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Guid IdUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
            );
        }

    }

    public class BuscarUsuarioPorIdQueryResult
    {
        public BuscarUsuarioPorIdQueryResult()
        {
            Comentarios = new List<Comentario>();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public int QuantidadeComentarios { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
    }

}
