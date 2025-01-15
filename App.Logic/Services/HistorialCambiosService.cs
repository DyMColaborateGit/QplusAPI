using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models;
using App.Models.Models.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class HistorialCambiosService : IHistorialCambiosService
    {
        private readonly IHistorialCambiosRepository _historialCambiosRepository;


        public HistorialCambiosService(IHistorialCambiosRepository historialCambiosRepository)
        {
            _historialCambiosRepository = historialCambiosRepository;
        }

        public async Task<List<Historial_cambiosModels>> GetHistorialesDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            return await _historialCambiosRepository.GetHistorialesDocumentoByDocumentoId(IdDocumento, EmpresaId);
        }
    }
}
