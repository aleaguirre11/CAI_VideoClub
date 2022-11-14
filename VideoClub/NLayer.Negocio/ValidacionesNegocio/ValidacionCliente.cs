using NLayer.Entidades;
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
            bool flag = false;

            foreach (var item in ClienteNegocio.TraerLista())
            {
                if (dni == item.dni)
                    return item;
            }

            return null;
        }
        ////Validar que no se pueda dar de alta a un cliente si ya se registro ese mail
        //bool flag1 = ValidarMail(cliente.Mail);



    }
}
