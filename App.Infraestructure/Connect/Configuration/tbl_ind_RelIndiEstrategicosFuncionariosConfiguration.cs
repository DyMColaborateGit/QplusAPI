using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_RelIndiEstrategicosFuncionariosConfiguration : IEntityTypeConfiguration<tbl_ind_RelIndiEstrategicosFuncionariosEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_RelIndiEstrategicosFuncionariosEntities> builder)
    {
        builder.ToTable("tbl_ind_RelIndiEstrategicosFuncionarios").
        HasKey(p => new { p.IdRelacion });

        builder.Property(p => p.IdRelacion)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.tbl_ind_MastIndicadoresObj)
       .WithMany(p => p.TBL_ind_RelIndiEstrategicosFuncionarios)
       .HasForeignKey(p => p.IndicadorId)
       .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Identificacion)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.Peso)
        .IsRequired()
        .HasColumnType("double");
    }
}
