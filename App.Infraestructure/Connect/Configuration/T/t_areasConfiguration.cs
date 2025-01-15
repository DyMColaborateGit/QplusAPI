using App.Infraestructure.Connect.Entities.T;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration.T
{
    public class t_areasConfiguration : IEntityTypeConfiguration<areasEntities>
    {
        public void Configure(EntityTypeBuilder<areasEntities> builder)
        {
            builder.ToTable("t_areas")
               .HasKey(p => new { p.IdArea });

            builder.Property(p => p.IdArea)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_area")
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Area)
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.CodigoMapa)
                .HasColumnName("codigo_mapa")
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FuncionPpl)
                .HasColumnName("funcion_ppl")
                .HasColumnType("text");

            builder.Property(p => p.Estado)
                .HasColumnType("int");

            builder.Property(p => p.Sigla)
                .HasMaxLength(20)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Logo)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");
        }
    }
}
