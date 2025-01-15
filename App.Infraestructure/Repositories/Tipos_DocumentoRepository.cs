using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
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
    public class Tipos_DocumentoRepository : ITipos_DocumentoRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public Tipos_DocumentoRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<tipos_documentoModels>> GetListadoTiposDocumentoEmpresaId(int EmpresaId)
        {
            try
            {
                var objResult = await _context.Tipos_documento.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Estado == true)
                    .OrderBy(x => x.Tipo)
                    .ToListAsync();
                return _mapper.Map<List<tipos_documentoModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListProcesosByempresaIdByEstado", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
