using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class FuncionariosRepository : IFuncionariosRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public FuncionariosRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SCP_FuncionariosModels> ObjFuncionarioByEmpresaIdByIdentificacion(int EmpresaId, long Identificacion)
    {
        try
        {
            var objResult = await _context.SCP_Funcionarios.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.Identificacion == Identificacion)
            .FirstOrDefaultAsync();
            return _mapper.Map<SCP_FuncionariosModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjFuncionarioByEmpresaIdByIdentificacion", ex, Identificacion.ToString()+"/"+ EmpresaId.ToString());
            throw;
        }
    }

    public async Task<JOINSCP_FuncionariosModels> ObjJoinFuncionarioByEmpresaIdByIdentificacion(int EmpresaId, long Identificacion)
    {
        try
        {
            var objResult = await _context.SCP_Funcionarios
            .Where(x => x.EmpresaId == EmpresaId && x.Identificacion == Identificacion)
            .FirstOrDefaultAsync();
            var ModeloFuncionario = _mapper.Map<JOINSCP_FuncionariosModels>(objResult);
            ModeloFuncionario.Cargoobj = _mapper.Map <SCP_CargosModels>( _context.SCP_Cargos.Where(c => c.Codigo == ModeloFuncionario.CargoId && c.EmpresaId == EmpresaId).FirstOrDefault());
            return ModeloFuncionario;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjJoinFuncionarioByEmpresaIdByIdentificacion", ex, Identificacion.ToString() + "/" + EmpresaId.ToString());
            throw;
        }
    }

    public async Task<List<SCP_FuncionariosModels>> ListFuncionarioByEmpresaIdByCargoId(int EmpresaId, int CargoId, bool Estado)
    {
        try
        {
            var objResult = await _context.SCP_Funcionarios.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.CargoId == CargoId && x.Estado == Estado)
            .ToListAsync();
            return _mapper.Map<List<SCP_FuncionariosModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListFuncionarioByEmpresaIdByCargoId", ex, EmpresaId.ToString() + "/" + CargoId.ToString()+"/"+ Estado);
            throw;
        }
    }

    public async Task<SCP_FuncionariosModels> ObjFuncionarioByIdentificacion(long Identificacion)
    {
        try
        {
            var objResult = await _context.SCP_Funcionarios.AsNoTracking()
            .Where(x => x.Identificacion == Identificacion)
            .FirstOrDefaultAsync();
            return _mapper.Map<SCP_FuncionariosModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjFuncionarioByIdentificacion", ex, Identificacion.ToString());
            throw;
        }
    }
}
