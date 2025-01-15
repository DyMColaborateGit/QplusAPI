using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_NivelesCompetenciasConfiguration : IEntityTypeConfiguration<tbl_com_NivelesCompetenciasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_NivelesCompetenciasEntities> builder)
    {
        builder.ToTable("tbl_com_NivelesCompetencias").
        HasKey(p => new { p.NivelId });

        builder.Property(p => p.NivelId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipoId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ValorMinComp)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.ValorMaxComp)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.ValorMinInd)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.ValorMaxInd)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.Calificacion)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.MinDesempeno)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.MaxDesempeno)
        .IsRequired()
        .HasColumnType("double");
    }
}
