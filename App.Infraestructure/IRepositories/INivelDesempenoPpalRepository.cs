using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface INivelDesempenoPpalRepository
    {
        Task<List<TBL_com_NivelesDesempenoPpalModels>> ListNivelDesempenoPpal(int EmpresaId, int InAnio);
    }
}
