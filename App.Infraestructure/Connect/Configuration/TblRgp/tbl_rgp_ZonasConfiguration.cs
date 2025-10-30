using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ZonasConfiguration : IEntityTypeConfiguration<tbl_rgp_ZonasEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ZonasEntities> builder)
        {
            builder.ToTable("tbl_rgp_Zonas")
                .HasKey(p => new { p.IdZona });

            builder.Property(p => p.IdZona)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Zona)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Respuesta)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Color)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Sigla)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Aceptabilidad)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
