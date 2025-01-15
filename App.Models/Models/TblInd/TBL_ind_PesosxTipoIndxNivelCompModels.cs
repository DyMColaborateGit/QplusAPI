using System;

namespace App.Models.Models.TblInd;

public class Tbl_ind_PesosxTipoIndxNivelCompModels
{
    public int IdPesosIndiNivel { get; set; }
    public int Empresaid { get; set; }
    public int Nivel { get; set; }
    public int IdtipoIndicador { get; set; }
    public decimal Peso { get; set; }
    public bool VisibleADI { get; set; }
}
