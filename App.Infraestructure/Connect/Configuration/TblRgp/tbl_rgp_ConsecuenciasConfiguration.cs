
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ConsecuenciasConfiguration : IEntityTypeConfiguration<tbl_rgp_ConsecuenciasEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ConsecuenciasEntities> builder)
        {
            builder.ToTable("tbl_rgp_Consecuencias")
                .HasKey(p => new { p.IdConsecuencia });

            builder.Property(p => p.IdConsecuencia)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Consecuencia)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Valor)
                .HasColumnType("int");

            builder.Property(p => p.Descripcion)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}

