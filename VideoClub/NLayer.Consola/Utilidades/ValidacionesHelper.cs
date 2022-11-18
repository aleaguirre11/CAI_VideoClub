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
            if (string.IsNullOrEmpty(ingreso.Trim()))
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

            if (!ValidarMayorCero(ingreso))
            {
                throw new Exception("El número ingresado es negativo. Por favor, ingresar solamente valores positivos");
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


        private static bool ValidarMayorCero(string ingreso)
        {
            if (int.Parse(ingreso) < 0)
            {
                return false;
            }

            return true;
        }

        internal static bool ValidarStringTel(string ingreso)
        {
            if (ingreso.Length < 10)
            {
                throw new Exception("El teléfono ingresado es demasiado corto. Por favor, revisar el valor detallado.");
            }

            return true;
        }


        internal static bool ValidarStringMail(string ingreso)
        {
            if (!ingreso.Contains("@"))
            {
                throw new Exception("El valor ingresado no corresponde a un email. Por favor, revisar el valor detallado.");
            }

            return true;
        }


        internal static bool ValidarLargoDNI(int dni)
        {
            if(dni<1000000)
            {
                throw new Exception("El DNI ingresado es demasiado chico. Por favor, revisar el valor detallado.");
            }
            else if(dni > 99999999)
            {
                throw new Exception("El DNI ingresado es demasiado grande. Por favor, revisar el valor detallado.");
            }
            else
            {
                return true;
            }
         
        }


        internal static DateTime ValidarFecha (string ingreso)
        {
            DateTime fecha;

            if (!DateTime.TryParse(ingreso,out fecha))
            {
                throw new Exception("El valor ingresado no corresponde a una fecha válida. Por favor, revisar el valor detallado");
            }
            else
            {
                return DateTime.Parse(ingreso);
            }
        }


        internal static int ValidarIdInt(string ingreso)
        {
            int number;

            if (int.TryParse(ingreso, out number) == false)
            {
                throw new Exception("El valor ingresado no es numérico. Por favor, ingresar solamente valores numéricos.");
            }

            if (!ValidarMayorCero(ingreso))
            {
                throw new Exception("No existen números identificadores que sean negativos. Por favor, ingresar solamente valores positivos");
            }

            return int.Parse(ingreso);
        }


        internal static bool ValidarAnio (int anio)
        {
            int anioActual = DateTime.Now.Year;

            if(anio > anioActual)
            {
                throw new Exception("El año ingresado es mayor al año actual. Por favor, revisar el valor ingresado.");
            }
            return true;
        }

        internal static double ValidarDouble(string ingreso)
        {
            double number;

            if (double.TryParse(ingreso, out number) == false)
            {
                throw new Exception("El valor ingresado no es numérico. Por favor, ingresar solamente valores numéricos.");
            }

            if (!ValidarMayorCero(ingreso))
            {
                throw new Exception("El número ingresado es negativo. Por favor, ingresar solamente valores positivos");
            }

            return double.Parse(ingreso);
        }



    }
}
