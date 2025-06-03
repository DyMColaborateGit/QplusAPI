using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface INivelDesempenoPpalRepository
    {
        Task<TBL_com_NivelesDesempenoPpalModels> GetObjNivelDesempenoPpal(int EmpresaId, string Nivel);
        Task<List<TBL_com_NivelesDesempenoPpalModels>> ListNivelDesempenoPpal(int EmpresaId, int InAnio);
    }
}
