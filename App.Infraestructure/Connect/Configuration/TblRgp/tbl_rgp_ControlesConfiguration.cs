
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ControlesConfiguration : IEntityTypeConfiguration<tbl_rgp_ControlesEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ControlesEntities> builder)
        {
            builder.ToTable("tbl_rgp_Controles")
                .HasKey(p => new { p.IdControl });

            builder.Property(p => p.IdControl)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.IdRiesgo)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Control)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.IdTipoControl)
                .HasColumnType("int");

            builder.Property(p => p.UsuarioCreacion)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.UsuarioModificacion)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(p => p.FechaModificacion)
                .IsRequired()
                .HasColumnType("Datetime");

            builder.Property(p => p.IdEvaluacion)
                .HasColumnType("int");
        }
    } 
}
