using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_NivelesdeDesempenoEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id_Nivel { get; set; }

    public int EmpresaId { get; set; }

    public string? Nivel { get; set; }

    public string? ComceptoFinal { get; set; }

    public decimal PorcMnin { get; set; }

    public decimal PorcMax { get; set; }

    public string? Color { get; set; }

    public int? NivelCompetencia { get; set; }
    public int? UbicacionMD { get; set; }

}
