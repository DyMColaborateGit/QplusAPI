using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories
{
    public class ActividadesIndicadoresRepository: IActividadesIndicadoresRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ActividadesIndicadoresRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TBL_com_ActividadesIndicadoresModels>> CreateActividadesIndicadoresList(List<TBL_com_ActividadesIndicadoresModels> objCreate)
        {
            try
            {
                await _context.TBL_com_ActividadesIndicadores.AddRangeAsync(_mapper.Map< List<tbl_com_ActividadesIndicadoresEntities>>(objCreate));
                await _context.SaveChangesAsync();

                var objResult = await _context.TBL_com_ActividadesIndicadores.AsNoTracking()
                    .Where(x => x.ActividadId == objCreate[0].ActividadId)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_ActividadesIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("CreateActividadesIndicadoresList", ex, JsonConvert.SerializeObject(objCreate));
                throw;
            }
            
        }
    }
}
