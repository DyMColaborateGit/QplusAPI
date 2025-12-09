
namespace App.Models.Models.TblCom;

public class TBL_com_SeguimientoActividadesModels
{
    public int InIdSeguimiento { get; set; }
    public int InIdActividadPIM { get; set; }
    public DateTime DtFechaSeguimiento { get; set; }
    public DateTime DtFechaReal { get; set; }
    public string? VcSeguimiento { get; set; }
    public string? UsuarioSeguimiento { get; set; }
}
