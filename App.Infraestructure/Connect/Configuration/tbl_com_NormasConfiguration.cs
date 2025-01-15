using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_NormasConfiguration : IEntityTypeConfiguration<tbl_com_NormasEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_NormasEntities> builder)
    {
        builder.ToTable("tbl_com_Normas").
        HasKey(p => new { p.InIdNorma });

        builder.Property(p => p.InIdNorma)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Empresaobj)
        .WithMany(p => p.TBL_com_Normas)
        .HasForeignKey(p => p.EmpresaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.VcCodNorma)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(e => e.VcCodFuncion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InIdTipoNorma)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.VcCompetencia)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InConsecutivo)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.BEstado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.InIdGrupo)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.UsuarioCreacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Fechacreacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(e => e.UsuarioModificacion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");
    }
}
