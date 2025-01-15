using App.Infraestructure.Connect.Entities.TblDoc;
using App.Infraestructure.Connect.Entities.TblMast;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Configuration.TblMast
{
    public class tbl_mast_SistemasGestionConfiguration : IEntityTypeConfiguration<tbl_mast_SistemasGestionEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_mast_SistemasGestionEntities> builder)
        {
            builder.ToTable("tbl_mast_SistemasGestion")
                .HasKey(p => new { p.InIdSistema });

            builder.Property(p => p.InIdSistema)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.VcSistema)
                .HasMaxLength(128)
                .HasColumnType("nvarchar");

            builder.Property(p => p.VcSigla)
                .HasMaxLength(10)
                .HasColumnType("varchar");

            builder.Property(p => p.InEstado)
                .HasColumnType("int");

            builder.Property(p => p.Principal)
                .HasColumnType("int");
        }
    }
    
}
