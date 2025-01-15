using App.Infraestructure.Connect.Entities.TblAud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App.Infraestructure.Connect.Configuration.TblAud
{
    public class tbl_aud_EvaPreguntasConfiguration : IEntityTypeConfiguration<tbl_aud_EvaPreguntasEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_aud_EvaPreguntasEntities> builder)
        {
            builder.ToTable("tbl_aud_EvaPreguntas").
            HasKey(p => new { p.IdEvaPregunta });

            builder.Property(p => p.IdEvaPregunta)
               .ValueGeneratedOnAdd()
               .IsRequired()
               .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.IdPregunta)
                .HasColumnType("int");

            builder.Property(p => p.IdEvaluacion)
                .HasColumnType("int");

            builder.Property(p => p.Calificacion)
                .HasColumnType("int");

            builder.Property(p => p.TextPregunta)
                .HasColumnName("Text_Pregunta")
                .HasMaxLength(4000)
                .HasColumnType("varchar");

        }
    }
}
