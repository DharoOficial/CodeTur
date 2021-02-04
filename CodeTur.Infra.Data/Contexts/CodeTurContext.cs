using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Infra.Data.Contexts
{
    public class CodeTurContext : DbContext
    {
        public CodeTurContext(DbContextOptions<CodeTurContext> options):
            base (options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            #region Mapeamento Tabela Usuario
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            modelBuilder.Entity<Usuario>().HasMany(c => c.Comentarios).WithOne(u => u.Usuario).HasForeignKey(fk => fk.IdUsuario);

            modelBuilder.Entity<Usuario>().Property(x => x.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            #endregion
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();
            #region
            modelBuilder.Entity<Pacote>().ToTable("Pacote");
            modelBuilder.Entity<Pacote>().Property(p => p.Titulo).HasMaxLength(50);
            modelBuilder.Entity<Pacote>().Property(p => p.Titulo).HasColumnType("Varchar(50)");
            modelBuilder.Entity<Pacote>().Property(p => p.Titulo).IsRequired();

            modelBuilder.Entity<Pacote>().ToTable("Pacote");
            modelBuilder.Entity<Pacote>().Property(p => p.Descricao).HasMaxLength(500);
            modelBuilder.Entity<Pacote>().Property(p => p.Descricao).HasColumnType("Varchar(500)");
            modelBuilder.Entity<Pacote>().Property(p => p.Descricao).IsRequired();

            modelBuilder.Entity<Pacote>().ToTable("Pacote");
            modelBuilder.Entity<Pacote>().Property(p => p.Imagem).HasMaxLength(500);
            modelBuilder.Entity<Pacote>().Property(p => p.Imagem).HasColumnType("Varchar(500)");

            #endregion
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();
            #region
            modelBuilder.Entity<Comentario>().ToTable("Pacote");
            modelBuilder.Entity<Comentario>().Property(p => p.Texto).HasMaxLength(1000);
            modelBuilder.Entity<Comentario>().Property(p => p.Texto).HasColumnType("Varchar(1000)");
            modelBuilder.Entity<Comentario>().Property(p => p.Texto).IsRequired();

            modelBuilder.Entity<Comentario>().ToTable("Pacote");
            modelBuilder.Entity<Comentario>().Property(p => p.Sentimento).HasMaxLength(50);
            modelBuilder.Entity<Comentario>().Property(p => p.Sentimento).HasColumnType("Varchar(50)");
            modelBuilder.Entity<Comentario>().Property(p => p.Sentimento).IsRequired();

            modelBuilder.Entity<Comentario>().ToTable("Pacote");
            modelBuilder.Entity<Comentario>().Property(p => p.Status).HasColumnType("BOOL");
            modelBuilder.Entity<Comentario>().Property(p => p.Status).IsRequired();

            modelBuilder.Entity<Comentario>().HasOne(c => c.Usuario).WithMany(u => u.Comentarios).HasForeignKey(fk => fk.IdUsuario);

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
