using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_TemasBrechaPConfiguration : IEntityTypeConfiguration<tbl_ghu_TemasBrechaPlEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_TemasBrechaPlEntities> builder)
    {
        builder.ToTable("tbl_ghu_TemasBrechaP").
       HasKey(p => new { p.TemaBrechaId });

        builder.Property(p => p.TemaBrechaId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.NombreTema)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
            .HasColumnType("bit");
    }
}
