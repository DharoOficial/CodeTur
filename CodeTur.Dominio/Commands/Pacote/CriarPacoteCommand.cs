using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class CriarPacoteCommand : Notifiable, ICommand
    {
        public CriarPacoteCommand()
        {

        }
        public CriarPacoteCommand(string titulo, string descricao, string imagem, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
        }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o titulo do pacote")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a Descricao do pacote")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a Imagem do pacote")
                );
        }
    }
}
