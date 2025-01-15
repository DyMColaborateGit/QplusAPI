using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories;

public class ParametrosEmpresasRepository : IParametrosEmpresasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ParametrosEmpresasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SCP_ParametrosEmpresasModels> ObjGetParametroEmpresaByParametroId(int EmpresaId, int ParametroId)
    {
        try
        {
            var objResult = await _context.SCP_ParametrosEmpresas.AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId && x.ParametroId == ParametroId);
            return _mapper.Map<SCP_ParametrosEmpresasModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjGetParametroEmpresaByParametroId", ex, EmpresaId.ToString() + "/" + ParametroId.ToString());
            throw;
        }
    }

    public async Task<List<SCP_ParametrosEmpresasModels>> ListParametrosGenerales(int EmpresaId)
    {
        try
        {
            var objResult = await _context.SCP_ParametrosEmpresas.AsNoTracking()
                .Where(x => x.EmpresaId == EmpresaId)
                .ToListAsync();
            return _mapper.Map<List<SCP_ParametrosEmpresasModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListParametrosGenerales", ex, "");
            throw;
        }
    }

}
