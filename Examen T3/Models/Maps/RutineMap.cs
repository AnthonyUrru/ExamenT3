using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.Maps
{
    public class RutineMap : IEntityTypeConfiguration<Rutine>
    {
        public void Configure(EntityTypeBuilder<Rutine> builder)
        {
            builder.ToTable("Rutine");
            builder.HasKey(o => o.Id);

           
        }
    }
}
