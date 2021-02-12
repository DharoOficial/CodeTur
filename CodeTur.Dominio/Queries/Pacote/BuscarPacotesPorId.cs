using CodeTur.Comum.Enum;
using CodeTur.Comum.Querries;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Queries.Pacote
{
    public class BuscarPacotesPorId : Notifiable, IQuery
    {
        public BuscarPacotesPorId()
        {

        }

        public BuscarPacotesPorId(Guid idPacote, EnTipoUsuario tipoUsuario)
        {
            IdPacote = idPacote;
            TipoUsuario = tipoUsuario;
        }

        public Guid IdPacote { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote")
            );
        }

    }

    public class BuscarPacotePorIdQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeComentarios { get; set; }
        public ICollection<ComentarioResult> Comentarios { get; set; }
    }

    public class ComentarioResult
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public string Sentimento { get; set; }
        public string Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPacote { get; set; }
    }

}
