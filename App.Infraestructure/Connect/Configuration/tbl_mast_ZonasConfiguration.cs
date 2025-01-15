using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblMast;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_mast_ZonasConfiguration : IEntityTypeConfiguration<tbl_mast_ZonasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_mast_ZonasEntities> builder)
    {
        builder.ToTable("tbl_mast_Zonas").
        HasKey(p => new { p.CodigoZO });

        builder.Property(p => p.ZonaId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoZO)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.TBL_mast_Zonas)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(p => p.ClienteId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Zona)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.CargoResponsable)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioModificacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");
    }
}
