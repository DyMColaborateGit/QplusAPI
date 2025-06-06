using App.Infraestructure.Connect.Entities.TblGhu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblGhu;

public class tbl_ghu_SolicitudPersonalConfiguration : IEntityTypeConfiguration<tbl_ghu_solicitudPersonalEntities>
{
    public void Configure(EntityTypeBuilder<tbl_ghu_solicitudPersonalEntities> builder)
    {
        builder.ToTable("tbl_ghu_SolicitudPersonal").
        HasKey(p => new { p.SolicitudId });

        builder.Property(p => p.SolicitudId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EmpresaId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Solicitante)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.TipoSolicitud)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.CargoDigitado)
            .HasMaxLength(200)
            .HasColumnType("nvarchar");

        builder.Property(p => p.CodigoCargo)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.CargoJefe)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.EstadoSolicitud)
            .HasColumnType("bit");

        builder.Property(p => p.EstadoBrecha)
            .HasColumnType("bit");

        builder.Property(p => p.FechaSolicitud)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(p => p.FechaSolicitudIngreso)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(p => p.MacroProcesoId)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Id_proceso)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.Id_producto)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.CantidadPersonasS)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.HorarioTrabajo)
            .HasMaxLength(200)
            .HasColumnType("nvarchar");

        builder.Property(p => p.SalarioAsignado)
            .HasMaxLength(200)
            .HasColumnType("nvarchar");

        builder.Property(p => p.CentroCostos)
            .HasMaxLength(200)
            .HasColumnType("nvarchar");

        builder.Property(p => p.IdContrato)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(p => p.DuracionVinculacion)
            .HasColumnType("int");

        builder.Property(p => p.Ciudad)
            .HasMaxLength(100)
            .HasColumnType("nvarchar");

        builder.Property(p => p.Requisitos)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.Funciones)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.SolicitudCorreo)
            .HasColumnType("bit");

        builder.Property(p => p.EquipoComputo)
            .HasColumnType("bit");

        builder.Property(p => p.Portatil)
            .HasColumnType("bit");

        builder.Property(p => p.Escritorio)
            .HasColumnType("bit");

        builder.Property(p => p.Observaciones)
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.Property(p => p.UsuarioCreacion)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.FechaCreacion)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(p => p.UsuarioModificacion)
            .IsRequired()
            .HasColumnType("bigint");

        builder.Property(p => p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");
    }
}
