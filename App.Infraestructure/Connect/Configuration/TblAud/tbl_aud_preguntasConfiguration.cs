using App.Infraestructure.Connect.Entities.TblAud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration.TblAud
{
    public class tbl_aud_preguntasConfiguration : IEntityTypeConfiguration<tbl_aud_preguntasEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_aud_preguntasEntities> builder)
        {
            builder.ToTable("tbl_aud_preguntas").
            HasKey(p => new { p.IdPregunta });

            builder.Property(p => p.IdPregunta)
               .ValueGeneratedOnAdd()
               .IsRequired()
               .HasColumnType("int");

            builder.Property(p =>p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.PreguntaTexto)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");

        }
    }
}
