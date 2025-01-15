using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Helpers
{
    public class GetBackgroundcolorHelpers
    {
        public static string colormapadetalentos(string color)
        {
            string colorimg = "";
            switch (color)
            {
                case "yellow.png"://Amarillo
                    colorimg = "background-color:#ffff00;color:#040404";
                    break;
                case "blue.png"://Azul
                    colorimg = "background-color:#00B0F0;color:#040404";
                    break;
                case "orange.png"://Naranja
                    colorimg = "background-color:#FF8000;color:#040404";
                    break;
                case "red.png"://Rojo
                    colorimg = "background-color:#FF0000;color:#040404";
                    break;
                case "green.png"://Verde
                    colorimg = "background-color:#08953F;color:#040404";
                    break;
                case "white.png"://Blanco
                    colorimg = "background-color:#FFFFFF;color:#040404";
                    break;
                default:
                    colorimg = "background-color:#FFFFFF;color:#040404";
                    break;
            }
            return colorimg;
        }
    }
}
