using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_RelGestoresDialogoDesarrolloConfiguration : IEntityTypeConfiguration<tbl_com_RelGestoresDialogoDesarrolloEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_RelGestoresDialogoDesarrolloEntities> builder)
    {
        builder.ToTable("tbl_com_RelGestoresDialogoDesarrollo").
        HasKey(p => new { p.IdRelgd });

        builder.Property(p => p.IdRelgd)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.FuncionarioId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.GestorId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.TipoRel)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");


        builder.Property(p => p.UpdatedAt)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.CreatedAt)
        .IsRequired()
        .HasColumnType("Datetime");

    }
}

