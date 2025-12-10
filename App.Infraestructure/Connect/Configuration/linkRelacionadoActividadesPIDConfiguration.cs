using App.Infraestructure.Connect.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration;

public class linkRelacionadoActividadesPIDConfiguration : IEntityTypeConfiguration<linkRelacionadoActividadesPIDEntities>
{
    public void Configure(EntityTypeBuilder<linkRelacionadoActividadesPIDEntities> builder)
    {
        builder.ToTable("linkRelacionadoActividadesPID").
        HasKey(p => new { p.Id });

        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");
    
        builder.Property(p => p.InIdActividadPID)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Nombre_Link)
        .IsRequired()
        .HasMaxLength(10000)
        .HasColumnType("nvarchar");

        builder.Property(e => e.Link)
        .IsRequired()
        .HasMaxLength(10000)
        .HasColumnType("nvarchar");
    }
}
