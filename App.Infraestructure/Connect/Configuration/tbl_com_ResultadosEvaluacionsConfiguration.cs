using App.Infraestructure.Connect.Entities.TblCom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration;

internal class tbl_com_ResultadosEvaluacionsConfiguration : IEntityTypeConfiguration<tbl_com_ResultadosEvaluacionEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ResultadosEvaluacionEntities> builder)
    {
        builder.ToTable("tbl_com_ResultadosEvaluacion").
        HasKey(p => new { p.ResultadoId });

        builder.Property(p => p.ResultadoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.ProgEvaluacionobj)
        .WithMany(p => p.TBL_com_ResultadosEvaluacion)
        .HasForeignKey(p => p.EvaluacionId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Normasobj)
           .WithMany(p => p.TBL_com_ResultadosEvaluacion)
           .HasForeignKey(p => p.NormaId)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Resultado)
        .IsRequired()
        .HasColumnType("double)");

        builder.Property(p => p.Porcentaje)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(e => e.Nivel)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Color)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Observaciones)
        .IsRequired()
        .HasMaxLength(1000)
        .HasColumnType("nvarchar");
    }
}
