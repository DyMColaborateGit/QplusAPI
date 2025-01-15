using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_PesosxTipoIndEstxTipoNivelEstConfiguration : IEntityTypeConfiguration<tbl_ind_PesosxTipoIndEstxTipoNivelEstEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_PesosxTipoIndEstxTipoNivelEstEntities> builder)
    {
        builder.ToTable("tbl_ind_PesosxTipoIndEstxTipoNivelEst").
        HasKey(p => new { p.IdPesos });

        builder.Property(p => p.IdPesos)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Empresaid)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipoNivelEst)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdtipoIndicadorEst)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Peso)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Anio)
        .IsRequired()
         .HasColumnType("int");
    }
}
