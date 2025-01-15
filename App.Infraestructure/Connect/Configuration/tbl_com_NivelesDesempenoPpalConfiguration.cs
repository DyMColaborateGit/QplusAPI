using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_NivelesDesempenoPpalConfiguration : IEntityTypeConfiguration<tbl_com_NivelesDesempenoPpalEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_NivelesDesempenoPpalEntities> builder)
    {
        builder.ToTable("tbl_com_NivelesDesempenoPpal").
        HasKey(p => new { p.IdNivel });

        builder.Property(p => p.IdNivel)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ConceptoFinal)
        .IsRequired()
        .HasMaxLength(4000)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UbicacionMD)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InAnio)
        .IsRequired()
        .HasColumnType("int");
    }
}
