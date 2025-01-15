using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_ind_MastIndicadoresConfiguration : IEntityTypeConfiguration<tbl_ind_MastIndicadoresEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ind_MastIndicadoresEntities> builder)
    {
        builder.ToTable("tbl_ind_MastIndicadores").
        HasKey(p => new { p.InIdIndicador });

        builder.Property(p => p.InIdIndicador)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoCargo)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdProceso)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.VcNombreIndicador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InIdResponsable)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdTipoIndicador)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdTipoObjetivo)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdTipoMeta)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InMetaIndicador)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.InFrecuencia)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(e => e.VcNumerador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");


        builder.Property(e => e.VcDenominador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InEstado)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.BRevisionGerencial)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.InIdProducto)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InIdSistema)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.ObjetivoCargo)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ClaseId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.ClaseIndicador)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");


        builder.Property(e => e.FuncionarioInd)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Peso)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Descripcion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.ComoSeCalcula)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PuntoControl)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TipoIndGeneral)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.IdObjetivo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TipoCalculo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.Finalidad)
        .IsRequired(false)
        .HasColumnType("int");


        builder.Property(e => e.Unidad)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");


        builder.Property(e => e.CodIndicador)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.IdFuenteEstrategico)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TipoIndicadorEstrategico)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired(false)
        .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
        .IsRequired(false)
        .HasColumnType("Datetime");


        builder.Property(p => p.UsuarioModificacion)
        .IsRequired(false)
        .HasColumnType("bigint");

        builder.Property(p => p.FechaModificacion)
        .IsRequired(false)
        .HasColumnType("Datetime");

    }
}
