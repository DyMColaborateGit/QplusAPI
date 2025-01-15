using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_NivelesDesempenoPpalEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdNivel { get; set; }

    public int EmpresaId { get; set; }

    public string? Nivel { get; set; }

    public string? ConceptoFinal { get; set; }

    public string? Color { get; set; }

    public int? UbicacionMD { get; set; }

    public int? InAnio { get; set; }
}
