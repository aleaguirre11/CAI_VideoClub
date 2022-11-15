using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NLayer.Consola.Utilidades
{
    internal class MenuHelper
    {
        internal static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("-------------MENU PRINCIPAL-------------");
            Console.WriteLine("");
            Console.WriteLine("Escriba el número de la opción del menú al cual quiere acceder:");
            Console.WriteLine("     1) Clientes");
            Console.WriteLine("     2) Préstamos");
            Console.WriteLine("     3) Películas");
            Console.WriteLine("     4) Copias");
            Console.WriteLine("     5) Reportes");
            Console.WriteLine("     X: Salir del programa");
        }

        internal static void Clientes()
        {
            Console.WriteLine("Seleccionó la opción clientes. ¿Qué desea hacer?");
            Console.WriteLine("     A) Ver clientes");
            Console.WriteLine("     B) Crear nuevo cliente");
            Console.WriteLine("     C) Modificar cliente existente");
            Console.WriteLine("     D) Eliminar cliente");
            Console.WriteLine("     X: Volver al menú anterior");
        }

        internal static void ListarClientes()
        {
            Console.WriteLine("Detalle la forma en que desea ver a los clientes");
            Console.WriteLine("     1. Ver todos los clientes");
            Console.WriteLine("     2. Ver todos los clientes de un número de registro");
            Console.WriteLine("     3. Buscar cliente por número de teléfono");
            Console.WriteLine("     X: Volver al menú anterior");
        }


        internal static void Prestamos()
        {
            Console.WriteLine("Seleccionó la opción préstamos. ¿Qué desea hacer?");
            Console.WriteLine("     A) Ver préstamos vigentes");
            Console.WriteLine("     B) Cargar nuevo préstamo");
            Console.WriteLine("     X: Volver al menú anterior");
        }


        internal static void Peliculas()
        {
            Console.WriteLine("Seleccionó la opción películas. ¿Qué desea hacer?");
            Console.WriteLine("     A) Listar películas cargadas");
            Console.WriteLine("     B) Cargar nueva película");
            Console.WriteLine("     X: Volver al menú anterior");
        }



        internal static void Copias()
        {
            Console.WriteLine("Seleccionó la opción copias. ¿Qué desea hacer?");
            Console.WriteLine("     A) Listar copias cargadas");
            Console.WriteLine("     B) Cargar nueva copia");
            Console.WriteLine("     X: Volver al menú anterior");
        }


        internal static void Reportes()
        {
            Console.WriteLine("Seleccionó la opción reportes. ¿Qué desea hacer?");
            Console.WriteLine("     A) Mostrar los préstamos por cliente");
            Console.WriteLine("     B) Mostrar la cantidad de copias por película");
            Console.WriteLine("     X: Volver al menú anterior");
        }


        internal static void ListarGeneros()
        {
            Console.WriteLine("1. Drama");
            Console.WriteLine("2. Terror");
            Console.WriteLine("3. Suspenso");
            Console.WriteLine("4. Acción");
            Console.WriteLine("5. Comedia");
            Console.WriteLine("6. Ciencia Ficción");
            Console.WriteLine("7. Documental");
            Console.WriteLine("8. Musical");
            Console.WriteLine("9. Infantil");
            Console.WriteLine("10. Otro");
        }




        //Utilizar en el caso que se quiera agregar la opción de listar todas las copias
        //
        //static void ListarCopias()
        //{
        //    Console.WriteLine("Detalle la forma en que desea listar a las copias (1 o 2):");
        //    Console.WriteLine("     1. Ver todas las películas");
        //    Console.WriteLine("     2. Buscar película por su núumero identificador");
        //    Console.WriteLine("     X: Volver al menú anterior");
        //}

        //Utilizar en el caso que se quiera agregar la opción de listar todas las películas
        //
        //static void ListarPeliculas()
        //{
        //    Console.WriteLine("Detalle la forma en que desea listar a las películas (1 o 2):");
        //    Console.WriteLine("     1. Ver todas las películas");
        //    Console.WriteLine("     2. Buscar película por su núumero identificador");
        //    Console.WriteLine("     X: Volver al menú anterior");
        //}


    }
}
