using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface ITotalIndEstCorporativosRepository
{
    Task<TBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativos(int EmpresaId, int Anio);
    Task<GeneralTBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativospeso(int EmpresaId, int Anio);
    //Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(int EvaluacionId, int EmpresaId);
    Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId);
}
