using System;

namespace App.Models.Models.TblInd;

public class TBL_ind_TotalIndEstCorporativosModels
{
    public int IdTotal { get; set; }
    public int Empresaid { get; set; }
    public int Anio { get; set; }
    public decimal Total { get; set; }
}

public class GeneralTBL_ind_TotalIndEstCorporativosModels
{
    public int IdTotal { get; set; }
    public int Empresaid { get; set; }
    public int Anio { get; set; }
    public decimal Total { get; set; }
    public decimal Peso { get; set; }
}

public class GeneralTotalUES
{
    public decimal Total { get; set; }
    public decimal peso { get; set; }
}
