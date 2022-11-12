using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
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

        private int _idcopia;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaalta;
        private int _idpelicula;


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
