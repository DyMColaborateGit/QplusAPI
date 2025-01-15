using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblMast;
using System;


namespace App.logic.Services
{
    public class ZonasService: IZonasService
    {
        private readonly IZonasRepository _zonasRepository;

        public ZonasService(IZonasRepository zonasRepository) 
        {
            _zonasRepository = zonasRepository;
        }

        public async Task<List<TBL_mast_ZonasModels>> GetListZonas(int EmpresaId)
        {
            return await _zonasRepository.ListZonas(EmpresaId);
        }
    }
}
