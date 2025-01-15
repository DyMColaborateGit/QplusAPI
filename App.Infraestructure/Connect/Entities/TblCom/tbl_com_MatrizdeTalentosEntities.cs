using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_MatrizdeTalentosEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodTalento { get; set; }

    public int EmpresaId { get; set; }

    public required string NombreCaja { get; set; }

    public required string Descripcion { get; set; }

    public int NumeroCaja { get; set; }

    public decimal PorcMaxC { get; set; }

    public decimal PorcMinC { get; set; }

    public decimal PorcMaxI { get; set; }

    public decimal PorcMinI { get; set; }

    public int CodMatrix { get; set; }

    public required string Color { get; set; }

    public bool Estado { get; set; }

    public long UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
