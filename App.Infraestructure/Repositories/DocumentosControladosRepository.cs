using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblDoc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class DocumentosControladosRepository : IDocumentosControladosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public DocumentosControladosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TBL_doc_DocumentosModels>> DocumentosList(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_doc_Documentos.AsNoTracking()
                .Where(x => x.EmpresaId == EmpresaId)
                .ToListAsync();
                return _mapper.Map <List<TBL_doc_DocumentosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("DocumentosList", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<PagedResult<ResponseTBL_doc_DocumentosModels>> GetListadoDocumentosFiltrosVista(int IdArea, int proceso_doc, string CodigoDoc, int IdProducto, int IdTipo, string Estado,
          int NivelSeguridad, int EmpresaId, int InIdSistema, int Usuario, string NombreDoc, int userId, int ElaboradoPor, int RevisadoPor, int AprobadoPor, string EstadoProceso, int Pagina, int pageSize,
          int codigoCargo)
        {

            //if (CodigoDoc == null)
            //    CodigoDoc = "T";

            //if (NombreDoc == null)
            //    NombreDoc = "T";

            if (string.IsNullOrEmpty(CodigoDoc))
            {
                CodigoDoc = "T";
            }

            if (string.IsNullOrEmpty(NombreDoc))
            {
                NombreDoc = "T";
            }

            try
            {
                var query = _context.TBL_doc_Documentos.AsNoTracking()
                    .Where(x => x.Estado == Estado && x.ProcesosObj.Estado == EstadoProceso && x.NivelSeguridad <= NivelSeguridad);

                if (proceso_doc != -1)
                {
                    query = query.Where(p => p.proceso_doc == proceso_doc);
                }
                if (IdArea != -1)
                {
                    query = query.Where(p => p.IdArea == IdArea);
                }
                if (CodigoDoc != "" && CodigoDoc != "T")
                {
                    query = query.Where(p => p.CodigoDoc == CodigoDoc);
                }
                if (NombreDoc != "" && NombreDoc != "T")
                {
                    query = query.Where(p => p.NombreDoc.ToLower().Contains(NombreDoc.ToLower()));
                }
                if (IdProducto != 0)
                {
                    query = query.Where(p => p.IdProducto == IdProducto);
                }
                if (IdTipo != -1)
                {
                    query = query.Where(p => p.IdTipo == IdTipo);
                }
                if (EmpresaId != -1)
                {
                    query = query.Where(p => p.EmpresaId == EmpresaId);
                }
                if (InIdSistema != -1)
                {
                    query = query.Where(p => p.InIdSistema == InIdSistema);
                }
                if (ElaboradoPor != -1)
                {
                    query = query.Where(p => p.ElaboradoPor == ElaboradoPor);
                }
                if (RevisadoPor != -1)
                {
                    query = query.Where(p => p.RevisadoPor == RevisadoPor);
                }
                if (AprobadoPor != -1)
                {
                    query = query.Where(p => p.AprobadoPor == AprobadoPor);
                }

                var orderedQuery = query.OrderByDescending(x => x.DocumentoId);
                var totalRegistros = await query.CountAsync();
                // Aplicar la paginación

                var pagedQuery = orderedQuery.Skip((Pagina - 1) * pageSize).Take(pageSize).Include(x => x.ProcesosObj);
                var objResult = await pagedQuery.ToListAsync();

                //return _mapper.Map<List<ResponseTBL_doc_DocumentosModels>>(objResult);

                var data = _mapper.Map<List<ResponseTBL_doc_DocumentosModels>>(objResult);

                return new PagedResult<ResponseTBL_doc_DocumentosModels>
                {
                    Data = data,
                    TotalRegistros = totalRegistros
                };
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListadoDocumentosFiltrosVista", ex, IdArea + "/" + proceso_doc + "/" + "/" + CodigoDoc + "/" + IdProducto + "/" + IdTipo + "/" + Estado + "/" + NivelSeguridad +
                    "/" + EmpresaId + "/" + InIdSistema + "/" + Usuario + "/" + NombreDoc + "/" + userId + "/" + ElaboradoPor + "/" + RevisadoPor + "/" + AprobadoPor + "/" + EstadoProceso + "/" + codigoCargo);
                throw;
            }
        }
        public class PagedResult<T>
        {
            public List<T> Data { get; set; }
            public int TotalRegistros { get; set; }
        }
    }
}
