using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models;
using App.Models.Models.T;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class ControlDistribucionService : IControlDistribucionService
    {
        private readonly IControlDistribucionRepository _control_distribucionRepository;


        public ControlDistribucionService(IControlDistribucionRepository control_distribucionRepository)
        {
            _control_distribucionRepository = control_distribucionRepository;
        }

        public async Task<List<Control_distribucionModels>> GetControlDistDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            return await _control_distribucionRepository.GetControlDistDocumentoByDocumentoId(IdDocumento, EmpresaId);
        }
    }
}
