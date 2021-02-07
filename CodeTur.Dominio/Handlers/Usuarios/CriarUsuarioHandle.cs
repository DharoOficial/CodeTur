

using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new GerencCommandResult(false, "informe corretamente os dados", command.Notifications);
            var usarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usarioExiste != null)
                return new GerencCommandResult(false, "Email ja cadastrado, informe outro email", null);

            command.Senha = Senha.Criptografar(command.Senha);
                
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GerencCommandResult(false, "Dados de usuario Invalidos", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            return new GerencCommandResult(true, "Usuario", usuario);

        }

    }
}
