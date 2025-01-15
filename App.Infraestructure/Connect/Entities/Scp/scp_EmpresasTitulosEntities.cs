using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.Scp
{
    public class scp_EmpresasTitulosEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodTitulo { get; set; }

        public int EmpresaId { get; set; }

        public required string Zona { get; set; }

        public required string Oficina { get; set; }

        public required string Acciones { get; set; }

        public required string AccionesCti { get; set; }

        public required string Tareas { get; set; }

        public required string TareasCti { get; set; }

        public required string Auditorias { get; set; }

        public required string AuditoriasCti { get; set; }

        public string? TituloMapaT { get; set; }

        public string? TituloMapaTM { get; set; }

        public string? EjeX_MapaT { get; set; }

        public string? EjeY_MapaT { get; set; }
    }
}
