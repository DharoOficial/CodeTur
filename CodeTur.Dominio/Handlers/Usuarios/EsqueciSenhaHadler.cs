using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class EsqueciSenhaHadler : Notifiable, IHandlerCommand<EsqueciSenhaCommadn>
    {
        private readonly IUsuarioRepositorio _repositorio;
        public EsqueciSenhaHadler(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(EsqueciSenhaCommadn command)
        {
            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", command.Notifications);

            var usuario = _repositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GerencCommandResult(false, "Email inválido", null);

            string senha = Senha.Gerar();

            usuario.AlterarSenha(Senha.Criptografar(senha));

            if (usuario.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", usuario.Notifications);

            _repositorio.Alterar(usuario);

            return new GerencCommandResult(true, "Uma nova senha foi criada e enviada para o seu e-mail, verifique!!!", null);
        }
    }
}
