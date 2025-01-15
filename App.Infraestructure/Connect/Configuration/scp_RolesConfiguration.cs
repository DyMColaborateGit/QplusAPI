using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_RolesConfiguration : IEntityTypeConfiguration<scp_RolesEntities>
{
    public void Configure(EntityTypeBuilder<scp_RolesEntities> builder)
    {
        builder.ToTable("scp_Roles").
        HasKey(p => new { p.RoleId });

        builder.Property(p => p.RoleId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoRol)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.RolPadre)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.Role)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.CodigoApp)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("Datetime");


        builder.Property(p => p.UsuarioModificacion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");

    }
}
