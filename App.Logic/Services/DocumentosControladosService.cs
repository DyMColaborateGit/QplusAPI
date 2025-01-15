using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using App.Models.Models.TblDoc;
using static App.Infraestructure.Repositories.DocumentosControladosRepository;

namespace App.logic.Services
{
    public class DocumentosControladosService : IDocumentosControladosService
    {
        private readonly IDocumentosControladosRepository _documentosControladosRepository;


        public DocumentosControladosService(IDocumentosControladosRepository documentosControladosRepository)
        {
            _documentosControladosRepository = documentosControladosRepository;
        }

        public async Task<List<TBL_doc_DocumentosModels>> GetListDocumentos(int EmpresaId)
        {
            return await _documentosControladosRepository.DocumentosList(EmpresaId);
        }

        public async Task<PagedResult<ResponseTBL_doc_DocumentosModels>> GetListadoDocumentosFiltrosVista(int IdArea, int proceso_doc, string CodigoDoc, int IdProducto, int IdTipo, string Estado,
            int NivelSeguridad, int EmpresaId, int InIdSistema, int Usuario, string NombreDoc, int userId, int ElaboradoPor, int RevisadoPor, int AprobadoPor, string EstadoProceso, int Pagina, int pageSize, int codigoCargo)
        {
            return await _documentosControladosRepository.GetListadoDocumentosFiltrosVista(IdArea, proceso_doc, CodigoDoc, IdProducto, IdTipo, Estado, NivelSeguridad, EmpresaId, 
                InIdSistema, Usuario, NombreDoc, userId, ElaboradoPor, RevisadoPor, AprobadoPor, EstadoProceso, Pagina, pageSize, codigoCargo);
        }
    }
}

