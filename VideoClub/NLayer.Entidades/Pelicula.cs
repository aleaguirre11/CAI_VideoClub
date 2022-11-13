using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class Pelicula
    {
        public Pelicula(int idpelicula, int anio, int duracion, string titulo, string director, string productora, string genero)
        {
            _idpelicula = idpelicula;
            _anio = anio;
            _duracion = duracion;
            _titulo = titulo;
            _director = director;
            _productora = productora;
            _genero = genero;
            
        }

        public Pelicula()
        {
            //constructor vacío para mapeo
        }

        private int _idpelicula;
        private int _anio;
        private int _duracion;
        private string _titulo;
        private string _director;
        private string _productora;
        private string _genero;


        public int IdPelicula
        {
            get
            {
                return _idpelicula;
            }

            set
            {
                _idpelicula = value;
            }
        }

        public int Anio
        {
            get
            {
                return _anio;
            }
            set
            {
                _anio = value;
            }
        }

        public int Duracion
        {
            get
            {
                return _duracion;
            }
            set
            {
                _duracion = value;
            }
        }

        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                _titulo = value;
            }
        }

        public string Director
        {
            get
            {
                return _director;
            }
            set
            {
                _director = value;
            }
        }

        public string Productora
        {
            get
            {
                return _productora;
            }
            set
            {
                _productora = value;
            }
        }

        public string Genero
        {
            get
            {
                return _genero;
            }
            set
            {
                _genero = value;
            }
        }

       
    }
}
