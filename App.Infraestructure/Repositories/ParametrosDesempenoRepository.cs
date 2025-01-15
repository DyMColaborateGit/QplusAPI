using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories;

public class ParametrosDesempenoRepository: IParametrosDesempenoRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ParametrosDesempenoRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_ParametrosDesempenoModels> ObjParametrosDesempenoByParametroId(long ParametroId)
    {
        try
        {
            var objResult = await _context.TBL_com_ParametrosDesempeno.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ParametroId == ParametroId);
            return _mapper.Map<TBL_com_ParametrosDesempenoModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjParametrosDesempenoByParametroId", ex, ParametroId.ToString());
            throw;
        }
    }

    public async Task<TBL_com_ParametrosDesempenoModels> ObjParametrosDesempenoByTipoId(int TipoId, Decimal Valor, int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_com_ParametrosDesempeno.AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId && x.TipoId == TipoId && Valor >= (decimal)x.ValorMin && Valor <= (decimal)x.ValorMax);
            return _mapper.Map<TBL_com_ParametrosDesempenoModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjParametrosDesempenoByTipoId", ex, TipoId.ToString()+"/"+ Valor + "/"+ EmpresaId);
            throw;
        }
    }
}
