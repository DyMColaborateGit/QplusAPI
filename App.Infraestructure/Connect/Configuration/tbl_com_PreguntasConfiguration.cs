using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_PreguntasConfiguration : IEntityTypeConfiguration<tbl_com_PreguntasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_PreguntasEntities> builder)
    {
        builder.ToTable("tbl_com_Preguntas").
        HasKey(p => new { p.IdPregunta });

        builder.Property(p => p.IdPregunta)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Pregunta)
        .IsRequired(false)
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");
    }
    
}
