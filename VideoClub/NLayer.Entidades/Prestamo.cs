using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class Prestamo
    {
        public Prestamo() { }
        public Prestamo(int idprestamo, DateTime fechadevolucionreal, DateTime fechadevoluciontentativa, DateTime fechaprestamo, bool abierto, int plazo, int idcopia, int idcliente)
        {
            _idprestamo = idprestamo;
            _fechadevolucionreal = fechadevolucionreal;
            _fechadevoluciontentativa = fechadevoluciontentativa;
            _fechaprestamo = fechaprestamo;
            _abierto = abierto;
            _plazo = plazo;

        }

        private int _idprestamo;
        private DateTime _fechadevolucionreal;
        private DateTime _fechadevoluciontentativa;
        private DateTime _fechaprestamo;
        private bool _abierto;
        private int _plazo;

        public int Idprestamo
        {
            get
            {
                return _idprestamo;
            }
            set
            {
                _idprestamo = value;    
            }
        }

        public DateTime Fechadevolucionreal
        {
            get
            {
                return _fechadevolucionreal;
            }
        }

        public DateTime Fechadevoluciontentativa
        {
            get
            {
                return _fechadevoluciontentativa;
            }
        }

        public DateTime Fechaprestamo
        {
            get
            {
                return _fechaprestamo;
            }
        }

        public bool Abierto
        {
            get
            {
                return _abierto;
            }     
            set
            {
                _abierto = value;
            }
        }

        public int Plazo
        {
            get
            {
                return _plazo;
            }
            set
            {
                _plazo = value; 
            }
        }




    }
}
