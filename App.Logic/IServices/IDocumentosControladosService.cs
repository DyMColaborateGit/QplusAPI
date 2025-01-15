

using App.Models.Models.TblCom;
using App.Models.Models.TblDoc;
using static App.Infraestructure.Repositories.DocumentosControladosRepository;

namespace App.logic.IServices
{
    public interface IDocumentosControladosService
    {
        Task<List<TBL_doc_DocumentosModels>> GetListDocumentos(int EmpresaId);

        Task<PagedResult<ResponseTBL_doc_DocumentosModels>> GetListadoDocumentosFiltrosVista(int IdArea, int proceso_doc, string CodigoDoc, int IdProducto, int IdTipo, string Estado,
            int NivelSeguridad, int EmpresaId, int InIdSistema, int Usuario, string NombreDoc, int userId, int ElaboradoPor, int RevisadoPor, int AprobadoPor, string EstadoProceso, int Pagina, int pageSize, int codigoCargo);
            
    }
}
