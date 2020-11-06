using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.Maps
{
    public class EjercicioRutineMap : IEntityTypeConfiguration<EjercicioRutine>
    {
        public void Configure(EntityTypeBuilder<EjercicioRutine> builder)
        {

            builder.ToTable("EjercicioR");
            builder.HasKey(o => o.Id);

        }
    }
}
