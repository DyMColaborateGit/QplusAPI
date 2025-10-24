using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_ParametrosValoracionConfiguration : IEntityTypeConfiguration<tbl_rgp_ParametrosValoracionEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_ParametrosValoracionEntities> builder)
        {
            builder.ToTable("tbl_rgp_ParametrosValoracion")
                .HasKey(p => new { p.IdParametro });

            builder.Property(p => p.IdParametro)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.ValorProbabilidad)
                .HasColumnType("int");

            builder.Property(p => p.valorConsecuencia)
                .HasColumnType("int");

            builder.Property(p => p.Resultado)
                .HasColumnType("int");

            builder.HasOne(p => p.ZonaObj)
                .WithMany(p => p.TBL_rgp_ParametrosValoracion)
                .HasForeignKey(p => p.IdZona)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.UbicacionMR)
                .HasColumnType("int");
        }
    }
}
