using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_TiposActividadConfiguration : IEntityTypeConfiguration<tbl_com_TiposActividadEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_TiposActividadEntities> builder)
    {
        builder.ToTable("tbl_com_TiposActividad").
        HasKey(p => new { p.InIdTipoActividad });

        builder.Property(p => p.InIdTipoActividad)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.VcTipoActividad)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.BEstado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.InIdCategoria)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");
    }

}
