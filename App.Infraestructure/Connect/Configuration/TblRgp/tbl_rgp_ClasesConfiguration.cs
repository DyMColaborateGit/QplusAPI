
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ClasesConfiguration : IEntityTypeConfiguration<tbl_rgp_ClasesEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ClasesEntities> builder)
        {
            builder.ToTable("tbl_rgp_Clases")
                .HasKey(p => new { p.ClaseId });

            builder.Property(p => p.ClaseId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Clase)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
