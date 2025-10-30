
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using App.Models.Models.TblCom;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class RiesgosRepository : IRiesgosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RiesgosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Riesgos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRiesgos", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int ProcesoId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Riesgos.AsNoTracking()
                .Where(x => x.ProcesoId == ProcesoId)
                .OrderBy(x => x.Codigo)
                .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaCodigoRiesgoByProcesoId", ex, ProcesoId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgosFiltros(int EmpresaId, DateTime? FechaInicio, DateTime? FechaFin, int ProcesoId, string Codigo, int SubprocesoId, int ClaseId, int IdAgente)
        {
            try
            {
                var query = _context.TBL_rgp_Riesgos
                    .AsNoTracking()
                    .Include(x => x.EvaluacionRObj)
                    .AsQueryable();

                if (EmpresaId != -1)
                {
                    query = query.Where(x => x.EmpresaId == EmpresaId);
                }
                if (FechaInicio.HasValue)
                {
                    query = query.Where(p =>
                        p.EvaluacionRObj != null &&
                        p.EvaluacionRObj.Fecha.Year >= FechaInicio.Value.Year
                    );
                }
                if (FechaFin.HasValue)
                {
                    query = query.Where(p =>
                        p.EvaluacionRObj != null &&
                        p.EvaluacionRObj.Fecha.Year <= FechaFin.Value.Year
                    );
                }
                if (ProcesoId != -1)
                {
                    query = query.Where(p => p.ProcesoId == ProcesoId);
                }
                if (!string.IsNullOrEmpty(Codigo))
                {
                    query = query.Where(p => p.Codigo.ToLower().Contains(Codigo.ToLower()));
                }
                if (SubprocesoId != -1)
                {
                    query = query.Where(p => p.SubprocesoId == SubprocesoId);
                }
                if (ClaseId != -1)
                {
                    query = query.Where(p => p.ClaseId == ClaseId);
                }
                if (IdAgente != -1)
                {
                    query = query.Where(p => p.IdAgente == IdAgente);
                }

                // 3. ORDENA Y EJECUTA LA CONSULTA
                var objResult = await query.OrderBy(p => p.Codigo).Distinct().ToListAsync();

                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRiesgosFiltros", ex, $"{EmpresaId}/{FechaInicio}/{FechaFin}/{ProcesoId}/{Codigo}/{SubprocesoId}/{ClaseId}/{IdAgente}");
                throw;
            }
        }
    }
}
