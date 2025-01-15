using App.logic.IServices;
using App.Models.Models.Share;
using System;

namespace App.logic.Services
{
    public class GeneralService: IGeneralService
    {
        public GeneralService()
        {

        }

        public async Task<List<AniosModels>> GetListAnios()
        {
            List<AniosModels> lista = new List<AniosModels>();

            int anioIni = DateTime.Today.Year - 5;
            int anioFin = DateTime.Today.Year + 2;

            for (int i = anioIni; i <= anioFin; i++)
            {
                AniosModels dA = new AniosModels();
                dA.IdAnio = i;
                dA.Anio = i.ToString();

                lista.Add(dA);
            }

            return lista;
        }
    }
}
