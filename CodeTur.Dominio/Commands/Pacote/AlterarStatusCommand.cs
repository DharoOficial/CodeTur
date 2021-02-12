using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class AlterarStatusCommand : Notifiable, ICommand
    {
        public AlterarStatusCommand()
        {

        }

        public AlterarStatusCommand(Guid idPacote, bool status)
        {
            IdPacote = idPacote;
            Status = status;
        }

        public Guid IdPacote { get; set; }
        public bool Status { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdPacote, Guid.Empty, "IdUsuario", "Id do usuário inválido")
           );
        }
    }
}
