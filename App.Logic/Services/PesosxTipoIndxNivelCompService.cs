using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services;

public class PesosxTipoIndxNivelCompService : IPesosxTipoIndxNivelCompService
{

    private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;


    public PesosxTipoIndxNivelCompService(IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository)
    {
        _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
    }

    public async Task<Tbl_ind_PesosxTipoIndxNivelCompModels> GetPesosxTipoIndxNivelComp(int EmpresaId, int Nivel, int IdTipoIndicador)
    {
        return await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, Nivel, IdTipoIndicador);
    }
}
