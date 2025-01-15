using App.Infraestructure.Connect.Entities.TblAud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration.TblAud
{
    public class auditoriasConfiguration : IEntityTypeConfiguration<auditoriasEntities>
    {
        public void Configure(EntityTypeBuilder<auditoriasEntities> builder)
        {
            builder.ToTable("auditorias").
            HasKey(p => new { p.IdAuditoria });

            builder.Property(p => p.IdAuditoria)
                .HasColumnName("id_auditoria")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.InIdEmpresa)
                .HasColumnType("int");
            
            builder.Property(p => p.ZonaId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(p => p.OficinaId)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(p => p.Consecutivo)
                .HasColumnType("int");

            builder.Property(p => p.CodigoAuditoria)
                .HasColumnName("codigo_auditoria")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.HasOne(p => p.ProcesosObj)
                .WithMany(p => p.Auditorias)
                .HasForeignKey(p => p.Proceso)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Auditor1)
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Auditor2)
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FechaProg)
                .HasColumnName("fecha_prog")
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaReal)
                .HasColumnName("fecha_real")
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaProgInforme)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaInfoDefinitivo)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaProgCierre)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaRealCierre)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaProgEvaluacion)
                .HasColumnType("Datetime");

            builder.Property(p => p.FechaRealEvaluacion)
                .HasColumnType("Datetime");

            builder.Property(p => p.Mes)
                .HasColumnType("int");

            builder.Property(p => p.Anio)
                .HasColumnName("año")
                .HasColumnType("int");

            builder.Property(p => p.Estado)
                .HasMaxLength(3)
                .HasColumnType("varchar");

            builder.Property(p => p.Requisitos)
                .HasMaxLength(4000)
                .HasColumnType("varchar");

            builder.Property(p => p.Hora)
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(p => p.Auditados)
                .HasMaxLength(4000)
                .HasColumnType("varchar");

            builder.Property(p => p.FlIndicadorInforme)
                .HasColumnType("float");

            builder.Property(p => p.InDiasRetInforme)
                .HasColumnType("float");

            builder.Property(p => p.FlIndicadorCierre)
                .HasColumnType("float");

            builder.Property(p => p.InDiasRetCierre)
                .HasColumnType("float");

            builder.Property(p => p.FlIndicadorEvaluacion)
                .HasColumnType("float");

            builder.Property(p => p.InDiasRetEvaluacion)
                .HasColumnType("float");

            builder.Property(p => p.InIdSistema)
                .HasColumnType("int");

            builder.Property(p => p.AprobadorId)
                .IsRequired(false)
                .HasColumnType("bigint");

            builder.Property(p => p.OtrosAuditores)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Identiauditor1)
                .HasColumnType("bigint");

            builder.Property(p => p.Identiauditor2)
                .HasColumnType("bigint");

        }

    }
}
