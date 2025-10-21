using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_EvaluacionRiesgoConfiguration : IEntityTypeConfiguration<tbl_rgp_EvaluacionRiesgoEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_EvaluacionRiesgoEntities> builder)
        {
            builder.ToTable("tbl_rgp_EvaluacionRiesgo")
                .HasKey(p => new { p.IdEvaluacion });

            builder.Property(p => p.IdEvaluacion)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Fecha)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.IdRiesgo)
                .HasColumnType("int");

            builder.Property(p => p.ValorProbabilidad)
                .HasColumnType("int");

            builder.Property(p => p.ValorConsecuencia)
                .HasColumnType("int");

            builder.Property(p => p.ResultadoRiesgo)
                .HasColumnType("int");

            builder.Property(p => p.Zona)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.SiglaZona)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Respuesta)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Color)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Aceptabilidad)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.EvaAnterior)
                .HasColumnType("int");

            builder.Property(p => p.UbicacionMR)
                .HasColumnType("int");
        }
    }
}
