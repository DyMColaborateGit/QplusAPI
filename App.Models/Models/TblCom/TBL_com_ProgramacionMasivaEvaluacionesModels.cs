using App.Models.Models.TblMast;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Models.TblCom;

public class Tbl_com_ProgramacionMasivaEvaluacionesModels
{
    public int IdProgramacion { get; set; }
    public long CedulaEvaluado { get; set; }
    public int ClaveCargoEvaluado { get; set; }
    public int CodigoDireccion { get; set; }
    public int CodigoGerencia { get; set; }
    public int CodigoNivelCompetencia { get; set; }
    public int MesProgramado { get; set; }
    public long CedulaEvaluador { get; set; }
    public int Anio { get; set; }
    public int MesInicio { get; set; }
    public int MesFin { get; set; }
    public DateTime FechaProgramacion { get; set; }
    public long UsuarioProgramacion { get; set; }
}

public class ResponseTbl_com_ProgramacionMasivaEvaluacionesModels
{
    public int IdProgramacion { get; set; }
    public long CedulaEvaluado { get; set; }
    public int ClaveCargoEvaluado { get; set; }

    [ForeignKey(nameof(CodigoDireccion))]
    public int CodigoDireccion { get; set; }
    public TBL_mast_ZonasModels? ZonaObj { get; set; }

    [ForeignKey(nameof(CodigoGerencia))]
    public int CodigoGerencia { get; set; }
    public TBL_mast_OficinasModels? OficinaObj { get; set; }
    public int CodigoNivelCompetencia { get; set; }
    public int MesProgramado { get; set; }
    public long CedulaEvaluador { get; set; }
    public int Anio { get; set; }
    public int MesInicio { get; set; }
    public int MesFin { get; set; }
    public DateTime FechaProgramacion { get; set; }
    public long UsuarioProgramacion { get; set; }
}
