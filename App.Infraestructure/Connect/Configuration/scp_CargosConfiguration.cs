using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_CargosConfiguration : IEntityTypeConfiguration<scp_CargosEntities>
{
    public void Configure(EntityTypeBuilder<scp_CargosEntities> builder)
    {
        builder.ToTable("scp_Cargos").
        HasKey(p => new { p.CargoId });

        builder.Property(p => p.CargoId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.SCP_Cargos)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Codigo)
        .IsRequired()
        .HasColumnType("int");

        //builder.HasOne(p => p.DocumentosObj)
        //        .WithMany(p => p.SCP_Cargos)
        //        .HasForeignKey(p => p.Codigo)
        //        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.CodigoCO)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.VcNombre)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NivelSeguridad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.BActivo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Nuevo)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.COActiva)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.DescCargo)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.AreaValoracion)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.GrupoCargo)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.IdTipoNivelEstrategico)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioModificacion)
        .IsRequired()
        .HasColumnType("bigint");
    }
}