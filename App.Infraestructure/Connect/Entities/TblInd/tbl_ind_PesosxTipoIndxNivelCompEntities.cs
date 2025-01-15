using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_PesosxTipoIndxNivelCompEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdPesosIndiNivel { get; set; }
    public int Empresaid { get; set; }
    public int Nivel { get; set; }
    public int IdtipoIndicador { get; set; }
    public decimal Peso { get; set; }
    public bool VisibleADI { get; set; }
}
