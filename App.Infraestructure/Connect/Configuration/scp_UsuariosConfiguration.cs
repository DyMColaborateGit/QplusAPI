
using App.Infraestructure.Connect.Entities.Scp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration;

public class scp_UsuariosConfiguration : IEntityTypeConfiguration<scp_UsuariosEntities>
{
    public void Configure(EntityTypeBuilder<scp_UsuariosEntities> builder)
    {
        builder.ToTable("scp_Usuarios").
        HasKey(p => new { p.WWID });

        builder.Property(p => p.UserId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.WWID)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("bigint");

        builder.HasOne(p => p.Clienteobj)
        .WithMany(p => p.SCP_Usuarios)
        .HasForeignKey(p => p.ClienteId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.SCP_Usuarios)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Funcionariobj)
        .WithMany(p => p.SCP_Usuarios)
        .HasForeignKey(p => p.FuncionarioId)
        .OnDelete(DeleteBehavior.NoAction);


        builder.Property(p => p.Nombre)
        .IsRequired(false)
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UserName)
        .IsRequired(false)
        .HasMaxLength(250)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Clave)
        .IsRequired(false)
        .HasMaxLength(550)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Email)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Observaciones)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ImagenUrl)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.IsLogged)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.LastLogin)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.ErroresCount)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Rol)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
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