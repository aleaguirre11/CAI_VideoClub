﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocio.ExcepcionesNegocio
{
    internal class PrestamoException : Exception
    {

        public PrestamoException() : base("Error. Detalle: No se han registrado préstamos aun.") { }

    }
    internal class PrestamoLimiteException : Exception
    {

        public PrestamoLimiteException() : base("Error. Detalle: El cliente ingresado hoy tiene 3 préstamos abiertos.") { }

    }
}
