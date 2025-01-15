using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblMast;
using System;

namespace App.logic.Services;

public class OficinasService: IOficinasService
{
    private readonly IOficinasRepository _oficinasRepository;

    public OficinasService(IOficinasRepository oficinasRepository)
    {
        _oficinasRepository = oficinasRepository;
    }

    public async Task<List<TBL_mast_OficinasModels>> GetListOficinasZonaId(int EmpresaId, int ZonaId)
    {
        return await _oficinasRepository.ListObjOficinas(EmpresaId, ZonaId);
    }
}
