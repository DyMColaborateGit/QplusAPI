using App.Infraestructure.Connect.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration
{
    public class control_distribucionConfiguration : IEntityTypeConfiguration<control_distribucionEntities>
    {
        public void Configure(EntityTypeBuilder<control_distribucionEntities> builder)
        {
            builder.ToTable("control_distribucion")
                .HasKey(p => new { p.IdDistribucion });

            builder.Property(p => p.IdDistribucion)
                .HasColumnName("id_distribucion")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.FechaDistribucion)
                .HasColumnName("fecha_dist")
                .HasColumnType("datetime");

            builder.Property(p => p.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("datetime");

            builder.Property(p => p.NumeroActualizacion)
                .HasColumnName("numero_actualizacion")
                .HasColumnType("int");

            builder.Property(p => p.ListaDistribucion)
                .HasColumnName("lista_distribucion")
                .HasColumnType("text");


            builder.Property(p => p.CodigoDocumento)
                .HasColumnName("codigo_documento")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(p => p.IdDocumento)
                .HasColumnName("id_documento")
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");
        }
    }
}
