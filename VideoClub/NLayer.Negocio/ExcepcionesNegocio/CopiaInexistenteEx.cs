using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocio.ExcepcionesNegocio
{
    internal class CopiaInexistenteEx : Exception
    {
        public CopiaInexistenteEx() : base("Error. Detalle: No se han registrado copias aun.") { }
    }
}
