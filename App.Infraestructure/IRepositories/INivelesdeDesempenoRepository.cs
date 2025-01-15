using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface INivelesdeDesempenoRepository
{
    Task<TBL_com_NivelesdeDesempenoModels> ObjNivelesdeDesempeno(decimal Resultado, int NivelCargo);
}
