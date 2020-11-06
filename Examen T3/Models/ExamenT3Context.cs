using Examen_T3.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models
{
    public class ExamenT3Context : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Rutine> Rutines { get; set; }
        public DbSet<EjercicioRutine> EjercicioRutines { get; set; }
        public ExamenT3Context(DbContextOptions<ExamenT3Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new RutineMap());
            modelBuilder.ApplyConfiguration(new EjercicioRutineMap());
            
        }
        
    }
}
