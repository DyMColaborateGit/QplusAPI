using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories;

public interface IAspectosValoracionRepository
{
    Task<bool> ExisteAspectosValoracion(int EmpresaId, int AspectoValoracionId, bool Estado);
}
