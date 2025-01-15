using System;

namespace App.Models.Models.Scp;

public class SCP_EmpresasTitulosModels
{
    public int CodTitulo { get; set; }

    public int EmpresaId { get; set; }

    public string? Zona { get; set; }

    public string? Oficina { get; set; }

    public string? Acciones { get; set; }

    public string? AccionesCti { get; set; }

    public string? Tareas { get; set; }

    public string? TareasCti { get; set; }

    public string? Auditorias { get; set; }

    public string? AuditoriasCti { get; set; }

    public string? TituloMapaT { get; set; }

    public string? TituloMapaTM { get; set; }

    public string? EjeX_MapaT { get; set; }

    public string? EjeY_MapaT { get; set; }
}
