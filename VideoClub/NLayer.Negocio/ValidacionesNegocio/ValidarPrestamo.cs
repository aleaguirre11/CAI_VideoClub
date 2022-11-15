using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NLayer.Negocio.ValidacionesNegocio
{
    internal class ValidarPrestamo
    {
        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            if (!(obj is Prestamo))
                return false;
            
            Prestamo pObj = (Prestamo)obj;

            if (pObj.Abierto != true)
                return false;


            return true;
        }
    }
}
