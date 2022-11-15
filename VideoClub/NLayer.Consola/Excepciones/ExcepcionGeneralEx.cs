using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Consola.Excepciones
{
    internal class ExcepcionGeneralEx : Exception
    {
        public ExcepcionGeneralEx() : base ("Ha ocurrido un error general.") { }
    }
}
