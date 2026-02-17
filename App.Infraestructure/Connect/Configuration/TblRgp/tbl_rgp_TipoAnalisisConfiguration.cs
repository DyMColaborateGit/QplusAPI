
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_TipoAnalisisConfiguration : IEntityTypeConfiguration<tbl_rgp_TipoAnalisisEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_TipoAnalisisEntities> builder)
        {
            builder.ToTable("tbl_rgp_TipoAnalisis")
                .HasKey(p => new { p.IdTipoAnalisis });

            builder.Property(p => p.IdTipoAnalisis)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.TipoAnalisis)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
