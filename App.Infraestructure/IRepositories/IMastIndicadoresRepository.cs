using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface IMastIndicadoresRepository
{
    Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresDeCargo(long FuncionarioInd, long CodCargo, int EmpresaId, long ClaseId, int InEstado);

    Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresDeCargoDifClass(long FuncionarioInd, long CodCargo, int EmpresaId, long ClaseId, int InEstado);

    Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresEstrategicos(long FuncionarioInd, int EmpresaId);

    Task<Tbl_ind_MastIndicadoresModels> CreateMastIndicadores(Tbl_ind_MastIndicadoresModels ObjUpdate);
}
