using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_EscalaEvaluacionConfiguration : IEntityTypeConfiguration<tbl_com_EscalaEvaluacionEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_EscalaEvaluacionEntities> builder)
    {
        builder.ToTable("tbl_com_EscalaEvaluacion").
        HasKey(p => new { p.EscalaId });

        builder.Property(p => p.EscalaId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.TBL_com_EscalaEvaluacion)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Abreviatura)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Escala)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Fondo)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.AspectovaloracionId)
        .IsRequired()
        .HasColumnType("int");
    }
}
