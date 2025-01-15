using App.Models.Models.TblCom;
using App.Models.Models.TblInd;

namespace App.Infraestructure.IRepositories;

public interface IPesosxTipoIndxNivelCompRepository
{
    Task<Tbl_ind_PesosxTipoIndxNivelCompModels> ObjPesosxTipoIndxNivelComp(int EmpresaId, int Nivel, int IdTipoIndicador);

    Task<string> StringValueTiposdeindicadores(int EmpresaId, Tbl_com_ProgEvaluacionModels ObjEvaluacion, bool ValuePesoGestion, bool ValuePesoEstretegicos, int IndiEstrategicos);
}
