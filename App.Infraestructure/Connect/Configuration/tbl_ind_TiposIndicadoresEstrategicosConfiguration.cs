using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_TiposIndicadoresEstrategicosConfiguration : IEntityTypeConfiguration<tbl_ind_TiposIndicadoresEstrategicosEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_TiposIndicadoresEstrategicosEntities> builder)
    {
        builder.ToTable("tbl_ind_TiposIndicadoresEstrategicos").
        HasKey(p => new { p.Id });

        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdTipoIndiEstra)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TipoIndicadorEstrategico)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");
    }
}
