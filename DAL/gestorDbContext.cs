using DAL.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class gestorDbContext : DbContext
    {
        public gestorDbContext()
        {
        }

        public gestorDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=exaDos;User Id =postgres; Password =1234; SearchPath = public");
        }

      
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<RelElementoReservas> RelElementosReservas { get; set; }
    }
}
