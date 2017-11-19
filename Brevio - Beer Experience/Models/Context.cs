using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    public class Context: DbContext
    {
        public DbSet<Cerveja> Cervejas { get; set; }
        public DbSet<Cervejaria> Cervejarias { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Familia> Famlias { get; set; }
        public DbSet<Preco> Precos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}