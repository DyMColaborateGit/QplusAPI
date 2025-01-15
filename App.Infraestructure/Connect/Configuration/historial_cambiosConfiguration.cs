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
    public class historial_cambiosConfiguration : IEntityTypeConfiguration<historial_cambiosEntities>
    {
        public void Configure(EntityTypeBuilder<historial_cambiosEntities> builder)
        {
            builder.ToTable("historial_cambios")
                .HasKey(p => new { p.IdHistorial });

            builder.Property(p => p.IdHistorial)
                .HasColumnName("id_historial")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.FechaHistorial)
                .HasColumnName("fecha_Historial")
                .HasColumnType("datetime");

            builder.Property(p => p.FechaCambio)
                .HasColumnName("fecha_cambio")
                .HasColumnType("datetime");

            builder.Property(p => p.NumeroActualizacion)
                .HasColumnName("numero_actualizacion")
                .HasColumnType("int");

            builder.Property(p => p.Descripcion)
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
