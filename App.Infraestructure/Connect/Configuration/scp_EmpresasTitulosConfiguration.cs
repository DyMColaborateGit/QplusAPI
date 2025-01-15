using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration
{
    public class scp_EmpresasTitulosConfiguration : IEntityTypeConfiguration<scp_EmpresasTitulosEntities>
    {
        public void Configure(EntityTypeBuilder<scp_EmpresasTitulosEntities> builder)
        {
            builder.ToTable("scp_EmpresasTitulos").
            HasKey(p => new { p.CodTitulo });

            builder.Property(p => p.CodTitulo)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");


            builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Zona)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Oficina)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Acciones)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.AccionesCti)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Tareas)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.TareasCti)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Auditorias)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.AuditoriasCti)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.TituloMapaT)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");

            builder.Property(p => p.TituloMapaTM)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");

            builder.Property(p => p.EjeX_MapaT)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");

            builder.Property(p => p.EjeY_MapaT)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");
        }
    }
}
