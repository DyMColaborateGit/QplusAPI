using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Entities.TblCom;
public class tbl_com_ProgEvaluacionEntities
{
    [Key]
    public int InIdEvaluacion { get; set; }
    public int? InTipoInstrumento { get; set; }
    public int? InIdTipoNorma { get; set; }
    public string? NomNorma { get; set; }
    public long? InIdEvaluador { get; set; }
    public string? NomEvaluador { get; set; }
    public int? CodigoCargo { get; set; }
    [ForeignKey(nameof(InIdEvaluado))]
    public long? InIdEvaluado { get; set; }
    public scp_FuncionariosEntities? EvaluadObj { get; set; }
    public string? NomEvaluado { get; set; }
    public bool? BLider { get; set; }
    public int? MesIni { get; set; }
    public string? NomMesInicio { get; set; }
    public int? MesFin { get; set; }
    public string? NomMesFin { get; set; }
    public int? InAno { get; set; }
    public bool? BEstado { get; set; }
    public bool? BEstadoLider { get; set; }
    public double? Resultado { get; set; }
    public string? Nivel { get; set; }
    public string? DescNivel { get; set; }
    public string? Color { get; set; }
    public int? TotComp { get; set; }
    public int? CompEva { get; set; }
    public double? CalifComp { get; set; }
    public double? PromComp { get; set; }
    public string? NivelComp { get; set; }
    public string? ColorComp { get; set; }
    public double? PorEvaComp { get; set; }
    public int? TotIndi { get; set; }
    public int? IndiEva { get; set; }
    public double? PorEvaIndi { get; set; }
    public double? CalifIndi { get; set; }
    public double? PromIndi { get; set; }
    public string? NivelIndi { get; set; }
    public string? ColorIndi { get; set; }
    public int? TipoEvaluacion { get; set; }
    public int? MotivoAnalisis { get; set; }
    public bool? Concepto { get; set; }
    public string? JustificacionConcepto { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public int? DiaVencimiento { get; set; }
    public string? ColorVencimiento { get; set; }
    public DateTime? FechaEnvio { get; set; }
    public int? DuracionContrato { get; set; }
    public int? TipoValoracionId { get; set; }
    public bool? EvaIndis { get; set; }
    public long? IdPadre { get; set; }
    [ForeignKey(nameof(IdPrgramacionEvaluacion))]
    public int? IdPrgramacionEvaluacion { get; set; }
    public tbl_com_ProgramacionMasivaEvaluacionesEntities? PrgramacionMasivaObj { get; set; }
    public decimal? PesoIndi { get; set; }
    public decimal? PesoCompe { get; set; }
    public decimal? ResultadoADI { get; set; }
    public int? TipoNivelEstrategico { get; set; }
    public int? NivelCargo { get; set; }
    public decimal? PesoTec { get; set; }
    public decimal? PromTec { get; set; }
    public string? ColorComt { get; set; }
    public string? NivelComt { get; set; }
    public int? NumeroMapaTalento { get; set; }
    public string? ColorMapaTalento { get; set; }
    public string? CajaMapaTalento { get; set; }
    public decimal? PesoTIG { get; set; }
    public decimal? PromTIG { get; set; }
    public string? ColorTIG { get; set; }
    public string? NivelTIG { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? ObservacionGeneral { get; set; }
    public int? NumeroMapaTalentoM { get; set; }
    public string? ColorMapaTalentoM { get; set; }
    public string? CajaMapaTalentoM { get; set; }
    public bool? Mod_MT { get; set; }
    public string? Obs_Mod_MapaT { get; set; }
    public int? UbicacionMD { get; set; }
    public int? UbicacionMD_M { get; set; }
    public string? ColorNivelM { get; set; }
    public string? NivelM { get; set; }
    public string? Obs_Nivel_MapaD { get; set; }
    public bool? Mod_MD { get; set; }
    public string? UsuarioModNivel {  get; set; }

    public ICollection<tbl_com_EncabezadoEvaEntities>? TBL_com_EncabezadoEva { get; set; }
    public ICollection<tbl_com_ResultadosEvaluacionEntities>? TBL_com_ResultadosEvaluacion { get; set; }
    public ICollection<tbl_com_ResultadosEntities>? TBL_com_Resultados { get; set; }
    public ICollection<tbl_com_ResultadosEvaIndicadoresEntities>? TBL_com_ResultadosEvaIndicadores { get; set; }

}
