using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories;

public class ProgramacionMasivaEvaluacionesRepository : IProgramacionMasivaEvaluacionesRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    public ProgramacionMasivaEvaluacionesRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> ObjProgramacionMasivaEvaluacionesByIdProgramacion(long IdProgramacion)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgramacionMasivaEvaluacion
            .FirstOrDefaultAsync(x => x.IdProgramacion == IdProgramacion);
            return _mapper.Map<Tbl_com_ProgramacionMasivaEvaluacionesModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjProgramacionMasivaEvaluacionesByIdProgramacion", ex, IdProgramacion.ToString());
            throw;
        }
    }

    public async Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> Update_ProgramacionMasivaEvaluaciones(Tbl_com_ProgramacionMasivaEvaluacionesModels ObjUpdate)
    {
        var UpdateRegistro = _context.TBL_com_ProgramacionMasivaEvaluacion.FirstOrDefault(p => p.IdProgramacion == ObjUpdate.IdProgramacion);
        try
        {
            if (UpdateRegistro != null)
            {
                #region Update
                UpdateRegistro.CedulaEvaluado = ObjUpdate.CedulaEvaluado;
                UpdateRegistro.ClaveCargoEvaluado = ObjUpdate.ClaveCargoEvaluado;
                UpdateRegistro.CodigoDireccion = ObjUpdate.CodigoDireccion;
                UpdateRegistro.CodigoGerencia = ObjUpdate.CodigoGerencia;
                UpdateRegistro.CodigoNivelCompetencia = ObjUpdate.CodigoNivelCompetencia;
                UpdateRegistro.MesProgramado = ObjUpdate.MesProgramado;
                UpdateRegistro.CedulaEvaluador = ObjUpdate.CedulaEvaluador;
                UpdateRegistro.Anio = ObjUpdate.Anio;
                UpdateRegistro.MesInicio = ObjUpdate.MesInicio;
                UpdateRegistro.MesFin = ObjUpdate.MesFin;
                UpdateRegistro.FechaProgramacion = ObjUpdate.FechaProgramacion;
                UpdateRegistro.UsuarioProgramacion = ObjUpdate.UsuarioProgramacion;
                #endregion
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("Update_ProgramacionMasivaEvaluaciones", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<Tbl_com_ProgramacionMasivaEvaluacionesModels>(UpdateRegistro);
    }
}
