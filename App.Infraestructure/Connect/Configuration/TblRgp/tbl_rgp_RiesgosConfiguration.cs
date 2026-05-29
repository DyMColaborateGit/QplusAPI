
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_RiesgosConfiguration : IEntityTypeConfiguration<tbl_rgp_RiesgosEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_RiesgosEntities> builder)
        {
            builder.ToTable("tbl_rgp_Riesgos")
                .HasKey(p => new { p.IdRiesgo });

            builder.Property(p => p.IdRiesgo)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Riesgo)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Descripcion)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.IdAgente)
                .HasColumnType("int");

            builder.Property(p => p.Causas)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Efectos)
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");

            builder.HasOne(p => p.ProcesosObj)
                .WithMany(p => p.TBL_rgp_Riesgos)
                .HasForeignKey(p => p.ProcesoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.ClaseId)
                .HasColumnType("int");

            builder.Property(p => p.IdTipoAnalisis)
                .HasColumnType("int");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");

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

            builder.HasOne(p => p.EvaluacionRObj)
                .WithMany(p => p.TBL_rgp_Riesgos)
                .HasForeignKey(p => p.EvaluacionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Codigo)
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Consecutivo)
                .HasColumnType("int");

            builder.Property(p => p.SubprocesoId)
                .HasColumnType("int");

            builder.Property(p => p.MacroProcesoId)
                .HasColumnType("int");

            builder.Property(p => p.Responsable)
                .IsRequired()
                .HasColumnType("bigint");
        }
    } 
}
