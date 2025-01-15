using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ResultadosConfiguration : IEntityTypeConfiguration<tbl_com_ResultadosEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ResultadosEntities> builder)
    {
        builder.ToTable("tbl_com_Resultados").
        HasKey(p => new { p.ResultadoId });

        builder.Property(p => p.ResultadoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.ProgEvaluacionobj)
        .WithMany(p => p.TBL_com_Resultados)
        .HasForeignKey(p => p.EvaluacionId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(p => p.CriterioId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.NormaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Criterio)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaEva)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.ResEscala)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.BMejoramiento)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.VcObMejoramiento)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.BEstado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.BCerrado)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Color)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.EscalaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Escalanivel)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}
