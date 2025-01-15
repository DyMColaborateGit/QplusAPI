using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_AspectosValoracionConfiguration : IEntityTypeConfiguration<tbl_com_AspectosValoracionEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_AspectosValoracionEntities> builder)
    {
        builder.ToTable("tbl_com_AspectosValoracion").
        HasKey(p => new { p.AspectoValoracionId });

        builder.Property(p => p.AspectoValoracionId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.AspectoValoracion)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasColumnType("bit");
    }
}
