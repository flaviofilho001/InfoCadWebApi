using InfoCad.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InfoCad.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Evento>? Eventos { get; set; }
        public DbSet<Noticia>? Noticias { get; set; }
        public DbSet<Notificacao>? Notificacaos { get; set; }


    }
}
