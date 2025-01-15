using App.Infraestructure.Connect.Entities.Scp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.Scp;

public class scp_ParametrosEmpresaConfiguration : IEntityTypeConfiguration<scp_ParametrosEmpresasEntities>
{
    public void Configure(EntityTypeBuilder<scp_ParametrosEmpresasEntities> builder)
    {
        builder.ToTable("scp_ParametrosEmpresa")
        .HasKey(p => new { p.ParametroId });

        builder.Property(p => p.ParametroId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Parametro)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Descripcion)
        .HasColumnType("ntext");

        builder.Property(p => p.Valor)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioModificacion)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");
    }
}
