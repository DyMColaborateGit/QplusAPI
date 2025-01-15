using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_NivelesCompetenciasEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NivelId { get; set; }

    public int EmpresaId { get; set; }

    public int TipoId { get; set; }

    public double ValorMinComp { get; set; }

    public double ValorMaxComp { get; set; }

    public double ValorMinInd { get; set; }

    public double ValorMaxInd { get; set; }

    public double Calificacion { get; set; }

    public string? Nivel { get; set; }

    public string? Color { get; set; }

    public string? Descripcion { get; set; }

    public double? MinDesempeno { get; set; }

    public double? MaxDesempeno { get; set; }

}
