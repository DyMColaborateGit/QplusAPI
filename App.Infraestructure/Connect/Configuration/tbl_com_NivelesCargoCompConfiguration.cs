using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_NivelesCargoCompConfiguration : IEntityTypeConfiguration<tbl_com_NivelesCargoCompEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_NivelesCargoCompEntities> builder)
    {
        builder.ToTable("tbl_com_NivelesCargoComp").
        HasKey(p => new { p.NivelCargoComId });

        builder.Property(p => p.NivelCargoComId)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CodigoCargo)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Normaobj)
        .WithMany(p => p.TBL_com_NivelesCargoComp)
        .HasForeignKey(p => p.CompetenciaId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.NivelId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.VisibleEva)
        .IsRequired()
        .HasColumnType("bit");
    }
}
