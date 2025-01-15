using App.Models.Models.TblMast;
using System;

namespace App.Infraestructure.IRepositories;

public interface IOficinasRepository
{
    Task<TBL_mast_OficinasModels> ObjOficinas(int CodigoOf, int EmpresaId);

    Task<List<TBL_mast_OficinasModels>> ListObjOficinas(int EmpresaId, int ZonaId);
}
