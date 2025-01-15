using App.Models.Models.TblMast;
using System;

namespace App.Infraestructure.IRepositories;

public interface IZonasRepository
{
    Task<TBL_mast_ZonasModels> ObjZonas(int CodigoZo, int EmpresaId);

    Task<List<TBL_mast_ZonasModels>> ListZonas(int EmpresaId);
}
