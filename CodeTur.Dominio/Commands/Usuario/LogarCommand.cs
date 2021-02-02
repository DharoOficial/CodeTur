using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class LogarCommand : Notifiable, ICommand
    {
        public string Senha { get; set; }
        public string Email { get; set; }
        public LogarCommand (string senha, string email)
        {
            Senha = senha;
            Email = email;
        }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um email valido")
                .HasMinLen(Senha, 6, "Senha", "A Senha deve ter no minimo 3 linhas")
                .HasMaxLen(Senha, 12, "Senha", "A Senha deve ter no minimo 3 linhas")
                );
        }
    }
}
