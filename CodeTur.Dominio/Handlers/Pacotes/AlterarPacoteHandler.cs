using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarPacoteHandler
    {
        private readonly IPacotesRespositorio _respositorio;

        public AlterarPacoteHandler(IPacotesRespositorio respositorio)
        {
            _respositorio = respositorio;
        }

        public ICommandResult Handler(AlterarPacoteCommand command)
        {

            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(false, "dados invalidos ", command.Notifications);

            var pacote = _respositorio.BuscarPorId(command.IdPacote);

            if (pacote == null)
                return new GerencCommandResult(false, "Pacote não encontrado", null);

            var pacoteExiste = _respositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteExiste != null)
                return new GerencCommandResult(false, "Pacote já caastrado", null);

            pacote.AlterarPacote(command.Titulo, command.Descricao);

            if (pacote.Invalid)
                return new GerencCommandResult(false, "Dados Invalidos", pacote.Notifications);
            _respositorio.Alterar(pacote);

            return new GerencCommandResult(true, "Pacote Alterado", null);
        }

    }
}
