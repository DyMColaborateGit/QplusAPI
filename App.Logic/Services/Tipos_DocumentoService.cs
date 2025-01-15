using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblDoc;
using App.Models.Models.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class Tipos_DocumentoService : ITipos_DocumentoService
    {
        private readonly ITipos_DocumentoRepository _tipos_DocumentoRepository;


        public Tipos_DocumentoService(ITipos_DocumentoRepository tipos_DocumentoRepository)
        {
            _tipos_DocumentoRepository = tipos_DocumentoRepository;
        }

        public async Task<List<tipos_documentoModels>> GetListadoTiposDocumentoEmpresaId(int EmpresaId)
        {
            return await _tipos_DocumentoRepository.GetListadoTiposDocumentoEmpresaId(EmpresaId);
        }
    }
}
