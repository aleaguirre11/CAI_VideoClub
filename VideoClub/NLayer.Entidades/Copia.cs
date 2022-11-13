using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]
    public class Copia 
    {
        public Copia(int idcopia, string observaciones, double precio, DateTime fechaalta, int idpelicula)
        {
            _idcopia = idcopia;
            _observaciones = observaciones;
            _precio = precio;
            _fechaalta = fechaalta;
            _idpelicula = idpelicula;
        }

        public Copia()
        {
            //constructor vacío para mapeo
        }

        private int _idcopia;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaalta;
        private int _idpelicula;

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
    }

   
}
