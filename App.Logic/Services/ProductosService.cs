using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models;
using App.Models.Models.TblDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IProductosRepository _productosRepository;
        public ProductosService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public async Task<List<ProductosModels>> GetListaSubProcesosByIdProcesoActivos(int IdProceso)
        {
            return await _productosRepository.GetListaSubProcesosByIdProcesoActivos(IdProceso);
        }
    }
}
