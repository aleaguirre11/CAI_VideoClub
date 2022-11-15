using NLayer.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocio.ExcepcionesNegocio
{
    internal class MenorDeEdadEx : Exception
    {

        public MenorDeEdadEx() : base("La edad del cliente ingresado es menor a 16.") { }

    }
}
