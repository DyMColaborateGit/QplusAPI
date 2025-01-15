using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories;

public interface IEncabezadoRepository
{
    Task<ResponseEncabezadoEvaModels> ObjEncabezadoEvaluacionByEvaluacionId(long EvaluacionId);
    Task<Tbl_com_EncabezadoEvaModels> ObjConsultEncabezadoEvaluacionByEvaluacionId(long EvaluacionId);
}
