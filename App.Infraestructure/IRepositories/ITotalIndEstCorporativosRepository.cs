using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface ITotalIndEstCorporativosRepository
{
    Task<TBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativos(int EmpresaId, int Anio);

    Task<GeneralTBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativospeso(int EmpresaId, int Anio);
}
