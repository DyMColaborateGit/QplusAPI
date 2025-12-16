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
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IFuncionariosRepository _funcionariosRepository;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;

    public TotalIndEstCorporativosRepository(ConnectContext context, IMapper mapper, IProgEvaluacionRepository progEvaluacionRepository, IFuncionariosRepository funcionariosRepository, IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository)
    {
        _context = context;
        _mapper = mapper;
        _progEvaluacionRepository = progEvaluacionRepository;
        _funcionariosRepository = funcionariosRepository;
        _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
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
    public async Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(int EvaluacionId, int EmpresaId)
    {
        try
        {
            var progEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            var anioEvaluacion = progEvaluacion.InAno;
            var funcionarioEvaluacion = progEvaluacion.InIdEvaluado;
            var tipoIndi = progEvaluacion.TipoNivelEstrategico;
            decimal peso = 0;

            var funcionario = await _funcionariosRepository.GetObjFuncionarioByIdentificacion((long)funcionarioEvaluacion);
            var empresa = funcionario.EmpresaId;

            if (tipoIndi != 0)
            {
                peso = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(empresa, (int)tipoIndi, 1)).Peso;
            }

            var objResult = await _context.TBL_ind_TotalIndEstCorporativos.AsNoTracking()
                .Where(x => x.Anio == anioEvaluacion && x.Empresaid == EmpresaId)
                .ToListAsync();

            var listaModelos = _mapper.Map<List<GeneralTBL_ind_TotalIndEstCorporativosModels>>(objResult);

            foreach (var item in listaModelos)
            {
                item.Peso = peso;
            }

            return listaModelos;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetListaTotalIndicadoresCorporativos", ex, EvaluacionId + "/" + EmpresaId);
            throw;
        }
    }
}
