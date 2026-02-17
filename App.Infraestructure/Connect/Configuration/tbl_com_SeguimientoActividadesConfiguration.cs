
using App.Infraestructure.Connect.Entities.TblCom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_SeguimientoActividadesConfiguration : IEntityTypeConfiguration<tbl_com_SeguimientoActividadesEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_SeguimientoActividadesEntities> builder)
    {
        builder.ToTable("tbl_com_SeguimientoActividades").
        HasKey(p => new { p.InIdSeguimiento });

        builder.Property(p => p.InIdSeguimiento)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdActividadPIM)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.DtFechaSeguimiento)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.DtFechaReal)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(e => e.VcSeguimiento)
        .IsRequired()
        .HasMaxLength(10000)
        .HasColumnType("nvarchar");

        builder.Property(e => e.UsuarioSeguimiento)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");
    }
}
