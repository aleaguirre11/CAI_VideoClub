using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NLayer.Negocio
{
	public class PeliculaNegocio
	{
        private PeliculaMapper _peliculaMapper;
        private List<Pelicula> _listaPeliculas;


        public PeliculaNegocio()
		{

            _peliculaMapper = new PeliculaMapper();
            _listaPeliculas = new List<Pelicula>();

        }

        //Dar de alta a las peliculas pidiendole al mapper que los inserte (post)
        public void AltaPelicula(/*int idpelicula,*/ int anio, int duracion, string titulo, string director,
            string productora, string genero)
        {
            Pelicula pelicula = new Pelicula();
            //pelicula.IdPelicula = idpelicula;
            pelicula.Anio = anio;
            pelicula.Duracion = duracion;
            pelicula.Titulo = titulo;
            pelicula.Director = director;
            pelicula.Productora = productora;
            pelicula.Genero = genero;

            TransactionResult transaction = _peliculaMapper.Insertar(pelicula);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        //pedirle al mapper la lista de peliculas
        public List<Pelicula> TraerLista()
        {
            _listaPeliculas = _peliculaMapper.TraerTodos();

            return _listaPeliculas;
        }

        //Consultar pelicula por nro de id
        public Pelicula TraerPorId(int idpelicula)
        {
            foreach (var item in TraerLista())
            {
                if (idpelicula == item.IdPelicula)
                    return item;
            }

            return null;
        }

        //Lista las peliculas que hizo un director 
        public List<Pelicula> TraerPorDirector(string director)
        {
            List<Pelicula> lst = new List<Pelicula>();
            //validar director no nulo
            List<Pelicula> lst1 = _peliculaMapper.TraerTodos();
            foreach (var item in lst1)
            {
                if (item.Director == director)
                    lst.Add(item);
            }

            return lst;
        }

        //Lista las peliculas por genero 
        public List<Pelicula> TraerPorGenero(string genero)
        {
            List<Pelicula> lst1 = new List<Pelicula>();
            //validar genero no nulo
            List<Pelicula> lst = _peliculaMapper.TraerTodos();
            foreach (var item in lst)
            {
                if (item.Genero == genero)
                    lst1.Add(item);
            }

            return lst1;
        }

        //Lista las peliculas por título
        public List<Pelicula> TraerPorTitulo(string titulo)
        {
            List<Pelicula> lst2 = new List<Pelicula>();
            //validar titulo no nulo
            List<Pelicula> lst = _peliculaMapper.TraerTodos();
            foreach (var item in lst)
            {
                if (item.Titulo == titulo)
                    lst2.Add(item);
            }

            return lst2;
        }


        //pedirle al mapper que actualice la pelicula (update)
        //private void ActualizarPelicula(Pelicula pelicula)
        //{


        //    TransactionResult transaction = _peliculaMapper.Actualizar(pelicula);

        //    //if (!transaction.IsOk)
        //    //    throw new Exception(transaction.Error);
        //}

        ////pedirle al mapper que elimine una pelicula (delete)
        //private void EliminarPelicula(Pelicula pelicula)
        //{


        //    TransactionResult transaction = _peliculaMapper.Eliminar(pelicula);

        //    //if (!transaction.IsOk)
        //    //    throw new Exception(transaction.Error);
        //}

        //Poder emitir un reporte de préstamos por cliente.
        private static void ReportePrestamoCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new Exception("Error de ingreso.");
            }

            PrestamoNegocio prest = new PrestamoNegocio();
            List<Prestamo> prestamos = prest.TraerLista();

            List<Prestamo> PrCliente = new List<Prestamo>();

            foreach (Prestamo p in prestamos.TakeWhile(p => p.Idcliente == Convert.ToInt32(cliente.Idcliente)))
            {
                PrCliente = prest.TraerPrestamoPorCliente(Convert.ToInt16(cliente.Idcliente));
            }

            Console.WriteLine($"Los prestamos del cliente son: " + System.Environment.NewLine + PrCliente);


        }

        //Poder emitir un reporte de copias por película.
        private static void ReporteCopiaPelicula(Pelicula pelicula)
        {
            if (pelicula == null)
            {
                throw new Exception("Error de ingreso.");
            }

            CopiaNegocio copyN = new CopiaNegocio();
            List<Copia> copias = copyN.TraerLista();

            List<Copia> CopyPeli = new List<Copia>();

            foreach (Copia c in copias.TakeWhile(c => c.Idpelicula == pelicula.IdPelicula))
            {
                CopyPeli = copyN.TraerPorIdPelicula(pelicula.IdPelicula);
            }

            Console.WriteLine($"Las copias de la pelicula son: " + System.Environment.NewLine + CopyPeli);


        }

    }
}
