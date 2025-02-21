using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_EmpresasConfiguration : IEntityTypeConfiguration<scp_EmpresasEntities>
{
    public void Configure(EntityTypeBuilder<scp_EmpresasEntities> builder)
    {
        builder.ToTable("scp_Empresas").
        HasKey(p => new { p.EmpresaId });

        builder.Property(p => p.IdEmpresa)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ClienteId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoCli)
        .ValueGeneratedNever()
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Empresa)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Logo)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
       .IsRequired()
       .HasColumnType("bit");

        builder.Property(p => p.Presentacion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Ciudad)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TipoLogin)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.ParamCodigo)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodProveedor)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.SrvAutenticacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.DominioLdap)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UsuarioLdap)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ClaveLdap)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TipoNivelComp)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.LogoMacroProceso)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.CodTipoMatrix)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.UsuarioModificacion)
       .IsRequired()
       .HasMaxLength(150)
       .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.Mod_MT)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.MapaTalentos)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.Mod_MD)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.Adi_Estrategicos)
        .IsRequired()
        .HasColumnType("bit");
    }
}
