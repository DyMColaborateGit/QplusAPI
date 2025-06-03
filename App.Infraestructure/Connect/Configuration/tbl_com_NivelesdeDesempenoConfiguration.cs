using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_NivelesdeDesempenoConfiguration : IEntityTypeConfiguration<tbl_com_NivelesdeDesempenoEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_NivelesdeDesempenoEntities> builder)
    {
        builder.ToTable("tbl_com_NivelesdeDesempeno").
        HasKey(p => new { p.Id_Nivel });

        builder.Property(p => p.Id_Nivel)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ComceptoFinal)
        .IsRequired()
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PorcMnin)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.PorcMax)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NivelCompetencia)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.UbicacionMD)
       .IsRequired()
       .HasColumnType("int");

    }
}
