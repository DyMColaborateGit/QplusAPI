using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories;

public class EncuestaPreguntaRepository: IEncuestaPreguntaRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public EncuestaPreguntaRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_EncuestaPreguntaModels> ObjEncuestaPregunta(int IdEncuestaPregunta)
    {
        try
        {
            var ObjResult = await _context.TBL_com_EncuestaPregunta.AsNoTracking()
            .Where(x => x.IdEncuestaPregunta == IdEncuestaPregunta)
            .FirstAsync();
            return _mapper.Map<TBL_com_EncuestaPreguntaModels>(ObjResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjEncuestaPregunta", ex, IdEncuestaPregunta.ToString());
            throw;
        }
    }

    public async Task<List<JOIN_tbl_com_EncuestaPreguntaModels>> ListEncuestaPregunta(int EmpresaId, int IdEncuesta)
    {
        try
        {
            var objResult = await _context.TBL_com_EncuestaPregunta.AsNoTracking()
                .Include(en => en.EncuestaObj)
                .Include(pr => pr.PreguntaObj)
                .Where(x => x.IdEncuesta == IdEncuesta && x.EmpresaId == EmpresaId)
                .ToListAsync();
            return _mapper.Map<List<JOIN_tbl_com_EncuestaPreguntaModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEncuestaPregunta", ex, EmpresaId + "/" + IdEncuesta);
            throw;
        }
    }

    public async Task<TBL_com_EncuestaPreguntaModels> UpdateEncuestaPregunta(TBL_com_EncuestaPreguntaModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_EncuestaPregunta.FirstOrDefault(x => x.IdEncuestaPregunta == ObjUpdate.IdEncuestaPregunta);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.IdEncuesta = ObjUpdate.IdEncuesta;
                updateRegistro.IdPregunta = ObjUpdate.IdPregunta;
                updateRegistro.Resultado = ObjUpdate.Resultado;
            }
            #endregion
            await _context.SaveChangesAsync();
            return _mapper.Map<TBL_com_EncuestaPreguntaModels>(updateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateEncuestaPregunta", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        
    }

}
