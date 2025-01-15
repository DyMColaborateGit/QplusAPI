using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ConsolidadoDesempenoConfiguration : IEntityTypeConfiguration<tbl_com_ConsolidadoDesempenoEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ConsolidadoDesempenoEntities> builder)
    {
        builder.ToTable("tbl_com_ConsolidadoDesempeno").
        HasKey(p => new { p.ConsolidadoId });

        builder.Property(p => p.ConsolidadoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EvaluacionId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipoId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ValorAnalisis)
        .IsRequired()
        .HasColumnType("float");

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

    }
}
