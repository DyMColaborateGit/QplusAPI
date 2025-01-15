using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ResultadoEvaluacionadaConfiguration : IEntityTypeConfiguration<tbl_com_ResultadoEvaluacionADAEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ResultadoEvaluacionADAEntities> builder)
    {
        builder.ToTable("tbl_com_ResultadoEvaluacionADA").
        HasKey(p => new { p.IdResultado });

        builder.Property(p => p.IdResultado)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdEvaluacion)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.IdPadre)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.IdHijo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TextoPregunta)
        .IsRequired()
        .HasMaxLength(1050)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TextoRespuesta)
        .IsRequired()
        .HasMaxLength(1050)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ResultadoTxt)
        .IsRequired()
        .HasMaxLength(1050)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Resultado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.Tipo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.Orden)
        .IsRequired(false)
        .HasColumnType("int");

    }

}
