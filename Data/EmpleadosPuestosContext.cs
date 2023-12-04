using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class EmpleadosPuestosContext : IdentityDbContext
    {
        public EmpleadosPuestosContext (DbContextOptions<EmpleadosPuestosContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto.Models.Empleado> Empleados { get; set; } = default!;
        public DbSet<Proyecto.Models.Puesto> Puestos { get; set; } = default!;
        public DbSet<Proyecto.Models.Sector> Sector { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<Puesto>()
                   .HasOne(e => e.Sector)
                   .WithMany(e => e.Puestos)
                   .IsRequired(false);
            
               base.OnModelCreating(modelBuilder);
        }
    }
}
