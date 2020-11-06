using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.Maps
{
    public class EjercicioMap : IEntityTypeConfiguration<Ejercicio>
    {
        public void Configure(EntityTypeBuilder<Ejercicio> builder)
        {
            builder.ToTable("Ejercicios");
            builder.HasKey(o => o.Id);
        }
    }
}
