

using App.Infraestructure.Connect;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using AutoMapper;

namespace App.Infraestructure.Repositories;

public class TotalUESRepository : ItotalUESRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IResulDirectorGerentesRepository _resulDirectorGerentesRepository;

    public TotalUESRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GeneralTotalUES> GetTotalAnalisisUES1(long EvaluacionId, int EmpresaId, int Tipo, int Nivel)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        GeneralTotalUES TotalUes = new GeneralTotalUES();
        int t = 0;
        long idEVa = 0;
        long cc = 0;
        int tipoIndi = (int)ObjEvaluacion.TipoNivelEstrategico;
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
                idEVa = EvaluacionId;
            }
            if (Tipo == 2)
            {
                t = 2;
                idEVa = (await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1)).InIdEvaluacion;
                cc = (int)ObjEvaluacion.IdPadre;
            }

        }
        if (Nivel != 1)
        {
            if (ObjEvaluacion.IdPadre == 0)
            {
                t = 1;
                idEVa = EvaluacionId;
            }
            else
            {
                t = 2;
                var DataEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1);
                idEVa = DataEvaluacion.InIdEvaluacion;
                cc = (int)ObjEvaluacion.IdPadre;
            }
            peso = (await TotalAnalisisIndicadoresEstrategicos(EvaluacionId, EmpresaId))[0].Peso;
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
            decimal res = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin))[0].Resultado;
            TotalUes.Total = res;
            TotalUes.peso = peso;
        }
        return TotalUes;
    }
}
