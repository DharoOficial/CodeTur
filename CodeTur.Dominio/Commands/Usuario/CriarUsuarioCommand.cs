using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        public CriarUsuarioCommand()
        {

        }

        public CriarUsuarioCommand(string nome, string email, string senha, string telefone, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            TipoUsuario = tipoUsuario;
        }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome" , "O nome deve ter no minimo 3 linhas")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no minimo 3 linhas")
                .IsEmail(Email, "Email", "Informe um email valido")
                .HasMinLen(Senha, 6, "Senha", "A Senha deve ter no minimo 3 linhas")
                .HasMaxLen(Senha, 12, "Senha", "A Senha deve ter no minimo 3 linhas")
                );
        }
    }
}
