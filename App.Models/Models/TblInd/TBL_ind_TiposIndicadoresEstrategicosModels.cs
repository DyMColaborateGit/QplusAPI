using System;

namespace App.Models.Models.TblInd;

public class TBL_ind_TiposIndicadoresEstrategicosModels
{
    public int Id { get; set; }

    public int? idTipoIndiEstra { get; set; }

    public int? empresaId { get; set; }

    public string? tipoIndicadorEstrategico { get; set; }
}
