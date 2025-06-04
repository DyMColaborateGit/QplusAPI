using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_RespuestaMultiplesBrechaPConfiguration : IEntityTypeConfiguration<tbl_ghu_RespuestaMultiplesBrechaPEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_RespuestaMultiplesBrechaPEntities> builder)
    {
        builder.ToTable("tbl_ghu_RespuestaMultiplesBrechaP").
        HasKey(p => new { p.RespuestaBrechaPId });

        builder.Property(p => p.RespuestaBrechaPId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.PreguntaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");


        builder.Property(p => p.Respuesta)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
            .HasColumnType("bit");
    }
}
