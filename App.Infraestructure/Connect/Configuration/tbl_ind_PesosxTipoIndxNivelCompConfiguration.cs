using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_PesosxTipoIndxNivelCompConfiguration : IEntityTypeConfiguration<tbl_ind_PesosxTipoIndxNivelCompEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_PesosxTipoIndxNivelCompEntities> builder)
    {
        builder.ToTable("tbl_ind_PesosxTipoIndxNivelComp").
        HasKey(p => new { p.IdPesosIndiNivel });

        builder.Property(p => p.IdPesosIndiNivel)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Empresaid)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Nivel)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdtipoIndicador)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Peso)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.VisibleADI)
        .IsRequired()
        .HasColumnType("bit");
    }
}
