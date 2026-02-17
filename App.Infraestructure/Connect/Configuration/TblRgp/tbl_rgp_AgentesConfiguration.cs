
using App.Infraestructure.Connect.Entities.TblRgp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Connect.Configuration.TblRgp
{
    public class tbl_rgp_AgentesConfiguration : IEntityTypeConfiguration<tbl_rgp_AgentesEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_rgp_AgentesEntities> builder)
        {
            builder.ToTable("tbl_rgp_Agentes")
                .HasKey(p => new { p.IdAgente });

            builder.Property(p => p.IdAgente)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.Property(p => p.Agente)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");
        }
    }
}
