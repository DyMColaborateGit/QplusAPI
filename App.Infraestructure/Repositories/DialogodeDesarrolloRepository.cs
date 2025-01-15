using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class DialogodeDesarrolloRepository: IDialogodeDesarrolloRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public DialogodeDesarrolloRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TBL_com_DialogodeDesarrolloModels>> ListDialogodeDesarrollo(int EmpresaId, long FuncionarioId, long Lider, int Anio)
        {
            try
            {
                var objResult = await _context.TBL_com_DialogodeDesarrollo.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.FuncionarioId == FuncionarioId)
                    .ToListAsync();
                List<TBL_com_DialogodeDesarrolloModels> objResultMapper = _mapper.Map<List<TBL_com_DialogodeDesarrolloModels>>(objResult);
                if (Lider != -1)
                {
                    objResultMapper = objResultMapper.Where(p => p.GestorId == Lider).Distinct().ToList<TBL_com_DialogodeDesarrolloModels>();
                }
                if (Anio != -1)
                {
                    objResultMapper = objResultMapper.Where(p => p.CreatedAt.Year == Anio).Distinct().ToList<TBL_com_DialogodeDesarrolloModels>();
                }
                return objResultMapper;
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListDialogodeDesarrollo", ex, EmpresaId + "/" + FuncionarioId + "/"+ Lider + "/" + Anio);
                throw;
            }
        }

        public async Task<TBL_com_DialogodeDesarrolloModels> ObjDialogodeDesarrolloById(int IdDialogo)
        {
            try
            {
                var objResult = await _context.TBL_com_DialogodeDesarrollo.AsNoTracking()
                    .Where(x =>x.IdDialogo == IdDialogo)
                    .FirstOrDefaultAsync();
                TBL_com_DialogodeDesarrolloModels objResultMapper = _mapper.Map<TBL_com_DialogodeDesarrolloModels>(objResult);
                return objResultMapper;
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjDialogodeDesarrolloById", ex, IdDialogo.ToString());
                throw;
            }
        }

    }
}
