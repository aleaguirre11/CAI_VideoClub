using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Consola.Utilidades
{
    internal class ValidacionesHelper
    {
        //Validación booleana para determinar que se haya ingresado algún valor, arrojando una excepción en el caso de que no se haya ingresado nada

        internal static bool ValidarVacio(string ingreso)
        {
            if (string.IsNullOrEmpty(ingreso))
            {
                throw new Exception("No se ingresó ningún valor. Por favor, ingresar el dato solicitado para ejecutar la fucionalidad.");
            }
            
            return false;
        }


        // Validaciones a nivel tipo de dato, arrojando excepciones en el caso que el valor ingresado no pueda convertirse al tipo de dato especificado.

        internal static int ValidarInt(string ingreso)
        {
            int number;

            if (int.TryParse(ingreso, out number) == false)
            {
                throw new Exception("El valor ingresado no es numérico. Por favor, ingresar solamente valores numéricos.");
            }

            return int.Parse(ingreso);
        }


        internal static bool ValidarString(string ingreso)
        {
            if (ingreso.Length < 2)
            {
                throw new Exception("El texto ingresado es demasiado corto. Por favor, revisar el valor detallado.");
            }

            return true;
        }



    }
}
