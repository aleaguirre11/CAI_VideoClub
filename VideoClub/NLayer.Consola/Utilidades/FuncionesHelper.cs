using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NLayer.Consola.Utilidades
{
    public class FuncionesHelper
    {

        public static void NoDisponible()
        {
            Console.WriteLine("Próximamente estará disponible esta funcionalidad. ¡Te invitamos a volver al menú anterior para explorar las otras opciones!");
            Thread.Sleep(5000);
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
