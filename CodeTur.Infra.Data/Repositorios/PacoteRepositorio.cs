using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Repositorios
{
    public class PacoteRepositorio : IPacotesRespositorio
    {
        private readonly CodeTurContext _context;
        public PacoteRepositorio(CodeTurContext context)
        {
            _context = context;
        }

        public void Adicionar(Pacote pacote)
        {
            _context.Pacotes.Add(pacote);
            _context.SaveChanges();
        }

        public void Alterar(Pacote pacote)
        {
            _context.Entry(pacote).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Pacote BuscarPorId(Guid id)
        {
            return _context.Pacotes.FirstOrDefault(x => x.Id == id);
        }

        public Pacote BuscarPorTitulo(string titulo)
        {
            return _context.Pacotes.FirstOrDefault(x => x.Titulo == titulo);
        }

        public ICollection<Pacote> Listar(bool? ativo = null)
        {
            if(ativo == null)
                return _context.Pacotes
                                   .AsNoTracking()
                                   .Include(x => x.Comentarios)
                                   .OrderBy(z => z.DataCriacao)
                                   .ToList();
            else
                return _context.Pacotes
                              .AsNoTracking()
                              .Include(x => x.Comentarios)
                              .OrderBy(z => z.DataCriacao)
                              .Where(a => a.Ativo == ativo)
                              .ToList();
        }
    }
}
