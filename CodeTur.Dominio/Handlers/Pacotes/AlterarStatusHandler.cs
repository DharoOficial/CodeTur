﻿using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class AlterarStatusHandler
    {

        private readonly IPacotesRespositorio _repositorio;

        public AlterarStatusHandler(IPacotesRespositorio respositorio)
        {
            _repositorio = respositorio;
        }
        public ICommandResult Handle(AlterarStatusCommand command)
        {

            command.Validar();

            if (command.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", command.Notifications);

            var pacote = _repositorio.BuscarPorId(command.IdPacote);

            if (pacote == null) 
                return new GerencCommandResult(false, "Pacote não encontrado", null);

            pacote.AlterarStatus(command.Status);

            if (pacote.Invalid)
                return new GerencCommandResult(false, "Dados inválidos", pacote.Notifications);

            _repositorio.Alterar(pacote);

            return new GerencCommandResult(true, "Imagem alterado", null);
        }

    }
}
