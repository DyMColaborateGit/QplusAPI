using App.Models.Models.TblDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Infraestructure.Repositories.DocumentosControladosRepository;

namespace App.Infraestructure.IRepositories
{
    public interface IDocumentosControladosRepository
    {
        Task<List<TBL_doc_DocumentosModels>> DocumentosList(int EmpresaId);

        Task<PagedResult<ResponseTBL_doc_DocumentosModels>> GetListadoDocumentosFiltrosVista(int IdArea, int proceso_doc, string CodigoDoc, int IdProducto, int IdTipo, string Estado, int NivelSeguridad, 
            int EmpresaId, int InIdSistema, int Usuario, string NombreDoc, int userId, int ElaboradoPor, int RevisadoPor, int AprobadoPor, string EstadoProceso, int Pagina, int pageSize, int codigoCargo);

    }
}
