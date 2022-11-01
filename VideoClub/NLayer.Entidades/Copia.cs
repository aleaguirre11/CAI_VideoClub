using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class Copia : Pelicula
    {
        public Copia(int idcopia, string observaciones, double precio, DateTime fechaalta, int idpelicula, int año, int duracion, string titulo, string director, string productora, string genero) : base(idpelicula, año, duracion, titulo, director, productora, genero)
        {
            _idcopia = idcopia;
            _observaciones = observaciones;
            _precio = precio;
            _fechaalta = fechaalta;
        }

        private int _idcopia;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaalta;


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
    }

   
}
