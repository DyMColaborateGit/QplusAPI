using System;

namespace App.Models.Models.TblCom;

public class TBL_com_NivelesCargoCompModels
{
    public int NivelCargoComId { get; set; }
    public int? CodigoCargo { get; set; }
    public int CompetenciaId { get; set; }
    public int? NivelId { get; set; }
    public int? EmpresaId { get; set; }
    public bool? VisibleEva { get; set; }
}
public class JOINTBL_com_NivelesCargoCompModels
{
    public int NivelCargoComId { get; set; }
    public int? CodigoCargo { get; set; }
    public int CompetenciaId { get; set; }
    public Tbl_com_NormasModels? Normaobj { get; set; }
    public int? NivelId { get; set; }
    public int? EmpresaId { get; set; }
    public bool? VisibleEva { get; set; }
}
