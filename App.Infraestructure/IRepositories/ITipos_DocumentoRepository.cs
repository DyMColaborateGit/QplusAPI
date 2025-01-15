using App.Models.Models.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface ITipos_DocumentoRepository
    {
        Task<List<tipos_documentoModels>> GetListadoTiposDocumentoEmpresaId(int EmpresaId);

    }
}
