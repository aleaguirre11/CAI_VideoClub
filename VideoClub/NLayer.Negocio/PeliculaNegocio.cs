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

            if (!(_listaPeliculas.Count() > 0))
            {
                throw new Exception("No se han registrado películas aun.");
            }

            return _listaPeliculas;
        }

        //Consultar pelicula por nro de id
        public Pelicula TraerPorId(int idpelicula)
        {
            _listaPeliculas = _peliculaMapper.TraerTodos();

            if (!(_listaPeliculas.Count() > 0))
            {
                throw new Exception("No se han registrado películas aun.");
            }

            foreach (var item in _listaPeliculas)
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

            List<Pelicula> lst1 = _peliculaMapper.TraerTodos();
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

            if (!(lst1.Count() > 0))
            {
                throw new Exception("No se han registrado películas aun.");
            }

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
            List<Pelicula> lst = new List<Pelicula>();

            List<Pelicula> lst1 = _peliculaMapper.TraerTodos();

            if (!(lst1.Count() > 0))
            {
                throw new Exception("No se han registrado películas aun.");
            }

            foreach (var item in lst1)
            {
                if (item.Genero == genero)
                    lst.Add(item);
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

            return lst;
        }
            return lst1;
        }

        //Lista las peliculas por título
        public List<Pelicula> TraerPorTitulo(string titulo)
        {
            List<Pelicula> lst2 = new List<Pelicula>();

            List<Pelicula> lst = _peliculaMapper.TraerTodos();

            if (!(lst.Count() > 0))
            List<Pelicula> lst2 = new List<Pelicula>();
            //validar titulo no nulo
            List<Pelicula> lst = _peliculaMapper.TraerTodos();
            foreach (var item in lst)
            {
                throw new Exception("No se han registrado películas aun.");
            }

            foreach (var item in lst)
            {
                if (item.Titulo == titulo)
                    lst2.Add(item);
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

        //Buscar Película a partir del ID de la película para el reporte
        public Pelicula BuscarPeliculaPorID(int idPelicula)
        {
            _listaPeliculas = _peliculaMapper.TraerTodos();

            if (!(_listaPeliculas.Count() > 0))
            {
                throw new Exception("No se han registrado películas aun.");
            }

            foreach (var item in _listaPeliculas)
            {
                if (idPelicula == item.IdPelicula)
                    return item;
            }

            throw new Exception("No existe una película con ese ID.");
            //return null;
        }

    }
}
