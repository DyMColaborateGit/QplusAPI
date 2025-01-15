using App.Infraestructure.Connect.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration
{
    public class productosConfiguration : IEntityTypeConfiguration<productosEntities>
    {
        public void Configure(EntityTypeBuilder<productosEntities> builder)
        {
            builder.ToTable("productos").
            HasKey(p => new { p.IdProducto });

            builder.Property(p => p.IdProducto)
                .HasColumnName("id_producto")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.IdProceso)
                .HasColumnName("id_proceso")
                .HasColumnType("int");

            //builder.HasOne(p => p.ProcesosObj)
            //    .WithMany(p => p.Productos)
            //    .IsRequired()
            //    .HasForeignKey(p => p.id_proceso)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Producto)
                .HasMaxLength(255)
                .HasColumnType("varchar");

            builder.Property(p => p.VcDescripcion)
                .HasMaxLength(512)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Frecuencia)
                .HasColumnType("int");

            builder.Property(p => p.Responsable)
                .HasColumnType("int");

            builder.Property(p => p.Estado)
                .HasColumnType("int");

            builder.Property(p => p.TipoProducto)
                .HasColumnName("tipo_producto")
                .HasColumnType("int");

            builder.Property(p => p.TipoIndOpt)
                .HasColumnName("tipo_ind_opt")
                .HasColumnType("int");

            builder.Property(p => p.Eliminado)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.Property(p => p.Abreviatura)
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
        }
    }
}
