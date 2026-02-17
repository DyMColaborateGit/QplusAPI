
using App.Models.Models.Scp;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Http;

namespace App.Models.Models.FileMove
{
    public class FilePdfADIPdiModel
    {
        public string? FileName { get; set; }
        public string? FolderPath { get; set; }
        public string? HeaderHtml { get; set; }
        public string? BodyHtml { get; set; }
        public string? FooterHtml { get; set; }
        public string? Mensaje { get; set; }
        public bool Success { get; set; }
        public string? Status { get; set; }
        public string? mMessage { get; set; }
        public long? Identificacion { get; set; }
        public string? NombreFuncionario { get; set; }
        public Tbl_com_ProgEvaluacionModels? Evaluacion { get; set; }
        public SCP_FuncionariosModels? Funcionario { get; set; }
        public SCP_UsuarioModels? UsuarioLog { get; set; }
        public List<string>? Data { get; set; }
        public List<TextoEvaluacion>? TextosEvaluacion { get; set; }
    }
}
