
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ProbabilidadesConfiguration : IEntityTypeConfiguration<tbl_rgp_ProbabilidadesEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ProbabilidadesEntities> builder)
        {
            builder.ToTable("tbl_rgp_Probabilidades")
                .HasKey(p => new { p.IdProbabilidad });

            builder.Property(p => p.IdProbabilidad)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Probabilidad)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Varlor)
                .HasColumnType("int");

            builder.Property(p => p.Descripcion)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
