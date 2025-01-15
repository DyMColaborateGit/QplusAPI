using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_ClientesConfiguration : IEntityTypeConfiguration<scp_ClientesEntities>
{
    public void Configure(EntityTypeBuilder<scp_ClientesEntities> builder)
    {
        builder.ToTable("scp_Clientes").
        HasKey(p => new { p.ClienteId });

        builder.Property(p => p.ClienteId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoCli)
        .ValueGeneratedNever()
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Nombre)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Direccion)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Identificacion)
       .IsRequired()
       .HasMaxLength(50)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Telefono)
       .IsRequired()
       .HasMaxLength(30)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
       .IsRequired()
       .HasColumnType("bit");

        builder.Property(p => p.TipoLicenciaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoLicencia)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaVencimiento)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.NumUsers)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipoBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NomBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.HostBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UserBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PassBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PortBD)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.SmtpHost)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.StrCorreo)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.StrPassword)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InsLog)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.TipoSync)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TipoLogin)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Idioma)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Logo)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TipoEmpresa)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCreacion)
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
