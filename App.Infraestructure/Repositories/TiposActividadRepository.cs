using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
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
    public class TiposActividadRepository: ITiposActividadRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public TiposActividadRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TBL_com_TiposActividadModels>> ListTiposActividadByCtegoriaIdEstado(int EmpresaId, int CategoriaId, bool Estado)
        {
            try
            {
                var objResult = await _context.TBL_com_TiposActividad.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.InIdCategoria == CategoriaId && x.BEstado == Estado)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_TiposActividadModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListTiposActividadByCtegoriaIdEstado", ex, EmpresaId + "/" + CategoriaId+"/"+ Estado);
                throw;
            }
        }
    }
}
