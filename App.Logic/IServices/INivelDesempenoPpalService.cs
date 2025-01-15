using App.Models.Models.TblCom;
using System;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface INivelDesempenoPpalService
{
    Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListNivelDesempenoPpal(int EmpresaId, int InAnio);
    Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListConsolidadoNivelDesempeno(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId);


}
