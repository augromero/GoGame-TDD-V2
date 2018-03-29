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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.Entity<Punto>().ToTable("Puntos");

        }
    }
}