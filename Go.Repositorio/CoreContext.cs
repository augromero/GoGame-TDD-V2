using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Go.Entidades;
using Microsoft.EntityFrameworkCore.Storage;

namespace Go.Repositorio
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        { }

        public DbSet<Punto> Puntos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(builder);

            modelBuilder.Entity<Punto>().ToTable("Puntos");
            modelBuilder.Entity<Jugador>().ToTable("Jugadores");
            modelBuilder.Entity<Partida>().ToTable("Partidas");
            modelBuilder.Entity<Movimiento>().ToTable("Movimientos")
                        .HasKey(llave => new { llave.PartidaId, llave.OrdenMovimiento });
            

        }
    }
}