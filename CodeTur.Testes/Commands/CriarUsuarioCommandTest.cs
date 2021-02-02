using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CriarUsuarioCommandTest
    {
        [Fact]
        public void DeveRetornarErroSeDadosInvalidos()
        {
            var command = new CriarUsuarioCommand();
            command.Validar();
            Assert.True(command.Valid, "Os Dados estão preenchidos corretamente");
        }
        [Fact]
        public void DeveRetornarErroSeDadosValidos()
        {
            var command = new CriarUsuarioCommand("Erick","email@email.com","123456","",Comum.Enum.EnTipoUsuario.comun);
            command.Validar();
            Assert.True(command.Valid, "Os Dados estão preenchidos corretamente");
        }
    }
}
