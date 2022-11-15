using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer.Entidades
{
    [DataContract]
    public class Copia 
    {

        public Copia() { }

        public Copia(string observaciones, double precio, DateTime fechaalta, int idpelicula)
        {
            _observaciones = observaciones;
            _precio = precio;
            _fechaalta = fechaalta;
            _idpelicula = idpelicula;
        }

        private int _idcopia;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaalta;
        private int _idpelicula;
        private Pelicula _pelicula;


        [DataMember(Name = "id")]
        public int Idcopia
        {
            get
            {
                return _idcopia;
            }
            set
            {
                _idcopia = value;
            }
        }

        [DataMember(Name = "observaciones")]
        public string Observaciones
        {
            get
            {
                return _observaciones;
            }
            set
            {
                _observaciones = value;
            }
        }

        [DataMember(Name = "precio")]
        public double Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }

        [DataMember(Name = "fechaAlta")]
        public DateTime Fechaalta
        {
            get
            {
                return _fechaalta;
            }
            set
            {
                _fechaalta = value;
            }
        }

        [DataMember(Name = "idPelicula")]
        public int Idpelicula
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

        public Pelicula Pelicula
        {
            get
            {
                return _pelicula;
            }
            set
            {
                _pelicula = value;
            }
        }
    }

   
}
