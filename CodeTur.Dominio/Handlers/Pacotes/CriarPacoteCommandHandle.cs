using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class CriarPacoteCommandHandle : IHandlerCommand<CriarPacoteCommand>
    {
        private readonly IPacotesRespositorio _pacotesRespositorio;

        public CriarPacoteCommandHandle(IPacotesRespositorio pacotesRespositorio)
        {
            _pacotesRespositorio = pacotesRespositorio;
        }
        public ICommandResult Handle(CriarPacoteCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(true, "Dados invalidos", command.Notifications);

            var pacoteExistete = _pacotesRespositorio.BuscarPorTitulo(command.Titulo); 

            if(pacoteExistete != null)
                return new GerencCommandResult(true, "Titulo do Pacote ja cadastrado", null);

            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if(pacote.Invalid)
                return new GerencCommandResult(true, "Dados invalidos", command.Notifications);

            return new GerencCommandResult(true, "Pacote Criado", pacote);
        }
    }
}
