using NLayer.Negocio;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLayer.Consola.Utilidades;

namespace NLayer.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cliente cliente = new Cliente();
                Copia copia = new Copia();
                Prestamo prestamo = new Prestamo();
                Pelicula pelicula = new Pelicula();

                bool consolaActiva = true;

                while (consolaActiva)
                {
                    DesplegarOpcionesMenu();
                    string opcionMenu = Console.ReadLine();
                    switch (opcionMenu)
                    {
                        case "1":
                            Clientes();
                            string opcionMenuCliente = Console.ReadLine();
                            switch(opcionMenuCliente.ToUpper())
                            {
                                case "A":
                                    ListarClientes();
                                    string opcionMenuListarCliente = Console.ReadLine();
                                    switch (opcionMenuListarCliente)
                                    {
                                        case "1":
                                            TraerTodos(cliente);
                                            break;
                                        case "2":
                                            Console.WriteLine("Detalle el número de registro a buscar: ");
                                            string nroRegistro = Console.ReadLine();
                                            TraerPorRegistro(nroRegistro,cliente);
                                            break;
                                        case "3":
                                            Console.WriteLine("Detalle el número de teléfono a buscar:");
                                            string nroTelefono = Console.ReadLine();
                                            TraerPorTelefono(nroTelefono,cliente); 
                                            break;
                                        case "X":
                                            Console.WriteLine("Volviendo al menú anterior...");
                                            Thread.Sleep(3000);
                                            ListarClientes();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;   
                                case "B":
                                    CrearCliente(cliente);
                                    break;
                                case "C":
                                    NoDisponible();
                                    DesplegarOpcionesMenu();
                                    /*Console.WriteLine("Detalle el id del cliente que desea actualizar:");
                                    string idClienteModificar = Console.ReadLine();
                                    ModificarCliente(idClienteModificar);*/
                                    break;
                                case "D":
                                    NoDisponible();
                                    DesplegarOpcionesMenu();
                                    /*Console.WriteLine("Detalle el id del cliente que desea eliminar:");
                                    string idClienteEliminar = Console.ReadLine();
                                    EliminarCliente(idClienteEliminar);*/
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    DesplegarOpcionesMenu();
                                    break;
                            }
                            break;
                        case "2":
                            Prestamos();
                            string opcionMenuPrestamos = Console.ReadLine();
                            switch (opcionMenuPrestamos.ToUpper())
                            {
                                case "A":
                                    ListarPrestamos(prestamo);
                                    break;
                                case "B":
                                    CargarPrestamo(prestamo);
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    DesplegarOpcionesMenu();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "3":
                            // Peliculas
                            break;
                        case "4":
                            // Copias
                            break;
                        case "5":
                            // Reportes
                            break;
                        case "X":
                            consolaActiva = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error general.");
            }

        }

        static void DesplegarOpcionesMenu()
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

        static void Clientes()
        {
            Console.WriteLine("Seleccionó la opción clientes. ¿Qué desea hacer?");
            Console.WriteLine("     A) Ver clientes");
            Console.WriteLine("     B) Crear nuevo cliente");
            Console.WriteLine("     C) Modificar cliente existente");
            Console.WriteLine("     D) Eliminar cliente");
            Console.WriteLine("     X: Volver al menú anterior");
        }

        static void ListarClientes()
        {
            Console.WriteLine("Detalle la forma en que desea ver a los clientes");
            Console.WriteLine("     1. Ver todos los clientes");
            Console.WriteLine("     2. Ver todos los clientes de un número de registro");
            Console.WriteLine("     3. Buscar cliente por número de teléfono");
            Console.WriteLine("     X: Volver al menú anterior");
        }


        static void Prestamos()
        {
            Console.WriteLine("Seleccionó la opción préstamos. ¿Qué desea hacer?");
            Console.WriteLine("     A) Ver préstamos vigentes");
            Console.WriteLine("     B) Cargar nuevo préstamo");
            Console.WriteLine("     X: Volver al menú anterior");
        }



        static void NoDisponible()
        {
            Console.WriteLine("Próximamente estará disponible esta funcionalidad. ¡Te invitamos a volver al menú anterior para explorar las otras opciones!");
            Thread.Sleep(5000);
        }



        static void TraerTodos(Cliente clientes)
        {
            List<Cliente> lst = clientes.[Metodo]; //agregar método para obtener todos los clientes (y validaciones en el caso que no haya ningún cliente)
            foreach (Cliente item in lst)
            {
                Console.WriteLine(item);
            }
        }

        static void TraerPorRegistro(string nroRegistro,Cliente clientes)
        {
            List<Cliente> lst = clientes.[Metodo](nroRegistro); //agregar método para obtener todos los clientes con un número de registro (y validaciones del nro ingresado)
            foreach (Cliente item in lst)
            {
                Console.WriteLine(item);
            }
        }

        static void TraerPorTelefono (string nroTelefono, Cliente clientes)
        {
            List<Cliente> lst = clientes.[Metodo](nroTelefono); //agregar método para obtener todos los clientes con un número de teléfono (y validaciones del nro ingresado)
            foreach (Cliente item in lst)
            {
                Console.WriteLine(item);
            }
        }



        static void CrearCliente(Cliente cliente)
        {
            Console.WriteLine("Ingresar el DNI del cliente:");
            string dniCliente = Console.ReadLine();
            //método para validar que no exista un cliente cargado con el mismo DNI, que tenga la cantidad de caracteres correspondientes y que se ingresen solo números.
            //sugerencia: en el caso que exista un cliente cargado con el mismo DNI, mostrar nombre y apellido de la persona.

            Console.WriteLine("Ingresar el nombre del cliente:");
            string nombreCliente = Console.ReadLine();
            //método para validar que no se inserte cualquier cosa

            Console.WriteLine("Ingresar el apellido del cliente:");
            string apellidoCliente = Console.ReadLine();
            //método para validar que no se inserte cualquier cosa

            Console.WriteLine("Ingresar la fecha de nacimiento del cliente:");
            string fechaNacCliente = Console.ReadLine();
            //método para validar que el cliente sea mayor a determinada edad o que la fecha no sea mayor al día de hoy

            Console.WriteLine("Ingresar el teléfono del cliente:");
            string telefonoCliente = Console.ReadLine();
            //método para validar que no se inserte cualquier cosa

            Console.WriteLine("Ingresar el domicilio del cliente:");
            string domicilioCliente = Console.ReadLine();

            Console.WriteLine("Ingresar el mail del cliente:");
            string mailCliente = Console.ReadLine();

            
            //pasar por parámetro al método de la capa de negocio los valores para crear el cliente 
            //Cliente clienteNuevo = new Cliente((DateTime.Now).ToString(), true, "", "890191", nombreCliente, apellidoCliente, domicilioCliente, int.Parse(dniCliente), telefonoCliente,mailCliente, DateTime.Parse(fechaNacCliente));

            //Console.WriteLine("¡El cliente se ha creado correctamente! Detalles:");
            //Console.WriteLine(clienteNuevo);

        }

        static void ListarPrestamos(Prestamo prestamos)
        {
            List<Prestamo> lst = prestamos.[Metodo]; //agregar método para obtener todos los préstamos (y validaciones en el caso que no haya ninguno)
            foreach (Prestamo item in lst)
            {
                Console.WriteLine(item);
            }
        }


        static void CargarPrestamo(Prestamo prestamo)
        {
            Console.WriteLine("Ingresar el DNI del cliente al cual se le va a realizar el préstamo:");
            string dniPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que el cliente exista
            // 2. Que el cliente no supere determinada cantidad de préstamos
            // 3. Que se haya ingresado un número

            Console.WriteLine("Ingresar el id de la película:");
            string idPeliculaPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que exista la película
            // 2. Que existan copias disponibles de esta película
            // 3. Que se haya ingresado un número

            Console.WriteLine("Ingresar el número de copia a prestar:");
            string nroCopiaPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que exista la copia
            // 2. Que se haya ingresado un número

            Console.WriteLine("¿La fecha del préstamo es la fecha de hoy? Responder con Si o No");
            string respuestaFechaPrestamo = Console.ReadLine().ToUpper();


            Console.WriteLine("Ingresar la cantidad de días del préstamo:");
            string plazoPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que no supere determinada cantidad de días
            // 2. Que se haya ingresado un número
           

        }

    }
}
