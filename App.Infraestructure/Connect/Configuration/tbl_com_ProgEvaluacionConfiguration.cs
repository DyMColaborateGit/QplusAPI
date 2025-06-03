using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Infraestructure.Connect.Entities.TblCom;

namespace App.Infraestructure.Connect.Configuration;

public class tbl_com_ProgEvaluacionConfiguration : IEntityTypeConfiguration<tbl_com_ProgEvaluacionEntities>
{
    public void Configure(EntityTypeBuilder<tbl_com_ProgEvaluacionEntities> builder)
    {
        builder.ToTable("tbl_com_ProgEvaluacion").
        HasKey(p => new { p.InIdEvaluacion });

        builder.Property(p => p.InIdEvaluacion)
        .ValueGeneratedOnAdd()
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.InTipoInstrumento)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.InIdTipoNorma)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.NomNorma)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InIdEvaluador)
        .IsRequired(false)
        .HasColumnType("bigint");

        builder.Property(p => p.NomEvaluador)
        .IsRequired(false)
        .HasMaxLength(255)
        .HasColumnType("nvarchar");

        builder.Property(p => p.CodigoCargo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.HasOne(p => p.EvaluadObj)
        .WithMany(p => p.TBL_com_ProgEvaluacion)
        .HasForeignKey(p => p.InIdEvaluado)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.NomEvaluado)
        .IsRequired(false)
        .HasMaxLength(255)
        .HasColumnType("nvarchar");

        builder.Property(p => p.BLider)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.MesIni)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.NomMesInicio)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.MesFin)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.NomMesFin)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.InAno)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.BEstado)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.BEstadoLider)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.Resultado)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.Nivel)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.DescNivel)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("ntext");

        builder.Property(p => p.Color)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TotComp)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.CompEva)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.CalifComp)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.PromComp)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.NivelComp)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ColorComp)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PorEvaComp)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.TotIndi)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.IndiEva)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.PorEvaIndi)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.CalifIndi)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.PromIndi)
        .IsRequired(false)
        .HasColumnType("float");

        builder.Property(p => p.NivelIndi)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.ColorIndi)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.TipoEvaluacion)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.MotivoAnalisis)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.Concepto)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.JustificacionConcepto)
        .IsRequired(false)
        .HasMaxLength(4000)
        .HasColumnType("nvarchar");

        builder.Property(p => p.UsuarioCreacion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCreacion)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.UsuarioModificacion)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaModificacion)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.FechaInicio)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.FechaFin)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.FechaVencimiento)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.DiaVencimiento)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.ColorVencimiento)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaEnvio)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.DuracionContrato)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.TipoValoracionId)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.EvaIndis)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.IdPadre)
        .IsRequired(false)
        .HasColumnType("bigint");

        builder.HasOne(p => p.PrgramacionMasivaObj)
        .WithMany(p => p.TBL_com_ProgEvaluacion)
        .HasForeignKey(p => p.IdPrgramacionEvaluacion)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.PesoIndi)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PesoCompe)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");


        builder.Property(p => p.ResultadoADI)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TipoNivelEstrategico)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.NivelCargo)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.PesoTec)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");


        builder.Property(p => p.PromTec)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.ColorComt)
        .IsRequired(true)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NivelComt)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NumeroMapaTalento)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.ColorMapaTalento)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.CajaMapaTalento)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.PesoTIG)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PromTIG)
        .IsRequired(false)
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.ColorTIG)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NivelTIG)
        .IsRequired(false)
        .HasMaxLength(150)
        .HasColumnType("nvarchar");

        builder.Property(p => p.FechaCierre)
        .IsRequired(false)
        .HasColumnType("Datetime");

        builder.Property(p => p.ObservacionGeneral)
       .IsRequired(false)
        .HasMaxLength(4000)
       .HasColumnType("nvarchar");

        builder.Property(p => p.NumeroMapaTalentoM)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.ColorMapaTalentoM)
        .IsRequired(false)
        .HasMaxLength(200)
        .HasColumnType("nvarchar");

        builder.Property(p => p.CajaMapaTalentoM)
        .IsRequired(false)
        .HasMaxLength(200)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Mod_MT)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.Obs_Mod_MapaT)
        .IsRequired(false)
        .HasColumnType("nvarchar")
        .HasMaxLength(4000);

        builder.Property(p => p.UbicacionMD)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.UbicacionMD_M)
        .IsRequired(false)
        .HasColumnType("int");

        builder.Property(p => p.ColorNivelM)
        .IsRequired(false)
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.NivelM)
        .IsRequired(false)
        .HasMaxLength(50)
        .HasColumnType("nvarchar");

        builder.Property(p => p.Obs_Nivel_MapaD)
        .IsRequired(false)
        .HasColumnType("nvarchar")
        .HasMaxLength(4000);

        builder.Property(p => p.Mod_MD)
        .IsRequired(false)
        .HasColumnType("bit");

        builder.Property(p => p.UsuarioModNivel)
        .IsRequired(false)
        .HasColumnType("nvarchar")
        .HasMaxLength(50);
    }
}
