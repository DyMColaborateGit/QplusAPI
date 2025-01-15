using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface ITxtFormEvaluacionRepository
{
    Task<Tbl_com_TxtFormEvaluacionModels> ObjTxtFormEvaluacion(int EmpresaId, int Tipotexto, int Tipovaloracion, int InAnio);

    Task<List<Tbl_com_TxtFormEvaluacionModels>> ListTxtFormEvaluacion(int EmpresaId, int Anio);
}
