using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using App.Models.Models.TblMast;

namespace App.Models.Models.Share;

public class GetGestEvaluacionModels
{
    public ResponseTbl_com_ProgEvaluacionModels? ObjEvaluacion { get; set; }
    public Tbl_com_EncabezadoEvaModels? ObjEncabezado { get; set; }
    public List<ResponseJoinTbl_com_ResultadosEvaluacionModels>? ObjCompetencias { get; set; }
    public TBL_mast_ZonasModels? Direccion { get; set; }
    public TBL_mast_OficinasModels? Gerencia { get; set; }
    public List<Tbl_com_TxtFormEvaluacionModels>? TextosFormularios { get; set; }
}

public class GetGestIndicadoresEvaluacionModels
{
    public List<JOINTbl_com_ResultadosEvaIndicadoresModels>? IndicadoresGestion { get; set; }
    public List<JOINTbl_com_ResultadosEvaIndicadoresModels>? IndicadoresEstrategicos { get; set; }
    public List<Tbl_ind_ObjetivosCalidadModels>? Objetivos { get; set; }
    public List<TBL_ind_TiposIndicadoresEstrategicosModels>? TiposIndicadoresEstrategicos { get; set; }
    public List<JOINTBL_ind_ResultIndiCoporpModels>? IndicadoresCorporativos { get; set; }
    public string? ViewIndicadores { get; set; }
}


public class GetGestTxtFormEvaluacionModels
{
    public Tbl_com_TxtFormEvaluacionModels? TextCompetencias { get; set; }
    public Tbl_com_TxtFormEvaluacionModels? TextIndicadores { get; set; }
    public Tbl_com_TxtFormEvaluacionModels? TextCompTecnicas { get; set; }
}

public class GetGestVerEvaluacionModels
{
    public List<TBL_com_ConsolidadoDesempenoModels>? ConsolidadoCompetencias { get; set; }
    public List<TBL_com_ConsolidadoDesempenoModels>? ConsolidadoRendimiento { get; set; }
    public TBL_com_TotalesConsolidadoDesempenoModels? TotalIndicadoresGestion { get; set; }
    public List<TBL_com_TotalesConsolidadoDesempenoModels>? TotalIndicadoresEstrategicos { get; set; }
    public GeneralTotalUES? TotalesUesOne { get; set; }
    public GeneralTotalUES? TotalesUesTwo { get; set; }
}
