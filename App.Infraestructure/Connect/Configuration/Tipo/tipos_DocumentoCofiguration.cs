using App.Infraestructure.Connect.Entities.Tipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration.Tipo
{
    public class tipos_DocumentoCofiguration : IEntityTypeConfiguration<tipos_DocumentoEntities>
    {
        public void Configure(EntityTypeBuilder<tipos_DocumentoEntities> builder)
        {
            builder.ToTable("tipos_documento")
                .HasKey(p => new { p.IdTipo });

            builder.Property(p => p.IdTipo)
                .HasColumnName("id_tipo")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.CodigoTipo)
                .HasColumnName("codigo_tipo")
                .HasMaxLength(10)
                .HasColumnType("varchar");

            builder.Property(p => p.Tipo)
                .HasMaxLength(225)
                .HasColumnType("varchar");

            builder.Property(p => p.Observaciones)
                .HasColumnType("text");

            builder.Property(p => p.TipoDocumento)
                .HasColumnType("int");

            builder.Property(p => p.Adjunto)
                .HasColumnType("bit");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
