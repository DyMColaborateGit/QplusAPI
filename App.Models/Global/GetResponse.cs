using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Global;

public class GetResponse<T> where T : class
{
    public int StatusCode { get; set; }
    public bool Result { get; set; }
    public string? Message { get; set; }
    public string CathError { get; set; }
    public T? Data { get; set; }
    public GetResponse()
    {
       this.StatusCode = (int)HttpCodes.OK;
    }
}

public enum HttpCodes
{
    OK = 200,
    BADREQUEST = 400,
    UNAUTHORIZED = 401,
    NOTFOUND = 404,
    ERRORHTTP = 405,
    ERROR = 500,
    INTERNALERROR = 501,
}

public class HttpCodesMessage
{
    public string OK = "Resultados con exito.";
    public string ADREQUEST = "Se a realizado una petición incorrecta.";
    public string UNAUTHORIZED = "Usuario no autorizado.";
    public string NOTFOUND = "El recurso que se solicito no existe.";
    public string ERRORHTTP = "Este metodo HTTP no está permitido.";
    public string ERROR = "Error en el servidor. Comunicate con los administradores de la Plataforma";
    public string INTERNALERROR = "Error en el servidor. Comunicate con los administradores de la Plataforma";
}


public static class GetAplications
{
    public const string Valoracion = "Valoracion del desempeño";
}



