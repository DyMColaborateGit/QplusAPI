using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblInd;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories;

public class ResulDirectorGerentesRepository: IResulDirectorGerentesRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ResulDirectorGerentesRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TBL_Ind_ResulDirectorGerentesModels>> ListResulDirectorGerentes(long Identificacion, int Anio, int Mesini, int Mesfin)
    {
        try
        {
            var objResult = await _context.TBL_Ind_ResulDirectorGerentes.AsNoTracking()
                .Where(x => x.Identificacion == Identificacion && x.Anio == Anio && x.Mesini == Mesini && x.Mesfin == Mesfin)
                .ToListAsync();
            return _mapper.Map<List<TBL_Ind_ResulDirectorGerentesModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListResulDirectorGerentes", ex, Identificacion + "/"+ Anio +"/"+ Mesini+"/"+ Mesfin);
            throw;
        }
    }

    public async Task<TBL_Ind_ResulDirectorGerentesModels> CreateResulDirectorGerentes(TBL_Ind_ResulDirectorGerentesModels objCreate)
    {
        try
        {
            _context.TBL_Ind_ResulDirectorGerentes.Add(_mapper.Map<tbl_Ind_ResulDirectorGerentesEntities>(objCreate));
            await _context.SaveChangesAsync();
            var ObjResult = await _context.TBL_Ind_ResulDirectorGerentes.OrderByDescending(e => e.Resultadoid).FirstOrDefaultAsync();
            return _mapper.Map<TBL_Ind_ResulDirectorGerentesModels>(ObjResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CreateResulDirectorGerentes", ex, JsonConvert.SerializeObject(objCreate));
            throw;
        }
    }


    public async Task<TBL_Ind_ResulDirectorGerentesModels> UpdateResulDirectorGerentes(TBL_Ind_ResulDirectorGerentesModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_Ind_ResulDirectorGerentes.FirstOrDefault(p => p.Resultadoid == ObjUpdate.Resultadoid);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.Anio = ObjUpdate.Anio;
                updateRegistro.Mesini = ObjUpdate.Mesini;
                updateRegistro.Mesfin = ObjUpdate.Mesfin;
                updateRegistro.Identificacion = ObjUpdate.Identificacion;
                updateRegistro.Resultado = ObjUpdate.Resultado;
                updateRegistro.Tipo = ObjUpdate.Tipo;
            }
            #endregion
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateResulDirectorGerentes", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_Ind_ResulDirectorGerentesModels>(updateRegistro);
    }
}
