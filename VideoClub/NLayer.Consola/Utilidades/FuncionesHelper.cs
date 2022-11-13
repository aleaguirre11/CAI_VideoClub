using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Consola.Utilidades
{
    public class FuncionesHelper
    {
        public string FechaPrestamo(string respuesta)
        {

            if (respuesta.Contains("S"))
            {
                Console.WriteLine("Se toma la fecha de hoy: " + DateTime.Now.ToShortDateString());
                string fechaPrestamo = DateTime.Now.ToShortDateString();
                return fechaPrestamo;
            }
            else
            {
                Console.WriteLine("Ingrese la fecha del préstamo:");
                string fechaPrestamo = DateTime.Parse(Console.ReadLine()).ToShortDateString();
                // método para validar que sea una fecha
                return fechaPrestamo;
            }
        }
    }
}
