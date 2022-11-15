using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLayer.Negocio;

namespace NLayer.Consola.Utilidades
{
    internal class FuncionesHelper
    {

        internal static void NoDisponible()
        {
            Console.WriteLine("Próximamente estará disponible esta funcionalidad. ¡Te invitamos a volver al menú anterior para explorar las otras opciones!");
            Thread.Sleep(5000);
        }


        internal static int ValidarDNI(string dni, ClienteNegocio cliente)
        {
            if(ValidacionesHelper.ValidarVacio(dni) == false)
            {
                int dniInt = ValidacionesHelper.ValidarInt(dni);
                bool resultado = cliente.ValidarDNI(dniInt);
                if(resultado == false)
                {
                    return dniInt;
                }
                else
                {
                    throw new Exception("Ya existe un cliente cargado con el DNI ingresado.");
                }
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }








        // -------------------------------
        // --------Funciones extra -------
        // --------------------------------
        //
        //public string FechaPrestamo(string respuesta)
        //{

        //    if (respuesta.Contains("S"))
        //    {
        //        Console.WriteLine("Se toma la fecha de hoy: " + DateTime.Now.ToShortDateString());
        //        string fechaPrestamo = DateTime.Now.ToShortDateString();
        //        return fechaPrestamo;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ingrese la fecha del préstamo:");
        //        string fechaPrestamo = DateTime.Parse(Console.ReadLine()).ToShortDateString();
        //        // método para validar que sea una fecha
        //        return fechaPrestamo;
        //    }
        //}

    }
}
