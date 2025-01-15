using System;

namespace App.Models.Models.TblInd;

public class Tbl_ind_MastIndicadoresModels
{
    public int InIdIndicador { get; set; }
    public int EmpresaId { get; set; }
    public int CodigoCargo { get; set; }
    public int InIdProceso { get; set; }
    public string? VcNombreIndicador { get; set; }
    public int InIdResponsable { get; set; }
    public int InIdTipoIndicador { get; set; }
    public int InIdTipoObjetivo { get; set; }
    public int InIdTipoMeta { get; set; }
    public decimal InMetaIndicador { get; set; }
    public int InFrecuencia { get; set; }
    public string? VcNumerador { get; set; }
    public string? VcDenominador { get; set; }
    public int InEstado { get; set; }
    public bool BRevisionGerencial { get; set; }
    public int InIdProducto { get; set; }
    public int InIdSistema { get; set; }
    public string? ObjetivoCargo { get; set; }
    public int ClaseId { get; set; }
    public string? ClaseIndicador { get; set; }
    public string? FuncionarioInd { get; set; }
    public decimal Peso { get; set; }
    public string? Descripcion { get; set; }
    public string? ComoSeCalcula { get; set; }
    public decimal PuntoControl { get; set; }
    public int TipoIndGeneral { get; set; }
    public int IdObjetivo { get; set; }
    public int TipoCalculo { get; set; }
    public int Finalidad { get; set; }
    public string? Unidad { get; set; }
    public string? CodIndicador { get; set; }
    public int IdFuenteEstrategico { get; set; }
    public int TipoIndicadorEstrategico { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public long UsuarioModificacion { get; set; }
    public long UsuarioCreacion { get; set; }
    public bool? BEvaluado { get; set; }
}
