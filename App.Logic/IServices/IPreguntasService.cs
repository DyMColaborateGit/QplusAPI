using App.Models.Models.TblAud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface IPreguntasService
{
    Task<List<TBL_aud_preguntasModels>> GetListPreguntas(int IdPregunta);
    Task<TBL_aud_preguntasModels> PostCrearPreguntas(TBL_aud_preguntasModels ObjCreate, int EmpresaId);
    Task<string> DeletePreguntas(TBL_aud_preguntasModels ObjModificar);
}
