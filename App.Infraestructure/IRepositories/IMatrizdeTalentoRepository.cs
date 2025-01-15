using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface IMatrizdeTalentoRepository
    {
       Task<List<ResponseTBL_com_MatrizdeTalentosModels>> ListMatrizdeTalentos(int EmpresaId);

       Task<TBL_com_MatrizdeTalentosModels> CategoriaMatrizdeTalentos(decimal ValorComp, decimal ValorInd, int EmpresaId);
    }
}
