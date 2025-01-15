using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_EncuestaPreguntaConfiguration : IEntityTypeConfiguration<tbl_com_EncuestaPreguntaEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_EncuestaPreguntaEntities> builder)
    {
        builder.ToTable("tbl_com_EncuestaPregunta").
        HasKey(p => new { p.IdEncuestaPregunta });

        builder.Property(p => p.IdEncuestaPregunta)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.EncuestaObj)
        .WithMany(p => p.TBL_com_EncuestaPregunta)
        .HasForeignKey(p => p.IdEncuesta)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.PreguntaObj)
        .WithMany(p => p.TBL_com_EncuestaPregunta)
        .HasForeignKey(p => p.IdPregunta)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Resultado)
        .IsRequired()
        .HasColumnType("int");
    }
}
