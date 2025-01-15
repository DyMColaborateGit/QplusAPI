using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_Ind_ResulDirectorGerentesConfiguration : IEntityTypeConfiguration<tbl_Ind_ResulDirectorGerentesEntities>
{
    public void Configure(EntityTypeBuilder<tbl_Ind_ResulDirectorGerentesEntities> builder)
    {
        builder.ToTable("tbl_Ind_ResulDirectorGerentes").
        HasKey(p => new { p.Resultadoid });

        builder.Property(p => p.Resultadoid)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Anio)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Mesini)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Mesfin)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Identificacion)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.Resultado)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Tipo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}

