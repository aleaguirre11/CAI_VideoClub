using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocio.ExcepcionesNegocio
{
    internal class ClienteException : Exception
    {
        public ClienteException() : base("Error. Detalle: No se han registrado clientes aun.") { }
    }

    internal class IDClienteInexistenteEx : Exception
    {
        public IDClienteInexistenteEx() : base("Error. Detalle: No existe un cliente con ese ID.") { }
    }

    internal class DNIClienteInexistenteEx : Exception
    {
        public DNIClienteInexistenteEx() : base("Error. Detalle: No existe un cliente con ese DNI.") { }
    }
    internal class MenorDeEdadEx : Exception
    {

        public MenorDeEdadEx() : base("Error. Detalle: La edad del cliente ingresado es menor a 16.") { }

    }

}
