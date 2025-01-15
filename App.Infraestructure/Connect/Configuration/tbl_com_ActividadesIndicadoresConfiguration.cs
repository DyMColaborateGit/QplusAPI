using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ActividadesIndicadoresConfiguration: IEntityTypeConfiguration<tbl_com_ActividadesIndicadoresEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ActividadesIndicadoresEntities> builder)
    {
        builder.ToTable("tbl_com_ActividadesIndicadores").
        HasKey(p => new { p.RelacionId });

        builder.Property(p => p.RelacionId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ActividadId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IndicadorId)
        .IsRequired()
        .HasColumnType("int");
    }
}
