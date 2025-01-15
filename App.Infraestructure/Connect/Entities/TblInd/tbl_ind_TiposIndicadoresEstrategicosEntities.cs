using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_TiposIndicadoresEstrategicosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    public int? IdTipoIndiEstra { get; set; }

    public int? EmpresaId { get; set; }

    public string? TipoIndicadorEstrategico { get; set; }
}
