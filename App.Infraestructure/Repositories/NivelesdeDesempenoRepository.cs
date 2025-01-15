using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace App.Infraestructure.Repositories;

public class NivelesdeDesempenoRepository: INivelesdeDesempenoRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public NivelesdeDesempenoRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_NivelesdeDesempenoModels> ObjNivelesdeDesempeno(decimal Resultado, int NivelCargo)
    {
        try
        {
            var objResult = await _context.TBL_com_NivelesdeDesempeno.AsNoTracking()
            .FirstOrDefaultAsync(x => x.PorcMnin <= Resultado && x.PorcMax >= Resultado && x.NivelCompetencia == NivelCargo);
            return _mapper.Map<TBL_com_NivelesdeDesempenoModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjNivelesdeDesempeno", ex, Resultado +"/"+ NivelCargo);
            throw;
        }
    }
}
