using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_PreguntasBrechaPConfiguration : IEntityTypeConfiguration<tbl_ghu_PreguntasBrechaPEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_PreguntasBrechaPEntities> builder)
    {
        builder.ToTable("tbl_ghu_PreguntasBrechaP").
        HasKey(p => new { p.PreguntaId });

        builder.Property(p => p.PreguntaId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Pregunta)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.TipoPregunta)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.TemaBrechaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Estado)
            .HasColumnType("bit");
    }
}
