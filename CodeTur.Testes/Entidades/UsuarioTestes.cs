using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetorarErroSeUsuarioInvalido()
        {
            var usuario = new Usuario("Erick", "erickdharobandeira@gmail.com", "123456", Comum.Enum.EnTipoUsuario.comun);
            Assert.True(usuario.Invalid, "usuario é valido");
        }

        [Fact]
        public void DeveRetorarSucessoSeUsuarioInvalido()
        {
            var usuario = new Usuario("Erick", "erickdharobandeira@gmail.com", "123456", Comum.Enum.EnTipoUsuario.comun);
            Assert.True(usuario.Invalid, "usuario é valido");
        }
    }
}
