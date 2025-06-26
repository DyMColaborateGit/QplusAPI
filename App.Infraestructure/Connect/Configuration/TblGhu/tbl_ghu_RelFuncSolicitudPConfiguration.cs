using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_RelFuncSolicitudPConfiguration : IEntityTypeConfiguration<tbl_ghu_RelFuncSolicitudPEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_RelFuncSolicitudPEntities> builder)
    {
        builder.ToTable("tbl_ghu_RelFuncSolicitudP").
        HasKey(p => new { p.RelFuncSolicitudPId });

        builder.Property(p => p.RelFuncSolicitudPId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Identificacion)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.SolicitudId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Brecha)
            .IsRequired()
            .HasColumnType("bit");

        builder.Property(p => p.TextoBrecha)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.UsuarioCreacion)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

        builder.Property(p => p.UsuarioCierreBrecha)
            .IsRequired()
            .HasColumnType("bigint");
    }
}
