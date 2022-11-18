using NLayer.Negocio;
using NLayer.Entidades;
using NLayer.Consola.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLayer.Consola.Excepciones;
using NLayer.Entidades.Enums;

namespace NLayer.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClienteNegocio cliente = new ClienteNegocio();
                CopiaNegocio copia = new CopiaNegocio();
                PrestamoNegocio prestamo = new PrestamoNegocio();
                PeliculaNegocio pelicula = new PeliculaNegocio();

                bool consolaActiva = true;

                while (consolaActiva)
                {
                    MenuHelper.DesplegarOpcionesMenu();
                    string opcionMenu = Console.ReadLine().Trim();
                    switch (opcionMenu)
                    {
                        case "1":
                            MenuHelper.Clientes();
                            string opcionMenuCliente = Console.ReadLine().Trim();
                            switch(opcionMenuCliente.ToUpper())
                            {
                                case "A":
                                    MenuHelper.ListarClientes();
                                    string opcionMenuListarCliente = Console.ReadLine().Trim();
                                    switch (opcionMenuListarCliente)
                                    {
                                        case "1":
                                            CliTraerTodos(cliente);
                                            break;
                                        case "2":
                                            Console.WriteLine("Detalle el número de registro a buscar: ");
                                            string nroRegistro = Console.ReadLine().Trim();
                                            CliTraerPorRegistro(nroRegistro,cliente);
                                            break;
                                        case "3":
                                            Console.WriteLine("Detalle el número de teléfono a buscar:");
                                            string nroTelefono = Console.ReadLine().Trim();
                                            CliTraerPorTelefono(nroTelefono,cliente); 
                                            break;
                                        case "X":
                                            Console.WriteLine("Volviendo al menú anterior...");
                                            Thread.Sleep(3000);
                                            MenuHelper.ListarClientes();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;   
                                case "B":
                                    CrearCliente(cliente);
                                    break;
                                case "C":
                                    FuncionesHelper.NoDisponible();
                                    MenuHelper.DesplegarOpcionesMenu();
                                    /*Console.WriteLine("Detalle el id del cliente que desea actualizar:");
                                    string idClienteModificar = Console.ReadLine();
                                    ModificarCliente(idClienteModificar);*/
                                    break;
                                case "D":
                                    FuncionesHelper.NoDisponible();
                                    MenuHelper.DesplegarOpcionesMenu();
                                    /*Console.WriteLine("Detalle el id del cliente que desea eliminar:");
                                    string idClienteEliminar = Console.ReadLine();
                                    EliminarCliente(idClienteEliminar);*/
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    MenuHelper.DesplegarOpcionesMenu();
                                    break;
                            }
                            break;
                        case "2":
                            MenuHelper.Prestamos();
                            string opcionMenuPrestamos = Console.ReadLine().Trim();
                            switch (opcionMenuPrestamos.ToUpper())
                            {
                                case "A":
                                    Console.WriteLine("Ingrese el número identificador de la película para la cual desea ver los préstamos:");
                                    string idPeliculaPrestamo = Console.ReadLine().Trim();
                                    ListarPrestamos(idPeliculaPrestamo,prestamo);
                                    break;
                                case "B":
                                    CargarPrestamo(prestamo, cliente);
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    MenuHelper.DesplegarOpcionesMenu();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "3":
                            MenuHelper.Peliculas();
                            string opcionMenuPeliculas = Console.ReadLine().Trim();
                            switch (opcionMenuPeliculas.ToUpper())
                            {
                                case "A":
                                    Console.WriteLine("Ingrese el número identificador de la película que desea visualizar:");
                                    string idPelicula = Console.ReadLine().Trim();
                                    ListarPelicula(idPelicula, pelicula);
                                    break;
                                case "B":
                                    CargarPelicula(pelicula);
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    MenuHelper.DesplegarOpcionesMenu();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "4":
                            MenuHelper.Copias();
                            string opcionMenuCopia = Console.ReadLine().Trim();
                            switch (opcionMenuCopia.ToUpper())
                            {
                                case "A":
                                    Console.WriteLine("Ingrese el número identificador de la película que desea visualizar:");
                                    string idPelicula = Console.ReadLine().Trim();
                                    ListarCopia(idPelicula, copia);
                                    break;
                                case "B":
                                    CargarCopia(copia);
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    MenuHelper.DesplegarOpcionesMenu();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "5":
                            MenuHelper.Reportes();
                            string opcionMenuReportes = Console.ReadLine().Trim();
                            switch (opcionMenuReportes.ToUpper())
                            {
                                case "A":
                                    MenuHelper.ReportePrestamos();
                                    string opcionMenuReportesPrestamo = Console.ReadLine().Trim();
                                    switch (opcionMenuReportesPrestamo)
                                    {
                                        case "1":
                                            Console.WriteLine("Ingrese el número de documento del cliente:");
                                            string dniCliente = Console.ReadLine().Trim();
                                            PrestamosPorDNICliente(dniCliente, prestamo, cliente);
                                            break;
                                        case "2":
                                            Console.WriteLine("Ingrese el número identificador del cliente:");
                                            string idCliente = Console.ReadLine().Trim();
                                            PrestamosPorIDCliente(idCliente, prestamo, cliente);
                                            break;
                                        case "X":
                                            Console.WriteLine("Volviendo al menú anterior...");
                                            Thread.Sleep(3000);
                                            MenuHelper.ReportePrestamos();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "B":
                                    Console.WriteLine("Ingrese el número identificador de la película:");
                                    string idPelicula = Console.ReadLine().Trim();
                                    CopiasPorPelicula(idPelicula, copia);
                                    break;
                                case "X":
                                    Console.WriteLine("Volviendo al menú anterior...");
                                    Thread.Sleep(3000);
                                    MenuHelper.DesplegarOpcionesMenu();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "X":
                            consolaActiva = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ExcepcionGeneralEx)
            {
                Console.WriteLine(ExcepcionGeneralEx.Message);
            }

        }





        static void CliTraerTodos(ClienteNegocio clientes)
        {
            List<Cliente> lst = clientes.TraerLista();
            foreach (Cliente item in lst)
            {
                Console.WriteLine(item);
            }
        }

        static void CliTraerPorRegistro(string nroRegistro,ClienteNegocio clientes)
        {

            bool nroRegistroValido = ValidacionesHelper.ValidarVacio(nroRegistro);

            if (nroRegistroValido)
            {
                List<Cliente> lst = clientes.TraerPorRegistro(nroRegistro); 
                foreach (Cliente item in lst)
                {
                    Console.WriteLine(item);
                }
            }

        }

        static void CliTraerPorTelefono (string nroTelefono, ClienteNegocio clientes)
        {

            bool nroTelefonoValido = ValidacionesHelper.ValidarVacio(nroTelefono);

            if (nroTelefonoValido)
            {
                List<Cliente> lst = clientes.TraerPorTelefono(nroTelefono); 
                foreach (Cliente item in lst)
                {
                    Console.WriteLine(item);
                }
            }

        }



        static void CrearCliente(ClienteNegocio cliente)
        {
            Console.WriteLine("Ingresar el DNI del nuevo cliente:");
            string dniCliente = Console.ReadLine();
            int dniClienteValidado = FuncionesHelper.ValidarCargaDNI(dniCliente, cliente);
            

            Console.WriteLine("Ingresar el nombre del nuevo cliente:");
            string nombreCliente = Console.ReadLine();
            string nombreClienteValidado = FuncionesHelper.ValidarTexto(nombreCliente);

            Console.WriteLine("Ingresar el apellido del nuevo cliente:");
            string apellidoCliente = Console.ReadLine();
            string apellidoClienteValidado = FuncionesHelper.ValidarTexto(apellidoCliente);

            Console.WriteLine("Ingresar la fecha de nacimiento del nuevo cliente (con el formato dd/mm/aaaa):");
            string fechaNacCliente = Console.ReadLine();
            DateTime fechaNacClienteValidada = FuncionesHelper.ValidarFechaNacimiento(fechaNacCliente,cliente);

            Console.WriteLine("Ingresar el teléfono del nuevo cliente:");
            string telefonoCliente = Console.ReadLine();
            string telefonoClienteValidado = FuncionesHelper.ValidarTextoTel(telefonoCliente);

            Console.WriteLine("Ingresar el domicilio del nuevo cliente:");
            string domicilioCliente = Console.ReadLine();
            string domicilioClienteValidado = FuncionesHelper.ValidarTexto(domicilioCliente);

            Console.WriteLine("Ingresar el mail del nuevo cliente:");
            string mailCliente = Console.ReadLine();
            string mailClienteValidado = FuncionesHelper.ValidarMail(mailCliente, cliente);

            cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", nombreClienteValidado, apellidoClienteValidado, domicilioClienteValidado, dniClienteValidado, telefonoClienteValidado, mailClienteValidado, fechaNacClienteValidada);
            Console.WriteLine("¡El cliente se ha creado correctamente! Detalles:");
            Console.WriteLine(cliente);

        }



        static void ListarPrestamos(string idPelicula,PrestamoNegocio prestamos)
        {
            //validar que el idPelicula sea un int
            int idValidado = FuncionesHelper.ValidarID(idPelicula);

            List<Prestamo> p = prestamos.TraerPorIdPelicula(idValidado); 
            foreach (Prestamo item in p)
            {
                Console.WriteLine(item);
            }
        }


        static void CargarPrestamo(PrestamoNegocio prestamo, ClienteNegocio cliente)
        {
            Console.WriteLine("Ingresar el DNI del cliente al cual se le va a realizar el préstamo:");
            string dniPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que el cliente exista ---> en TraerIdPorDNI
            // 2. Que el cliente no supere determinada cantidad de préstamos --> en el alta
            // 3. Que se haya ingresado un número --> en funciones/validaciones helper 

            // convertir dniPrestamo a int para pasar al método de la capa de negocio
            int dniClienteValidado = FuncionesHelper.ValidarBusquedaDNI(dniPrestamo, cliente);
            int idClientePrestamo = cliente.TraerIdPorDNI(dniClienteValidado);


            Console.WriteLine("Ingresar el número de copia a prestar:");
            string nroCopiaPrestamo = Console.ReadLine();
            int nroCopiaValidado = FuncionesHelper.ValidarID(nroCopiaPrestamo);
            //método para validar:
            // 1. Que exista la copia
            // 2. Que la copia esté disponible
            // 3. Que se haya ingresado un número


            prestamo.AltaPrestamo(true, nroCopiaValidado, idClientePrestamo);
            Console.WriteLine("¡El préstamo se ha cargado correctamente! Detalles:");
            Console.WriteLine(prestamo);

        }


        static void ListarPelicula(string idPelicula, PeliculaNegocio pelicula)
        {
            //validar que el idPelicula sea un int
            int idValidado = FuncionesHelper.ValidarID(idPelicula);

            Pelicula p = pelicula.TraerPorId(idValidado); 
            Console.WriteLine(p);
        }


        static void CargarPelicula(PeliculaNegocio pelicula)
        {
            Console.WriteLine("Ingrese el título de la película a cargar:");
            string tituloPeli = Console.ReadLine();
            string tituloPeliValidado = FuncionesHelper.ValidarTexto(tituloPeli);

            Console.WriteLine("Ingrese el director de la película a cargar:");
            string directorPeli = Console.ReadLine();
            string directorPeliValidado = FuncionesHelper.ValidarTexto(directorPeli);

            Console.WriteLine("Ingrese la productora de la película a cargar:");
            string productoraPeli = Console.ReadLine();
            string productoraPeliValidado = FuncionesHelper.ValidarTexto(productoraPeli);

            Console.WriteLine("Ingrese el año de estreno de la película a cargar:");
            string anioPeli = Console.ReadLine();
            int anioPeliValidado = FuncionesHelper.ValidarAnio(anioPeli);
            
            //dejo en stand by esto: mayor o igual a 1895 (año de la primera película de la historia)

            Console.WriteLine("Ingrese la duración (en minutos) de la película a cargar:");
            string duracionPeli = Console.ReadLine();
            int duracionPeliVaidado = FuncionesHelper.ValidarNumero(duracionPeli);

            string generoPeli;
            int intGeneroPeli = 0;

            do
            {
                Console.WriteLine("Por favor, seleccione el número del género que corresponda de la película a cargar:");
                MenuHelper.ListarGeneros();

                generoPeli = Console.ReadLine();
                

                if (int.TryParse(generoPeli,out intGeneroPeli) || (int.Parse(generoPeli)>=10 || int.Parse(generoPeli)<0))
                {
                    Console.WriteLine("La opcion seleccionada es incorrecta.");
                }

            } while (int.TryParse(generoPeli,out intGeneroPeli));

            pelicula.AltaPelicula(anioPeliValidado, duracionPeliVaidado, tituloPeliValidado, directorPeliValidado, productoraPeliValidado, ((GeneroEnum)int.Parse(generoPeli)).ToString());

            Console.WriteLine("¡La película se ha cargado correctamente! Detalles:");
            Console.WriteLine(pelicula);

        }

        static void ListarCopia(string idPelicula, CopiaNegocio copia)
        {
            //validar que el idPelicula sea un int
            int idValidado = FuncionesHelper.ValidarID(idPelicula);

            Copia c = copia.TraerPorId(idValidado);
            Console.WriteLine(c);
        }


        static void CargarCopia(CopiaNegocio copia)
        {
            Console.WriteLine("Ingrese el número identificador de la película de la nueva copia:");
            string idPeliCopia = Console.ReadLine();
            //validar que exista el id de pelicula antes de continuar, y que sea un int.
            int idPeliCopiaValidado = FuncionesHelper.ValidarID(idPeliCopia);

            Console.WriteLine("Ingrese el precio de la nueva copia:");
            string precioCopia = Console.ReadLine();
            double precioCopiaValidado = FuncionesHelper.ValidarPrecio(precioCopia);

            Console.WriteLine("Ingrese las observaciones de la nueva copia. En el caso de no contar con observaciones, detallar: 'N/A'");
            string observacionesCopia = Console.ReadLine();
            //validar que el largo del string sea mayor o igual a 3, partiendo de la base que se debe detallar N/A en el caso de que no haya observaciones aplicables.
            string observacionesCopiaValidado = FuncionesHelper.ValidarTexto(observacionesCopia);

            copia.AltaCopia(observacionesCopiaValidado, precioCopiaValidado, DateTime.Now,idPeliCopiaValidado);
            Console.WriteLine("¡La copia se ha cargado correctamente! Detalles:");
            Console.WriteLine(copia);


        }

        static void PrestamosPorDNICliente(string dniCliente, PrestamoNegocio prestamo, ClienteNegocio cliente)
        {
            // validar que el nro de cliente sea un int y convertir dniCliente a int 
            int dni = FuncionesHelper.ValidarBusquedaDNI(dniCliente, cliente); 
            // llamar al método para generar el reporte
            prestamo.TraerPrestamoPorDNI(dni);

            //ReportePrestamoCliente(cliente);

        }


        static void PrestamosPorIDCliente(string dniCliente, PrestamoNegocio prestamo, ClienteNegocio cliente)
        {
            // validar que el nro de cliente sea un int y convertir dniCliente a int 
            int dni = FuncionesHelper.ValidarBusquedaDNI(dniCliente, cliente);
            // llamar al método para generar el reporte
            prestamo.TraerPrestamoPorDNI(dni);

        }



        static void CopiasPorPelicula(string idPelicula, CopiaNegocio copia)
        {
            // validar que el nro de cliente sea un int
            // convertir dniCliente a int 
            // llamar al método para generar el reporte

            //ReporteCopiaPelicula(pelicula);
        }

        

    }
}
