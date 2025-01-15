using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories;

public class EncuestaRepository: IEncuestaRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public EncuestaRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_EncuestaModels> ObjEncuesta(int IdEncuesta)
    {
        try
        {
            var objResult = await _context.TBL_com_Encuesta.AsNoTracking()
                .Where(x => x.IdEncuesta == IdEncuesta)
                .FirstAsync();
            return _mapper.Map< TBL_com_EncuestaModels> (objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjEncuesta", ex, IdEncuesta.ToString());
            throw;
        }
    }

    public async Task<TBL_com_EncuestaModels> UpdateEncuesta(TBL_com_EncuestaModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_Encuesta.FirstOrDefault(x => x.IdEncuesta == ObjUpdate.IdEncuesta);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.IdEncuesta = ObjUpdate.IdEncuesta;
                updateRegistro.EmpresaId = ObjUpdate.EmpresaId;
                updateRegistro.TotalPreguntas = ObjUpdate.TotalPreguntas;
                updateRegistro.PreguntasCalificadas = ObjUpdate.PreguntasCalificadas;
                updateRegistro.Estado = ObjUpdate.Estado;
            }
            #endregion
            await _context.SaveChangesAsync();
            return _mapper.Map<TBL_com_EncuestaModels>(updateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateEncuesta", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }

    }
}
