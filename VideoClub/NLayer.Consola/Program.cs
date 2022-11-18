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
            bool flag = false;

            do
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
                                switch (opcionMenuCliente.ToUpper())
                                {
                                    case "A":
                                        MenuHelper.ListarClientes();
                                        string opcionMenuListarCliente = Console.ReadLine().Trim();
                                        switch (opcionMenuListarCliente.ToUpper())
                                        {
                                            case "1":
                                                CliTraerTodos(cliente);
                                                break;
                                            case "2":
                                                Console.WriteLine("Detalle el número de registro a buscar: ");
                                                string nroRegistro = Console.ReadLine().Trim();
                                                CliTraerPorRegistro(nroRegistro, cliente);
                                                break;
                                            case "3":
                                                Console.WriteLine("Detalle el número de teléfono a buscar:");
                                                string nroTelefono = Console.ReadLine().Trim();
                                                CliTraerPorTelefono(nroTelefono, cliente);
                                                break;
                                            case "X":
                                                Console.WriteLine("Volviendo al menú principal...");
                                                Thread.Sleep(2000);
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
                                        /*Console.WriteLine("Detalle el id del cliente que desea actualizar:");
                                        string idClienteModificar = Console.ReadLine();
                                        ModificarCliente(idClienteModificar);*/
                                        break;
                                    case "D":
                                        FuncionesHelper.NoDisponible();
                                        /*Console.WriteLine("Detalle el id del cliente que desea eliminar:");
                                        string idClienteEliminar = Console.ReadLine();
                                        EliminarCliente(idClienteEliminar);*/
                                        break;
                                    case "X":
                                        Console.WriteLine("Volviendo al menú principal...");
                                        Thread.Sleep(3000);
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
                                        ListarPrestamos(idPeliculaPrestamo, prestamo);
                                        break;
                                    case "B":
                                        CargarPrestamo(prestamo, cliente);
                                        break;
                                    case "X":
                                        Console.WriteLine("Volviendo al menú principal...");
                                        Thread.Sleep(2000);
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
                                        Console.WriteLine("Volviendo al menú principal...");
                                        Thread.Sleep(3000);
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
                                        Console.WriteLine("Volviendo al menú principal...");
                                        Thread.Sleep(2000);
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
                                        switch (opcionMenuReportesPrestamo.ToUpper())
                                        {
                                            case "1":
                                                Console.WriteLine("Ingrese el número de documento del cliente:");
                                                string dniCliente = Console.ReadLine().Trim();
                                                PrestamosPorDNICliente(dniCliente, prestamo);
                                                break;
                                            case "2":
                                                Console.WriteLine("Ingrese el número identificador del cliente:");
                                                string idCliente = Console.ReadLine().Trim();
                                                PrestamosPorIDCliente(idCliente, prestamo);
                                                break;
                                            case "X":
                                                Console.WriteLine("Volviendo al menú principal...");
                                                Thread.Sleep(2000);
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
                                        Console.WriteLine("Volviendo al menú principal...");
                                        Thread.Sleep(2000);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "X":
                                consolaActiva = false;
                                Console.WriteLine("¡Hasta la próxima!");
                                Thread.Sleep(2000);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ExcepcionGeneralEx)
                {
                    Console.WriteLine(ExcepcionGeneralEx.Message);
                    Thread.Sleep(1500);
                }

                Console.WriteLine("¿Desea realizar otra operación?" + System.Environment.NewLine + "S - Desplegar las opciones del menú principal." + System.Environment.NewLine + "N - Salir del sistema.");
                string resultado = Console.ReadLine().Trim();

                if (resultado.ToUpper() == "S")
                {
                    flag = true;
                }
                else if (!(resultado.ToUpper()=="S"))
                {
                    flag = false;
                    Console.WriteLine("¡Hasta la próxima!");
                    Thread.Sleep(2000);
                }

            } while (flag == true);

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

            if (nroRegistroValido == false)
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

            if (nroTelefonoValido == false)
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

            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Lucas", "Perez", "Av Santa Fe 888", 30444789, "1167895432", "chau@hotmail.com", DateTime.Parse("09/10/1980"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Matias", "Aguirre", "Av Santa Fe 999", 30555729, "1167333439", "quepaso@hotmail.com", DateTime.Parse("05/01/1985"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Mariano", "Iglesias", "Av Libertador 3289", 38455789, "1122895466", "buenosdias@gmail.com", DateTime.Parse("23/07/1990"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Sofia", "Velez", "Av Corrientes 555", 40467843, "1161115438", "pinonfijo@yahoo.com", DateTime.Parse("02/12/1997"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Lourdes", "Sanchez", "Nordelta 2022", 30599732, "1155595992", "chatoamor@outlook.com", DateTime.Parse("29/03/1975"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Susana", "Gimenez", "Av Uruguay 389", 20444111, "1533895192", "lasugimenez@hotmail.com", DateTime.Parse("09/05/1950"));
            //cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", "Moria", "Casan", "Av Yoquese 656", 30569719, "1167891722", "eldecorado@secalla.com", DateTime.Parse("02/01/1950"));
            Console.WriteLine("Ingresar el DNI del nuevo cliente:");
            string dniCliente = Console.ReadLine();
            int dniClienteValidado = FuncionesHelper.ValidarCargaDNI(dniCliente);


            Console.WriteLine("Ingresar el nombre del nuevo cliente:");
            string nombreCliente = Console.ReadLine();
            string nombreClienteValidado = FuncionesHelper.ValidarTexto(nombreCliente);

            Console.WriteLine("Ingresar el apellido del nuevo cliente:");
            string apellidoCliente = Console.ReadLine();
            string apellidoClienteValidado = FuncionesHelper.ValidarTexto(apellidoCliente);

            Console.WriteLine("Ingresar la fecha de nacimiento del nuevo cliente (con el formato dd/mm/aaaa):");
            string fechaNacCliente = Console.ReadLine();
            DateTime fechaNacClienteValidada = FuncionesHelper.ValidarFechaNacimiento(fechaNacCliente);

            Console.WriteLine("Ingresar el teléfono del nuevo cliente:");
            string telefonoCliente = Console.ReadLine();
            string telefonoClienteValidado = FuncionesHelper.ValidarTextoTel(telefonoCliente);

            Console.WriteLine("Ingresar el domicilio del nuevo cliente:");
            string domicilioCliente = Console.ReadLine();
            string domicilioClienteValidado = FuncionesHelper.ValidarTexto(domicilioCliente);

            Console.WriteLine("Ingresar el mail del nuevo cliente:");
            string mailCliente = Console.ReadLine();
            string mailClienteValidado = FuncionesHelper.ValidarMail(mailCliente);

            cliente.AltaClientes((DateTime.Now).ToString(), true, "", "890191", nombreClienteValidado, apellidoClienteValidado, domicilioClienteValidado, dniClienteValidado, telefonoClienteValidado, mailClienteValidado, fechaNacClienteValidada);
            Console.WriteLine("¡El cliente se ha creado correctamente!");

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
            //prestamo.AltaPrestamo(true, 22, 835);
            //prestamo.AltaPrestamo(true, 21, 835);
            //prestamo.AltaPrestamo(true, 20, 835);
            //prestamo.AltaPrestamo(true, 19, 841);
            //prestamo.AltaPrestamo(true, 18, 842);
            //prestamo.AltaPrestamo(true, 17, 842);
            //prestamo.AltaPrestamo(true, 16, 844);
            //prestamo.AltaPrestamo(true, 15, 844);
            //prestamo.AltaPrestamo(true, 14, 844);
            //prestamo.AltaPrestamo(true, 13, 843);
            //prestamo.AltaPrestamo(true, 12, 843);
            //prestamo.AltaPrestamo(true, 11, 840);
            //prestamo.AltaPrestamo(true, 10, 840);

            Console.WriteLine("Ingresar el DNI del cliente al cual se le va a realizar el préstamo:");
            string dniPrestamo = Console.ReadLine();
            //método para validar:
            // 1. Que el cliente exista ---> en TraerIdPorDNI
            // 2. Que el cliente no supere determinada cantidad de préstamos --> en el alta
            // 3. Que se haya ingresado un número --> en funciones/validaciones helper 

            // convertir dniPrestamo a int para pasar al método de la capa de negocio
            int dniClienteValidado = FuncionesHelper.ValidarBusquedaDNI(dniPrestamo);
            int idClientePrestamo = cliente.TraerIdPorDNI(dniClienteValidado);


            Console.WriteLine("Ingresar el número de copia a prestar:");
            string nroCopiaPrestamo = Console.ReadLine();
            int nroCopiaValidado = FuncionesHelper.ValidarID(nroCopiaPrestamo);
            //método para validar:
            // 1. Que exista la copia
            // 2. Que la copia esté disponible
            // 3. Que se haya ingresado un número


            prestamo.AltaPrestamo(true, nroCopiaValidado, idClientePrestamo);
            Console.WriteLine("¡El préstamo se ha cargado correctamente!");

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

            //pelicula.AltaPelicula(2010, 160, "Avatar", "James Cameron", "Queseyo", ((GeneroEnum)int.Parse("9")).ToString());
            //pelicula.AltaPelicula(2000, 100, "Shrek", "Juan Perez", "DreamWorks", ((GeneroEnum)int.Parse("9")).ToString());
            //pelicula.AltaPelicula(2015, 120, "Avengers", "Tony Stark", "Marvel", ((GeneroEnum)int.Parse("4")).ToString());
            //pelicula.AltaPelicula(2019, 130, "End Game", "Black Widow", "Marvel", ((GeneroEnum)int.Parse("4")).ToString());
            //pelicula.AltaPelicula(2018, 120, "The Simpsons", "Ned Flanders", "Krusty Burger", ((GeneroEnum)int.Parse("5")).ToString());
            //pelicula.AltaPelicula(1970, 100, "Top Gun", "Marcelo", "CAI", ((GeneroEnum)int.Parse("4")).ToString());
            //pelicula.AltaPelicula(2008, 80, "Animal Planet", "El Mago sin dientes", "El Fan de Wanda", ((GeneroEnum)int.Parse("7")).ToString());


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


                if (int.TryParse(generoPeli, out intGeneroPeli) == false || (int.Parse(generoPeli) > 10 || int.Parse(generoPeli) < 0))
                {
                    Console.WriteLine("La opcion seleccionada es incorrecta.");
                }

            } while (!int.TryParse(generoPeli, out intGeneroPeli));

            pelicula.AltaPelicula(anioPeliValidado, duracionPeliVaidado, tituloPeliValidado, directorPeliValidado, productoraPeliValidado, ((GeneroEnum)int.Parse(generoPeli)).ToString());

            Console.WriteLine("¡La película se ha cargado correctamente!");

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
            //copia.AltaCopia("Mala calidad", 600.0, DateTime.Now, 13);
            //copia.AltaCopia("Hacemos lo que podemos", 1000.0, DateTime.Now, 12);
            //copia.AltaCopia("Que noche tete!", 1500.0, DateTime.Now, 10);
            //copia.AltaCopia("Pochoclera 100%", 1500.0, DateTime.Now, 10);
            //copia.AltaCopia("Nostalgia sos vos", 800.0, DateTime.Now, 8);
            //copia.AltaCopia("Son-Risas", 800.0, DateTime.Now, 8);
            //copia.AltaCopia("Subimo el precio porque podemos", 5000.0, DateTime.Now, 7);
            //copia.AltaCopia("Sea feliz, mirese una peli", 1800.0, DateTime.Now, 6);



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

            copia.AltaCopia(observacionesCopiaValidado, precioCopiaValidado, DateTime.Now, idPeliCopiaValidado);
            Console.WriteLine("¡La copia se ha cargado correctamente!");


        }

        static void PrestamosPorDNICliente(string dniCliente, PrestamoNegocio prestamo)
        {
            // validar y convertir dniCliente a int 
            int dni = FuncionesHelper.ValidarBusquedaDNI(dniCliente); 
            // llamar al método para generar el reporte
            List<Prestamo> Prestamos = prestamo.ReportePrestamoCliente2(dni);

            Console.WriteLine($"El cliente con DNI {0} posee estos préstamos:",dni);
            foreach (Prestamo item in Prestamos)
            {
                Console.WriteLine(item);
            }

        }


        static void PrestamosPorIDCliente(string id, PrestamoNegocio prestamo)
        {
            // validar y convertir id del cliente a int 
            int idCliente = FuncionesHelper.ValidarID(id);
            // llamar al método para generar el reporte

            List<Prestamo> Prestamos = prestamo.ReportePrestamoCliente(idCliente);

            Console.WriteLine($"El cliente con ID {0} posee estos préstamos:", idCliente);
            foreach (Prestamo item in Prestamos)
            {
                Console.WriteLine(item);
            }

        }



        static void CopiasPorPelicula(string idPelicula, CopiaNegocio copia)
        {
            // validar y convertir id de la película a int 
            int idPeliculaValidado = FuncionesHelper.ValidarID(idPelicula);

            List<Copia> Copias = copia.ReporteCopiaPelicula(idPeliculaValidado);

            Console.WriteLine($"La película con ID {0} posee estas copias:", idPelicula);
            foreach (Copia item in Copias)
            {
                Console.WriteLine(item);
            }

        }









        

    }
}
