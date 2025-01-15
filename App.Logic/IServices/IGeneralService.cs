using App.Models.Models.Share;
using System;

namespace App.logic.IServices
{
    public interface IGeneralService
    {
        Task<List<AniosModels>> GetListAnios();
    }
}
