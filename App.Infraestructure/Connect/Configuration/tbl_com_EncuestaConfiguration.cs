using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_EncuestaConfiguration : IEntityTypeConfiguration<tbl_com_EncuestaEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_EncuestaEntities> builder)
    {
        builder.ToTable("tbl_com_Encuesta").
        HasKey(p => new { p.IdEncuesta });

        builder.Property(p => p.IdEncuesta)
       .ValueGeneratedOnAdd()
       .IsRequired()
       .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdADI)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.TotalPreguntas)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.PreguntasCalificadas)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("int");
    }
}

