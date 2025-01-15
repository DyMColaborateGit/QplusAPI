using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblMast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class SistemasGestionService : ISistemasGestionService
    {
        private readonly ISistemasGestionRepository _sistemasGestionRepository;

        public SistemasGestionService(ISistemasGestionRepository sistemasGestionRepository)
        {
            _sistemasGestionRepository = sistemasGestionRepository;
        }

        public async Task<List<TBL_mast_SistemasGestionModels>> GetListaSistemasGestionByEmpresaId(int EmpresaId)
        {
            return await _sistemasGestionRepository.GetListaSistemasGestionByEmpresaId(EmpresaId);
        }
    }
}
