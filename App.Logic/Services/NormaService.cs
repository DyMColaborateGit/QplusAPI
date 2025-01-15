using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class NormaService: INormaService
    {
        private readonly INormaRepository _normaRepository;
        private readonly INivelesCargoCompRepository _nivelesCargoCompRepository;
        public NormaService(INormaRepository normaRepository, INivelesCargoCompRepository nivelesCargoCompRepository) 
        {
            _normaRepository = normaRepository;
            _nivelesCargoCompRepository = nivelesCargoCompRepository;
        }

        public async Task<List<JOINTBL_com_NivelesCargoCompModels>> GetListNormasJoinNivelesCargoComp(int EmpresaId, int CargoId)
        {
            return await _nivelesCargoCompRepository.ListNivelesCargoCompByCargoId(EmpresaId, CargoId);
        }

        public async Task<List<Tbl_com_NormasModels>> GetListNormasByEstado(int EmpresaId, bool Estado)
        {
            return await _normaRepository.ListNormasByEstado(EmpresaId, Estado);
        }
    }
}
