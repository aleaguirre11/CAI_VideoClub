using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer.Entidades
{
    [DataContract]
    public class Pelicula
    {
        public Pelicula(int idpelicula, int anio, int duracion, string titulo, string director, string productora, string genero, int idcopia, string observaciones, double precio, DateTime fechaalta)
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

        [DataMember(Name = "id")]
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

        [DataMember(Name = "anio")]
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

        [DataMember(Name = "duraciom")]
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

        [DataMember(Name = "titulo")]
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

        [DataMember(Name = "director")]
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

        [DataMember(Name = "productora")]
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

        [DataMember(Name = "genero")]
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
       

        public override ToString()
        {
            return $"id: {IdPelicula} - {Titulo}";
        }
    }
}
