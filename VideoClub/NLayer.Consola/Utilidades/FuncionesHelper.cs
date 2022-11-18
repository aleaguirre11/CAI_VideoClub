using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLayer.Negocio;
using NLayer.Consola.Excepciones;

namespace NLayer.Consola.Utilidades
{
    internal class FuncionesHelper
    {

        internal static void NoDisponible()
        {
            Console.WriteLine("Próximamente estará disponible esta funcionalidad. ¡Te invitamos a volver al menú anterior para explorar las otras opciones!");
            Thread.Sleep(5000);
        }


        internal static int ValidarCargaDNI(string dni) //, ClienteNegocio cliente)
        {
            if(ValidacionesHelper.ValidarVacio(dni) == false)
            {
                int dniInt = ValidacionesHelper.ValidarInt(dni);
                bool resultadoLargoDNI = ValidacionesHelper.ValidarLargoDNI(dniInt);
                //bool resultadoExiste = cliente.ValidarDNI(dniInt);
                if(resultadoLargoDNI) //&&  resultadoExiste == false)
                {
                    return dniInt;
                }
                else
                {
                    throw new Exception("Ya existe un cliente cargado con el DNI ingresado.");
                }
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }

        internal static string ValidarTexto(string texto)
        {
            
            if(ValidacionesHelper.ValidarVacio(texto) == false && ValidacionesHelper.ValidarString(texto) && int.TryParse(texto, out int textoInt)==false)
            {
                return texto;
            }

            throw new Exception("El texto ingresado no cumple con los requisitos establecidos.");
        }


        internal static string ValidarTextoTel(string telefono)
        {
            if (ValidacionesHelper.ValidarVacio(telefono) == false && ValidacionesHelper.ValidarStringTel(telefono))
            {
                return telefono;
            }

            throw new Exception("El teléfono ingresado no cumple con los requisitos establecidos.");
        }

        internal static string ValidarMail(string mail) //, ClienteNegocio cliente)
        {
            if (ValidacionesHelper.ValidarVacio(mail) == false)
            {
                bool resultadoString = ValidacionesHelper.ValidarStringMail(mail);
                //bool resultadoExiste = cliente.ValidarMail(mail);
                if (resultadoString) // && resultadoExiste == false)
                {
                    return mail;
                }
                else
                {
                    throw new Exception("Ya existe un cliente cargado con el mail ingresado.");
                }
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }

        internal static DateTime ValidarFechaNacimiento(string fechaNacCliente) //, ClienteNegocio cliente)
        {
            if (ValidacionesHelper.ValidarVacio(fechaNacCliente) == false)
            {
                DateTime fechaNac = ValidacionesHelper.ValidarFecha(fechaNacCliente);
                return fechaNac;
                //bool resultadoEdad = cliente.ValidarEdad(fechaNac);
                /*
                if (resultadoEdad)
                {
                    return fechaNac;
                }
                else
                {
                    throw new Exception("El cliente no puede ser ingresado ya que no cumple con los requisitos de edad establecidos.");
                }*/
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }


        internal static int ValidarID(string id)
        {
            if (ValidacionesHelper.ValidarVacio(id) == false)
            {
                int idInt = ValidacionesHelper.ValidarIdInt(id);
                return idInt;
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }

        internal static int ValidarBusquedaDNI(string dni) //, ClienteNegocio cliente)
        {
            if (ValidacionesHelper.ValidarVacio(dni) == false)
            {
                int dniInt = ValidacionesHelper.ValidarInt(dni);
                bool resultadoLargoDNI = ValidacionesHelper.ValidarLargoDNI(dniInt);
                //bool resultadoExiste = cliente.ValidarDNI(dniInt);
                if (!resultadoLargoDNI) //&& resultadoExiste == true)
                {
                    throw new Exception("El largo del DNI ingresado no sigue con los parámetros establecidos. Por favor, revisar el valor ingresado.");
                }
                else
                {
                    return dniInt;
                }
                /*else
                {
                    throw new Exception("No se han registrado clientes con ese DNI aún.");
                }*/
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }

        internal static int ValidarNumero (string numero)
        {
            if (ValidacionesHelper.ValidarVacio(numero) == false)
            {
                int numeroInt = ValidacionesHelper.ValidarInt(numero);
                return numeroInt;
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }


        internal static int ValidarAnio (string anio)
        {
            if (ValidacionesHelper.ValidarVacio(anio) == false)
            {
                int anioInt = ValidacionesHelper.ValidarInt(anio);
                bool resultadoAnio = ValidacionesHelper.ValidarAnio(anioInt);
                if (!resultadoAnio)
                {
                    throw new Exception("El año ingresado es mayor al año actual. Por favor, revisar el valor ingresado.");
                }
                else
                {
                    return anioInt;
                }
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
        }


        internal static double ValidarPrecio (string precio)
        {
            if (ValidacionesHelper.ValidarVacio(precio) == false)
            {
                double precioDouble = ValidacionesHelper.ValidarDouble(precio);
                return precioDouble;
            }
            else
            {
                throw new Exception("Ha ocurrido un error general.");
            }
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
