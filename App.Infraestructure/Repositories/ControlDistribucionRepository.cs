using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using App.Models.Models.Scp;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class ControlDistribucionRepository : IControlDistribucionRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ControlDistribucionRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Control_distribucionModels>> GetControlDistDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            try
            {
                var objResult = await _context.Control_Distribucion.AsNoTracking()
                    .Where(x => x.IdDocumento == IdDocumento && x.EmpresaId == EmpresaId)
                    .OrderByDescending(x => x.NumeroActualizacion)
                    .ToListAsync();
                return _mapper.Map<List<Control_distribucionModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetControlDistDocumentoByDocumentoId", ex, IdDocumento + "/" + EmpresaId.ToString());
                throw;
            }
        }
    }
}
