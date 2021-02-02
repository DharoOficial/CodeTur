using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuarios
{
    public class CriarUsuarioHandlerTeste
    {
        [Fact]
        public void DeveRetornarErroCasoOsDadosDoHandleSejamInvalidos()
        {
            var command = new CriarUsuarioCommand();
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            var resultado = (GerencCommandResult)handle.Handle(command);
            Assert.False(resultado.Sucesso, "Usuario válido");
        }

        [Fact]
        public void DeveRetornarSucessoCasoOsDadosDoHandleSejamValidos()
        {
            var command = new CriarUsuarioCommand("Erick","email@email.com","123456","", Comum.Enum.EnTipoUsuario.comun);
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            var resultado = (GerencCommandResult)handle.Handle(command);
            Assert.False(resultado.Sucesso, "Usuario válido");
        }
    }
}
