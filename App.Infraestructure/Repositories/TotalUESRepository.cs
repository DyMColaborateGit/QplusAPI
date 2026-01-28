

using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class TotalUESRepository : ItotalUESRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IResulDirectorGerentesRepository _resulDirectorGerentesRepository;
    private readonly ITotalAnalisisIndiADIRepository _totalAnalisisIndiADIRepository;

    public TotalUESRepository(ConnectContext context, IMapper mapper, IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository,
        IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository, IResulDirectorGerentesRepository resulDirectorGerentesRepository, ITotalAnalisisIndiADIRepository totalAnalisisIndiADIRepository)
    {
        _context = context;
        _mapper = mapper;
        _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
        _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
        _resulDirectorGerentesRepository = resulDirectorGerentesRepository;
        _totalAnalisisIndiADIRepository = totalAnalisisIndiADIRepository;
    }

    public async Task<GeneralTotalUES> GetTotalAnalisisUES1(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId, int Tipo, int Nivel)
    {
        //Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        GeneralTotalUES TotalUes = new GeneralTotalUES();
        int t = 0;
        long idEVa = 0;
        long cc = 0;
        int tipoIndi = (int)progEvaluacion.TipoNivelEstrategico;
        decimal peso = 100;

        if (tipoIndi != 0)
        {
            peso = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, tipoIndi, 2)).Peso;
        }

        if (Nivel == 1)
        {

            if (Tipo == 1)
            {
                t = 1;
                idEVa = progEvaluacion.InIdEvaluacion;
            }
            if (Tipo == 2)
            {
                t = 2;
                //idEVa = (await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1)).InIdEvaluacion;
                idEVa = (await ObjProgEvaluacionPadre((int)progEvaluacion.IdPadre, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin, EmpresaId, 1, 1)).InIdEvaluacion;
                cc = (int)progEvaluacion.IdPadre;
            }

        }
        if (Nivel != 1)
        {
            if (progEvaluacion.IdPadre == 0)
            {
                t = 1;
                idEVa = progEvaluacion.InIdEvaluacion;
            }
            else
            {
                t = 2;
                //var DataEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1);
                var DataEvaluacion = await ObjProgEvaluacionPadre((int)progEvaluacion.IdPadre, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin, EmpresaId, 1, 1);
                idEVa = DataEvaluacion.InIdEvaluacion;
                cc = (int)progEvaluacion.IdPadre;
            }
            peso = (await _totalAnalisisIndiADIRepository.TotalAnalisisIndicadoresEstrategicosADI(progEvaluacion, EmpresaId))[0].Peso;
        }

        if (t == 1)
        {
            var listInd = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(idEVa, new int[] { 6 }, EmpresaId); ;
            decimal sum = 0;
            foreach (var li in listInd)
            {
                sum += li.Ponderado;
            }


            TotalUes.Total = sum;
            TotalUes.peso = peso;

        }
        else
        {
            decimal res = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin))[0].Resultado;
            TotalUes.Total = res;
            TotalUes.peso = peso;
        }
        return TotalUes;
    }
    public async Task<GeneralTotalUES> GetTotalAnalisisUES2(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId)
    {
        GeneralTotalUES To = new GeneralTotalUES();
        //Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        int tipoIndi = (int)progEvaluacion.TipoNivelEstrategico;
        decimal peso = 100;

        if (tipoIndi != 0)
        {
            peso = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, tipoIndi, 2)).Peso;
        }

        var listInd = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadores(progEvaluacion.InIdEvaluacion);
        decimal sum = 0;
        foreach (var li in listInd)
        {
            sum += li.Ponderado;
        }

        To.Total = sum;
        To.peso = peso;
        return To;
    }

    private async Task<Tbl_com_ProgEvaluacionModels> ObjProgEvaluacionPadre(long InIdEvaluado, int Anio, int MesIni, int MesFin, int EmpresaId, int TipoEvaluacion, int TipoValoracionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion
            .FirstOrDefaultAsync(x => x.InIdEvaluado == InIdEvaluado && x.TipoValoracionId == TipoValoracionId && x.TipoEvaluacion == TipoEvaluacion && x.MesFin == MesFin && x.MesIni == MesIni && x.InAno == Anio);
            return _mapper.Map<Tbl_com_ProgEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjProgEvaluacionPadre", ex, InIdEvaluado + "/" + Anio + "/" + MesIni + "/" + MesFin + "/" + EmpresaId + "/" + TipoEvaluacion + "/" + TipoValoracionId);
            throw;
        }
    }
}
