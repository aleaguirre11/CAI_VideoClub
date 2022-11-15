using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            

            //Validar que no se pueda dar de alta a una pelicula si ya se registro ese id
            //Validar que no se pueda dar de alta a una pelicula si ya se registro ese id con ese id de copia

            TransactionResult transaction = _peliculaMapper.Insertar(pelicula);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
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

        //Pedirle al mappaer las peliculas que hizo un director 
        //public List<Pelicula>  TraerPorDirector(Pelicula director)
        //{
        //    //validar director no nulo
        //    List<Pelicula> lst1 = _peliculaMapper.TraerPorDirector(director);

        //    return lst1;
        //}

        //public List<Pelicula>  TraerPorGenero(Pelicula genero)
        //{
        //    //validar genero no nulo
        //    List<Pelicula> lst2 = _peliculaMapper.TraerPorGenero(genero);

        //    return lst2;
        //}

        //public List<Pelicula>  TraerPorTitulo(Pelicula titulo)
        //{
        //    //validar titulo no nulo
        //    List<Pelicula> lst3 = _peliculaMapper.TraerPorTitulo(titulo);

        //    return lst3;
        //}

        //Una pelicula tiene un unico id pero puede tener mas de una copia
        public int TraerTotalCopias(int idpelicula)
        {
            int contador = 0;

            //validar id no nulo
            foreach (var item in TraerLista())
            {
                if (idpelicula == item.IdPelicula)
                    contador++;
                
            }

            return contador;
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

    }
}
