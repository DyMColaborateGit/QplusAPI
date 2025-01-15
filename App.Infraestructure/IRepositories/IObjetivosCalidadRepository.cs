using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface IObjetivosCalidadRepository
{
    Task<List<Tbl_ind_ObjetivosCalidadModels>> ListObjetivosCalidadByEmpresaId(int EmpresaId);
}
