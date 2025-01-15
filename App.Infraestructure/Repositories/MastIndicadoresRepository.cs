using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblInd;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace App.Infraestructure.Repositories;

public class MastIndicadoresRepository: IMastIndicadoresRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public MastIndicadoresRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresDeCargo(long FuncionarioInd, long CodCargo, int EmpresaId, long ClaseId, int InEstado)
    {
        try
        {
            var objResult = await _context.TBL_ind_MastIndicadores.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId &&  x.FuncionarioInd == FuncionarioInd.ToString() && x.ClaseId == ClaseId && x.InEstado == InEstado && x.CodigoCargo == CodCargo)
            .ToListAsync();
            return _mapper.Map<List<Tbl_ind_MastIndicadoresModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListMastIndicadoresDeCargo", ex, FuncionarioInd + "/"+ CodCargo + "/" + EmpresaId + "/" + ClaseId + "/" + InEstado);
            throw;
        }
    }

    public async Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresDeCargoDifClass(long FuncionarioInd, long CodCargo, int EmpresaId, long ClaseId, int InEstado)
    {
        try
        {
            var objResult = await _context.TBL_ind_MastIndicadores.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.FuncionarioInd == FuncionarioInd.ToString() && x.ClaseId != ClaseId && x.InEstado == InEstado && x.CodigoCargo == CodCargo)
            .ToListAsync();
            return _mapper.Map<List<Tbl_ind_MastIndicadoresModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListMastIndicadoresDeCargo", ex, FuncionarioInd + "/" + CodCargo + "/" + EmpresaId + "/" + ClaseId + "/" + InEstado);
            throw;
        }
    }


    public async Task<List<Tbl_ind_MastIndicadoresModels>> ListMastIndicadoresEstrategicos(long FuncionarioInd, int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_ind_MastIndicadores.AsNoTracking()
            .Where(x => x.InIdResponsable == FuncionarioInd && x.EmpresaId == EmpresaId &&  x.ClaseId == 4 && x.InEstado == 1 )
            .ToListAsync();
            return _mapper.Map<List<Tbl_ind_MastIndicadoresModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListMastIndicadoresEstrategicos", ex, FuncionarioInd.ToString()+ EmpresaId);
            throw;
        }
    }

    public async Task<Tbl_ind_MastIndicadoresModels> CreateMastIndicadores(Tbl_ind_MastIndicadoresModels ObjUpdate)
    {
        tbl_ind_MastIndicadoresEntities CreateRegistro = _mapper.Map<tbl_ind_MastIndicadoresEntities>(ObjUpdate);
        try
        {
            _context.TBL_ind_MastIndicadores.Add(CreateRegistro);
            await _context.SaveChangesAsync();
            var ObjResult = await _context.TBL_ind_MastIndicadores.OrderByDescending(e => e.InIdIndicador).FirstOrDefaultAsync();
            return _mapper.Map<Tbl_ind_MastIndicadoresModels>(ObjResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CreateResultadosEvaIndicadores", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
    }

}
