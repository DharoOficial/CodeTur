using CodeTur.Comum.Entidades;
using CodeTur.Comum.Enum;
using Flunt.Validations;

namespace CodeTur.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            AddNotifications ( new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve ter no minimo 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no maximo 40 caracteres")
                .IsEmail(email,"Email", "Informe um email valido")
                .HasMinLen(senha, 3, "Senha", "A senha deve ter no minimo 6 caracteres")
                .HasMaxLen(senha, 40, "Senha", "A senha deve ter no maximo 12 caracteres")
                );

            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
    }
}
