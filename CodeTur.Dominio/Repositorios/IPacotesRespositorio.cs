using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Repositorios
{
    public interface IPacotesRespositorio
    {
        void Adicionar(Pacote pacote);
        void Alterar(Pacote pacote);
        Pacote BuscarPorId(Guid id);
        Pacote BuscarPorTitulo(string titulo);
        ICollection<Pacote> Listar(bool? ativo = null);
    }
}
