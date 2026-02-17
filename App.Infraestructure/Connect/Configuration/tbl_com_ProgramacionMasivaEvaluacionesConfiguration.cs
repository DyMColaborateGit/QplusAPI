using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ProgramacionMasivaEvaluacionesConfiguration : IEntityTypeConfiguration<tbl_com_ProgramacionMasivaEvaluacionesEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ProgramacionMasivaEvaluacionesEntities> builder)
    {
        builder.ToTable("tbl_com_ProgramacionMasivaEvaluaciones").
        HasKey(p => new { p.IdProgramacion });

        builder.Property(p => p.IdProgramacion)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CedulaEvaluado)
        .ValueGeneratedNever()
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.ClaveCargoEvaluado)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.ZonaObj)
        .WithMany(p => p.TBL_com_ProgramacionMasivaEvaluacion)
        .HasForeignKey(p => p.CodigoDireccion)
        .HasPrincipalKey(m => m.CodigoZO)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.OficinaObj)
        .WithMany(p => p.TBL_com_ProgramacionMasivaEvaluacion)
        .HasForeignKey(p => p.CodigoGerencia)
        .HasPrincipalKey(m => m.CodigoOf)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.CodigoNivelCompetencia)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.MesProgramado)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.CedulaEvaluador)
        .IsRequired()
        .HasColumnType("bigint");


        builder.Property(p => p.Anio)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.MesInicio)
        .IsRequired()
        .HasColumnType("int");


        builder.Property(p => p.MesFin)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.FechaProgramacion)
        .IsRequired()
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioProgramacion)
        .IsRequired()
        .HasColumnType("bigint");
    }
}

