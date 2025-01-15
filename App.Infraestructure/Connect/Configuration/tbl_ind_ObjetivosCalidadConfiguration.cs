using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_ObjetivosCalidadConfiguration : IEntityTypeConfiguration<tbl_ind_ObjetivosCalidadEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_ObjetivosCalidadEntities> builder)
    {
        builder.ToTable("tbl_ind_ObjetivosCalidad").
        HasKey(p => new { p.InIdTipoObjetivo });

        builder.Property(p => p.InIdTipoObjetivo)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.VcObjetivo)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.VcIndicador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Perspectiva)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

    }
}
