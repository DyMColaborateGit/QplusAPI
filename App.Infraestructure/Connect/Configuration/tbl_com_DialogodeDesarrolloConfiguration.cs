using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_DialogodeDesarrolloConfiguration : IEntityTypeConfiguration<tbl_com_DialogodeDesarrolloEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_DialogodeDesarrolloEntities> builder)
    {
        builder.ToTable("tbl_com_DialogodeDesarrollo").
        HasKey(p => new { p.IdDialogo });

        builder.Property(p => p.IdDialogo)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.FuncionarioId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.Observacion)
        .IsRequired()
        .HasMaxLength(1050)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TipoGestor)
        .IsRequired()
        .HasMaxLength(1050)
        .HasColumnType("nvarchar");

        builder.Property(p => p.GestorId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.UpdatedAt)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.CreatedAt)
        .IsRequired()
        .HasColumnType("Datetime");

    }
}
        
