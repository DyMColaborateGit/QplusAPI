using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class PesosxTipoIndxNivelCompRepository: IPesosxTipoIndxNivelCompRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public PesosxTipoIndxNivelCompRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Tbl_ind_PesosxTipoIndxNivelCompModels> ObjPesosxTipoIndxNivelComp(int EmpresaId, int Nivel, int IdTipoIndicador)
    {
        try
        {
            var objResult = await _context.TBL_ind_PesosxTipoIndxNivelComp.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Empresaid == EmpresaId && x.Nivel == Nivel && x.IdtipoIndicador == IdTipoIndicador);
            return _mapper.Map<Tbl_ind_PesosxTipoIndxNivelCompModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjPesosxTipoIndxNivelComp", ex, EmpresaId.ToString()+"/"+ Nivel.ToString()+"/"+ IdTipoIndicador.ToString());
            throw;
        }
    }

    public async Task<string> StringValueTiposdeindicadores(int EmpresaId, Tbl_com_ProgEvaluacionModels ObjEvaluacion,bool ValuePesoGestion, bool ValuePesoEstretegicos, int IndiEstrategicos)
    {
        string v = "";
        if (ValuePesoGestion)
        {
            v = "g";
        }

        if (ValuePesoEstretegicos)
        {
            v = "e";
        }

        if (ValuePesoGestion && ValuePesoEstretegicos)
        {
            if (IndiEstrategicos == 0 && (int)ObjEvaluacion.NivelCargo == 2)
            {
                v = "d";
            }
            else if (IndiEstrategicos == 0 && (int)ObjEvaluacion.NivelCargo == 100)
            {
                v = "d";
            }
            else if (IndiEstrategicos == 0 && (int)ObjEvaluacion.NivelCargo == 1 && (int)ObjEvaluacion.TipoNivelEstrategico == 1)
            {
                v = "g";
            }
            else
            {
                v = "d";
            }
        }
        return v;
    }
}
