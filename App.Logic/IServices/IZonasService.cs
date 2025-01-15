using App.Models.Models.TblMast;
using System;

namespace App.logic.IServices
{
    public interface IZonasService
    {
        Task<List<TBL_mast_ZonasModels>> GetListZonas(int EmpresaId);
    }
}
