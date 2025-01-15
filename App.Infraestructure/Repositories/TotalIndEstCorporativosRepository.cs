using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class TotalIndEstCorporativosRepository: ITotalIndEstCorporativosRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public TotalIndEstCorporativosRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativos(int EmpresaId, int Anio)
    {
        try
        {
            var objResult = await _context.TBL_ind_TotalIndEstCorporativos.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Empresaid == EmpresaId && x.Anio == Anio);
            return _mapper.Map<TBL_ind_TotalIndEstCorporativosModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjTotalIndEstCorporativos", ex, EmpresaId.ToString() + "/" + Anio.ToString());
            throw;
        }
    }

    public async Task<GeneralTBL_ind_TotalIndEstCorporativosModels> ObjTotalIndEstCorporativospeso(int EmpresaId, int Anio)
    {
        try
        {
            var objResult = await _context.TBL_ind_TotalIndEstCorporativos.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Empresaid == EmpresaId && x.Anio == Anio);
            return _mapper.Map<GeneralTBL_ind_TotalIndEstCorporativosModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjTotalIndEstCorporativospeso", ex, EmpresaId.ToString() + "/" + Anio.ToString());
            throw;
        }
    }
}
