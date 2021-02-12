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
    public class AlterarImagemPacoteCommand : Notifiable, ICommand
    {
        public AlterarImagemPacoteCommand()
        {

        }

        public AlterarImagemPacoteCommand(Guid idPacote, string imagem)
        {
            IdPacote = idPacote;
            Imagem = imagem;
        }

        public Guid IdPacote { get; set; }
        public string Imagem { get; set; }

        public event EventHandler CanExecuteChanged;

        

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a Imagem do pacote")
                );
        }
    }
}
