using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ActividadesPIDConfiguration : IEntityTypeConfiguration<tbl_com_ActividadesPIDEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ActividadesPIDEntities> builder)
    {
        builder.ToTable("tbl_com_ActividadesPID").
        HasKey(p => new { p.InIdActividadPID });

        builder.Property(p => p.InIdActividadPID)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EvaluadoId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.InIdEvaluacion)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdTipoActividad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.VcActividad)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.DtFechaInicial)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.DtFechaFinal)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.DtFechaReal)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(e => e.VcLugar)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.VcObMejoramiento)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.BEstado)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.BCapacitacion)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.InIdFuente)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InAnio)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CategoriaPDI)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.AutoDesarrollo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.TipoActividadOtro)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Analisis)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}