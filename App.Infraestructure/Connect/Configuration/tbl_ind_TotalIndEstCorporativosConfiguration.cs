using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration
{
    internal class tbl_ind_TotalIndEstCorporativosConfiguration : IEntityTypeConfiguration<tbl_ind_TotalIndEstCorporativosEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_ind_TotalIndEstCorporativosEntities> builder)
        {
            builder.ToTable("tbl_ind_TotalIndEstCorporativos").
            HasKey(p => new { p.IdTotal });

            builder.Property(p => p.IdTotal)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Empresaid)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Anio)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        }
    }
}
