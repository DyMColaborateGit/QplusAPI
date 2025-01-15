using App.Models.Models.TblMast;
using System;

namespace App.logic.IServices;

public interface IOficinasService
{
    Task<List<TBL_mast_OficinasModels>> GetListOficinasZonaId(int EmpresaId, int ZonaId);
}
