using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblMast;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_mast_OficinasConfiguration : IEntityTypeConfiguration<tbl_mast_OficinasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_mast_OficinasEntities> builder)
    {
        builder.ToTable("tbl_mast_Oficinas").
        HasKey(p => new { p.CodigoOf });

        builder.Property(p => p.OficinaId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoOf)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.TBL_mast_Oficinas)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Oficina)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ZonaId)
        .IsRequired()
        .HasColumnType("int");

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
