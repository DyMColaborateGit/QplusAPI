using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class RelGestoresDialogoDesarrolloRepository: IRelGestoresDialogoDesarrolloRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RelGestoresDialogoDesarrolloRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TBL_com_RelGestoresDialogoDesarrolloModels> GetGestoresLiderByFuncionarioByGestorId(int EmpresaId, long FuncionarioId, long GestorId, string TipoRel)
        {
            try
            {
                var objResult = await _context.TBL_com_RelGestoresDialogoDesarrollo.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId && x.FuncionarioId == FuncionarioId && x.GestorId == GestorId && x.TipoRel == TipoRel);
                return _mapper.Map<TBL_com_RelGestoresDialogoDesarrolloModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGestoresLiderByFuncionarioByGestorId", ex, EmpresaId +"/"+ FuncionarioId+"/"+ GestorId+"/"+ TipoRel);
                throw;
            }
        }
    }
}
