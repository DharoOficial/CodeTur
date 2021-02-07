using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        List<Usuario> _usuarios = new List<Usuario>()
       {
            new Usuario("Erick", "email@email.com", "123456", Comum.Enum.EnTipoUsuario.comun)
       };



        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

                public void Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(x => x.Email == email);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                 new Usuario("Erick", "email@email.com", "123456", Comum.Enum.EnTipoUsuario.comun)
            };
        }
    }
}