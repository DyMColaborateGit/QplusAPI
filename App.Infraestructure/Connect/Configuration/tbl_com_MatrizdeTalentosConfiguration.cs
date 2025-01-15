using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_MatrizdeTalentosConfiguration : IEntityTypeConfiguration<tbl_com_MatrizdeTalentosEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_MatrizdeTalentosEntities> builder)
    {
        builder.ToTable("tbl_com_MatrizdeTalentos").
        HasKey(p => new { p.CodTalento });

        builder.Property(p => p.CodTalento)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.NombreCaja)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(350)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NumeroCaja)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.PorcMaxC)
        .IsRequired()
        .HasColumnType("decimal(18, 2))");


        builder.Property(p => p.PorcMinC)
        .IsRequired()
        .HasColumnType("decimal(18, 2))");


        builder.Property(p => p.PorcMaxI)
        .IsRequired()
        .HasColumnType("decimal(18, 2))");


        builder.Property(p => p.PorcMinI)
        .IsRequired()
        .HasColumnType("decimal(18, 2))");

        builder.Property(p => p.CodMatrix)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioModificacion)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.FechaModificacion)
        .IsRequired()
        .HasColumnType("Datetime");

    }
}
