using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblDoc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace App.Infraestructure.Repositories
{
    public class ProcesoRepository: IProcesoRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ProcesoRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SCP_ProcesosModels>> ListProcesosByempresaIdByEstado(int EmpresaId, string Estado)
        {
            try
            {
                var objResult = await _context.SCP_Procesos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Estado == Estado)
                    .OrderBy(x => x.Proceso)
                    .ToListAsync();
                return _mapper.Map<List<SCP_ProcesosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListProcesosByempresaIdByEstado", ex, EmpresaId + "/" + Estado);
                throw;
            }
        }

        public async Task<List<SCP_ProcesosModels>> GetListaProcesosEstadoByEmpresaIdByMacroproId(int EmpresaId, int Id_Area, string Estado)
        {
            try
            {
                var query = _context.SCP_Procesos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId);

                if (Id_Area != -1)
                {
                    query = query.Where(p => p.Id_Area == Id_Area);
                }

                if (Estado != "" && Estado != null)
                {
                    query = query.Where(p => p.Estado.Trim() == Estado);
                }


                query = query.OrderBy(x => x.Proceso);
                var objResult = await query.ToListAsync();

                return _mapper.Map<List<SCP_ProcesosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaProcesosEstadoByEmpresaIdByMacroproId", ex, EmpresaId + "/" + Id_Area + "/" + Estado);
                throw;
            }
        }

    }
}
