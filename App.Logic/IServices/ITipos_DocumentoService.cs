using App.Models.Models.TblMast;
using App.Models.Models.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface ITipos_DocumentoService
    {
        Task<List<tipos_documentoModels>> GetListadoTiposDocumentoEmpresaId(int EmpresaId);

    }
}
