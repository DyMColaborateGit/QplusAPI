using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration
{
    public class tbl_ind_ResultIndiCoporpConfiguration : IEntityTypeConfiguration<tbl_ind_ResultIndiCoporpEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_ind_ResultIndiCoporpEntities> builder)
        {
            builder.ToTable("tbl_ind_ResultIndiCoporp").
            HasKey(p => new { p.ResultadoId });

            builder.Property(p => p.ResultadoId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
            .IsRequired(false)
            .HasColumnType("int");

            builder.Property(p => p.CodigoIndi)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Anio)
            .IsRequired(false)
            .HasColumnType("int");

            builder.Property(p => p.Resultado)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Peso)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Ponderado)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        }
    }
}