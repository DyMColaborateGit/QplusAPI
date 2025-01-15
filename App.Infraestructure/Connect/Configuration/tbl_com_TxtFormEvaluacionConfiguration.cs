using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_TxtFormEvaluacionConfiguration : IEntityTypeConfiguration<tbl_com_TxtFormEvaluacionEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_TxtFormEvaluacionEntities> builder)
    {
        builder.ToTable("tbl_com_TxtFormEvaluacion").
        HasKey(p => new { p.TextoId });

        builder.Property(p => p.TextoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.TBL_com_TxtFormEvaluacion)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Titulo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Texto)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Tipotxt)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Anio)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipovaloracionId)
        .IsRequired()
        .HasColumnType("int");
    }
}