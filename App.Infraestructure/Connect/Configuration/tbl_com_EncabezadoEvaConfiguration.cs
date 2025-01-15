using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_EncabezadoEvaConfiguration : IEntityTypeConfiguration<tbl_com_EncabezadoEvaEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_EncabezadoEvaEntities> builder)
    {
        builder.ToTable("tbl_com_EncabezadoEva").
        HasKey(p => new { p.EncabezadoId });

        builder.Property(e => e.EncabezadoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.ProgEvaluacionobj)
           .WithMany(p => p.TBL_com_EncabezadoEva)
           .HasForeignKey(p => p.InIdEbaluacion)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.Periodo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Identificacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Oficina)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Zona)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.VcNombre)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Proceso)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Motivo)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Texto)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.TextoIndi)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}
