using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration
{
    public class scp_ProcesosConfiguration : IEntityTypeConfiguration<scp_ProcesosEntities>
    {
        public void Configure(EntityTypeBuilder<scp_ProcesosEntities> builder)
        {
            builder.ToTable("scp_Procesos").
            HasKey(p => new { p.Id_Proceso });

            builder.Property(p => p.Id_Proceso)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Id_Area)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Proceso)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Sigla)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Id_Cargo)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Mision)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Codigo_Mapa)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("nvarchar");

            builder.Property(p => p.Consecutivo_Mapa)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Certificado)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ElaboradoPor)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.AprobadoPor)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Generico)
            .IsRequired()
            .HasColumnType("bit");

        }
    }
}
