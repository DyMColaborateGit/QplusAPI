using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration
{
    public class tbl_com_ResultcomTecnicasConfiguration : IEntityTypeConfiguration<tbl_com_ResultcomTecnicasEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_com_ResultcomTecnicasEntities> builder)
        {
            builder.ToTable("tbl_com_ResultcomTecnicas").
            HasKey(p => new { p.ResultadoId });

            builder.Property(p => p.ResultadoId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.EvaluacionId)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Observacion)
            .IsRequired(false)
            .HasMaxLength(1050)
            .HasColumnType("nvarchar");

            builder.Property(p => p.EscalaNivel)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.FechaEva)
            .IsRequired()
            .HasColumnType("Datetime");

            builder.Property(p => p.EscalaId)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ResEscala)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.BEstado)
            .IsRequired()
            .HasColumnType("bit");

            builder.Property(p => p.BCerrado)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.EscalaNivel)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

        }
    }
}
