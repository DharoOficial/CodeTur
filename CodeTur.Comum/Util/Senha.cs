using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Util
{
    public static class Senha
    {
        public static string Criptografar (string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
        public static bool Validar(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
        public static void Gerar()
        {
            //string caracteres = "";
            //string;
        }
    }
}
