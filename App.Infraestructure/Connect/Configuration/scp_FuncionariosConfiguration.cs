using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Configuration;

public class scp_FuncionariosConfiguration : IEntityTypeConfiguration<scp_FuncionariosEntities>
{
    public void Configure(EntityTypeBuilder<scp_FuncionariosEntities> builder)
    {
        builder.ToTable("scp_Funcionarios").
        HasKey(p => new { p.Identificacion });

        builder.Property(p => p.Id_funcionario)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Identificacion)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("bigint");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.SCP_Funcionarios)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.ZonaId)//Esta es foranea tbl_mast_Zonas
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.OficinaId)//Esta es foranea tbl_mast_Oficinas
        .IsRequired()
        .HasColumnType("int");


        builder.HasOne(p => p.Cargoobj)
        .WithMany(f => f.SCP_Funcionarios)
        .HasForeignKey(p => p.CargoId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Genero)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Cenco)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.NivelSeguridad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Nuevo)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.EstadoPerfil)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.Hojadevida)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.IndiEstrategico)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.FechaIngreso)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.Sueldo)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TipoContratoId) //Foranea de tbl_ghu_TipoContrato
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.SedeId)//Foranea de tbl_mast_Sede
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
