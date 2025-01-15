using App.Infraestructure.Connect.Entities.Scp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.Scp
{
    public class scp_CargosProcesosConfiguration : IEntityTypeConfiguration<scp_CargosProcesosEntities>
    {
        public void Configure(EntityTypeBuilder<scp_CargosProcesosEntities> builder)
        {
            builder.ToTable("scp_CargosProcesos").
            HasKey(p => new { p.IdCargoAsoc });

            builder.Property(p => p.IdCargoAsoc)
            .HasColumnName("id_cargo_asoc")
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
            .HasColumnType("int");

            //builder.Property(p => p.IdCargo)
            //    .HasColumnName("id_cargo")
            //    .IsRequired()
            //    .HasColumnType("int");

            builder.HasOne(p => p.CargosObj)
                .WithMany(p => p.SCP_CargosProcesos)
                .HasForeignKey(p => p.id_cargo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.IdProceso)
                .HasColumnName("id_proceso")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.TipoCargo)
                .HasColumnName("tipo_cargo")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
        }
    }
}
