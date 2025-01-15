using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_NivelesCargoCompEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int NivelCargoComId { get; set; }
    public int? CodigoCargo { get; set; }
    [ForeignKey(nameof(CompetenciaId))]
    public int CompetenciaId { get; set; }
    public tbl_com_NormasEntities? Normaobj { get; set; }
    public int? NivelId { get; set; }
    public int? EmpresaId { get; set; }
    public bool? VisibleEva { get; set; }
}
