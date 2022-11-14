using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NLayer.Negocio.ValidacionesNegocio
{
    internal class ValidacionCliente
    {
        ////Validar que no se pueda dar de alta a un cliente si ya se registro ese dni
        public bool ValidarDNI(int dni)
        {
            
            foreach (var item in ClienteNegocio.TraerLista())
            {
                if (dni == item.Dni)
                    return true;
            }

            return false;
        }
        ////Validar que no se pueda dar de alta a un cliente si ya se registro ese mail
        //bool flag1 = ValidarMail(cliente.Mail);



    }
}
