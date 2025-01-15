using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ParametrosDesempeno: IEntityTypeConfiguration<tbl_com_ParametrosDesempenoEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ParametrosDesempenoEntities> builder)
    {
        builder.ToTable("tbl_com_ParametrosDesempeno").
        HasKey(p => new { p.ParametroId });

        builder.Property(p => p.ParametroId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TipoId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.OperadorMin)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ValorMin)
        .IsRequired()
        .HasColumnType("float");

        builder.Property(p => p.OperadorMax)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ValorMax)
        .IsRequired()
        .HasColumnType("float");

        builder.Property(p => p.Parametro)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Color)
        .IsRequired()
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Descripcion)
        .IsRequired(false)
        .HasColumnType("ntext");
    }
}
