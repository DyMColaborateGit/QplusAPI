using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using App.Models.Models.Tipo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class HistorialCambiosRepository : IHistorialCambiosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public HistorialCambiosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Historial_cambiosModels>> GetHistorialesDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            try
            {
                var query = _context.Historial_Cambios.AsNoTracking()
                    .Where(x => x.IdDocumento == IdDocumento && x.EmpresaId == EmpresaId);
                var orderedQuery = query.OrderByDescending(x => x.NumeroActualizacion);
                var objResult = await query.ToListAsync();

                return _mapper.Map<List<Historial_cambiosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetHistorialesDocumentoByDocumentoId", ex, IdDocumento + "/" + EmpresaId.ToString());
                throw;
            }
        }
    }
}
