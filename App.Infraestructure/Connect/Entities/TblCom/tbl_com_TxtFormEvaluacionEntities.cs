using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_TxtFormEvaluacionEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TextoId { get; set; }

    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }

    public string? Titulo { get; set; }

    public string? Texto { get; set; }

    public int Tipotxt { get; set; }

    public int Anio { get; set; }

    public int TipovaloracionId { get; set; }
}
