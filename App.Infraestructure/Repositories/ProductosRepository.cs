using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using App.Models.Models.TblDoc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ProductosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductosModels>> GetListaSubProcesosByIdProcesoActivos(int IdProceso)
        {
            try
            {
                var objResult = await _context.Productos.AsNoTracking()
                .Where(x => x.Estado == 1 && x.IdProceso == IdProceso)
                .OrderBy(x => x.Producto)
                .ToListAsync();

                //objResult = objResult.OrderBy(x => x.Proceso?.Trim()).ToList();

                return _mapper.Map<List<ProductosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaSubProcesosByIdProcesoActivos", ex, IdProceso.ToString());
                throw;
            }
        }
    }
}
