using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Util
{
    public static class Senha
    {
        public static string CriptografarSenha (string senha)
        {
            return senha + senha;
        }
    }
}
