using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Dtos;
 

namespace DataAccess
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        
        public DbSet<Parametro> Parametro { get; set; }  
       
        public DbSet<Articulo> Articulo { get; set; }   
        public DbSet<MovimientoDeStock> MovimientoDeStock { get; set; }
        public DbSet<TipoDeMovimiento> TipoDeMovimiento { get; set; }

        

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetPrecisionForDecimal(modelBuilder);

            modelBuilder.Entity<Parametro>(p => p.HasKey(p => p.Clave));

         

            modelBuilder.Entity<MovimientoDeStock>(entity =>
            {
                entity.HasOne(e => e.Articulo)
                      .WithMany()
                      .HasForeignKey(e => e.ArticuloId);


                entity.HasOne(e => e.TipoDeMovimiento)
                      .WithMany()
                      .HasForeignKey(e => e.TipoDeMovimientoId);


                entity.HasOne(e => e.Empleado)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId);
            });



            

            base.OnModelCreating(modelBuilder);
        }

        private void SetPrecisionForDecimal(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(12);
                property.SetScale(2);
            }
        }
    }
}
