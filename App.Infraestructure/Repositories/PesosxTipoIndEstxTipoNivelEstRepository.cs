using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class PesosxTipoIndEstxTipoNivelEstRepository: IPesosxTipoIndEstxTipoNivelEstRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public PesosxTipoIndEstxTipoNivelEstRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TBL_ind_PesosxTipoIndEstxTipoNivelEstModels> ObjPesosxTipoIndEstxTipoNivelEst(int EmpresaId,int TipoNivelEst, int IdtipoIndicadorEst)
        {
            try
            {
                var objResult = await _context.TBL_ind_PesosxTipoIndEstxTipoNivelEst.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Empresaid == EmpresaId && x.IdtipoIndicadorEst == IdtipoIndicadorEst && x.TipoNivelEst == TipoNivelEst);
                return _mapper.Map<TBL_ind_PesosxTipoIndEstxTipoNivelEstModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjPesosxTipoIndEstxTipoNivelEst", ex, EmpresaId.ToString() + "/" + IdtipoIndicadorEst.ToString() + "/" + TipoNivelEst.ToString());
                throw;
            }
        }
    }
}
