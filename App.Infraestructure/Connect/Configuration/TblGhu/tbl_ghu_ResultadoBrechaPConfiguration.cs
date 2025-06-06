using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_ResultadoBrechaPConfiguration : IEntityTypeConfiguration<tbl_ghu_ResultadoBrechaPEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_ResultadoBrechaPEntities> builder)
    {
        builder.ToTable("tbl_ghu_ResultadoBrechaP").
        HasKey(p => new { p.ResultadoBrechaId });

        builder.Property(p => p.ResultadoBrechaId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.PreguntaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.UsuarioAnalisisBrecha)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.TipoPregunta)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.TemaBrecha)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.RelFuncSolicitudPId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.PadreId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.HijoId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.TextoPregunta)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.TextoSMultiple)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.RespuestaAbierta)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.ResultadoSMultiple)
            .HasColumnType("bit");
    }
}
