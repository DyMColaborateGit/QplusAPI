using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ResultadosEvaIndicadoresConfiguration : IEntityTypeConfiguration<tbl_com_ResultadosEvaIndicadoresEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ResultadosEvaIndicadoresEntities> builder)
    {
        builder.ToTable("tbl_com_ResultadosEvaIndicadores").
        HasKey(p => new { p.ResultadoId });

        builder.Property(p => p.ResultadoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.ProgEvaluacionobj)
        .WithMany(p => p.TBL_com_ResultadosEvaIndicadores)
        .HasForeignKey(p => p.EvaluacionId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.MastIndicadoresobj)
        .WithMany(p => p.TBL_com_ResultadosEvaIndicadores)
        .HasForeignKey(p => p.IndcadorId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.Indicador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Fecha)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.Peso)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Meta)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Real)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Ponderado)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Cumple)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Color)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PesoNext)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Editar)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.TipoIndi)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.EnablePeso)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.EnableCalificacion)
        .IsRequired(false)
        .HasColumnType("bit");
    }
}
