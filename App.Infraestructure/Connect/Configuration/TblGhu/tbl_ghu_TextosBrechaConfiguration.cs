using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_TextosBrechaConfiguration : IEntityTypeConfiguration<tbl_ghu_TextosBrechaEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_TextosBrechaEntities> builder)
    {
        builder.ToTable("tbl_ghu_TextosBrecha").
       HasKey(p => new { p.TextoBrechaId });

        builder.Property(p => p.TextoBrechaId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.TextoBrecha)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
            .HasColumnType("bit");

        builder.Property(p => p.UsuarioCreacion)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

    }
}
