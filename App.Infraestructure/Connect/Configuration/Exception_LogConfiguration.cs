using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.Share;

namespace App.Infraestructure.Connect.Configuration;

public class Exception_LogConfiguration: IEntityTypeConfiguration<Exception_LogEntities>
{
    public void Configure(EntityTypeBuilder<Exception_LogEntities> builder)
    {
        builder.ToTable("Exception_Log").
        HasKey(p => new { p.LogId });

        builder.Property(p => p.LogId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Metodo)
        .IsRequired()
        .HasColumnType("nvarchar");

        builder.Property(p => p.Aplicacion)
        .IsRequired()
        .HasColumnType("nvarchar");

        builder.Property(p => p.ExceptionString)
        .IsRequired()
        .HasColumnType("nvarchar");

        builder.Property(p => p.Observacion)
        .IsRequired()
        .HasColumnType("nvarchar");

        builder.Property(p => p.Anio)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.FechaLog)
        .IsRequired()
        .HasColumnType("Datetime");
    }
}
