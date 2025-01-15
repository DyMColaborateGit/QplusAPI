using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblMast;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories;

public class OficinasRepository: IOficinasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public OficinasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_mast_OficinasModels> ObjOficinas(int CodigoOf, int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_mast_Oficinas.AsNoTracking()
            .FirstOrDefaultAsync(x => x.CodigoOf == CodigoOf && x.EmpresaId == EmpresaId);
            return _mapper.Map<TBL_mast_OficinasModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjOficinas", ex, CodigoOf + "/" + EmpresaId);
            throw;
        }
    }

    public async Task<List<TBL_mast_OficinasModels>> ListObjOficinas(int EmpresaId, int ZonaId)
    {
        try
        {
            var objResult = await _context.TBL_mast_Oficinas.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.Estado == true)
            .OrderBy(x => x.Oficina)
            .ToListAsync();
            if (ZonaId != -1)
            {
                objResult = objResult.Where(x => x.ZonaId == ZonaId).ToList();
            }

            return _mapper.Map<List<TBL_mast_OficinasModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListObjOficinas", ex, EmpresaId + "/" + ZonaId);
            throw;
        }
    }
}
