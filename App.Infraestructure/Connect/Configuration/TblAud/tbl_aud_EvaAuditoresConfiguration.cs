using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblAud;

namespace App.Infraestructure.Connect.Configuration.TblAud
{
    public class tbl_aud_EvaAuditoresConfiguration : IEntityTypeConfiguration<tbl_aud_EvaAuditoresEntities>
    {
        public void Configure(EntityTypeBuilder<tbl_aud_EvaAuditoresEntities> builder)
        {
            builder.ToTable("tbl_aud_EvaAuditores").
            HasKey(p => new { p.IdEvaluacion });

            builder.Property(p => p.IdEvaluacion)
               .ValueGeneratedOnAdd()
               .IsRequired()
               .HasColumnType("int");

            builder.Property(p => p.EmpresaId)
                .HasColumnType("int");

            builder.HasOne(p => p.AuditoriasObj)
                .WithMany(p => p.TBL_aud_EvaAuditores)
                .HasForeignKey(p => p.IdAuditoria)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.AuditorObj)
                .WithMany(p => p.TBL_aud_EvaAuditores)
                .HasForeignKey(p => p.IdAuditor)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Promedio)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Observaciones)
               .IsRequired()
               .HasMaxLength(4000)
               .HasColumnType("nvarchar");

            builder.Property(p => p.TotalPreCalificadas)
                .HasColumnType("int");

            builder.Property(p => p.TotalPreguntas)
                .HasColumnType("int");

            builder.Property(p => p.Estado)
                .HasColumnType("bit");

        }
    }
}
