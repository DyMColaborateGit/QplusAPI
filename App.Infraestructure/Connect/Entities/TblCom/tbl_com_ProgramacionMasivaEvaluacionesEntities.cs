using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ProgramacionMasivaEvaluacionesEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdProgramacion { get; set; }
    public long CedulaEvaluado { get; set; }
    public int ClaveCargoEvaluado { get; set; }
    public int CodigoDireccion { get; set; }
    public int CodigoGerencia { get; set; }
    public int CodigoNivelCompetencia { get; set; }
    public int MesProgramado { get; set; }
    public long CedulaEvaluador { get; set; }
    public int Anio { get; set; }
    public int MesInicio { get; set; }
    public int MesFin { get; set; }
    public DateTime FechaProgramacion { get; set; }
    public long UsuarioProgramacion { get; set; }
    public ICollection<tbl_com_ProgEvaluacionEntities>? TBL_com_ProgEvaluacion { get; set; }
}
