using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ActividadesCompetenciasConfiguraction : IEntityTypeConfiguration<tbl_com_ActividadesCompetenciasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ActividadesCompetenciasEntities> builder)
    {
        builder.ToTable("tbl_com_ActividadesCompetencias").
        HasKey(p => new { p.RelacionId });

        builder.Property(p => p.RelacionId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ActividadId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodNorma)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}