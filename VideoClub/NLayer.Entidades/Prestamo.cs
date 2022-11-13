using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer.Entidades
{
    [DataContract]
    public class Prestamo
    {

        public Prestamo() { }
        public Prestamo(int idcliente, int idcopia, bool abierto, int plazo)
        {
            _idcliente = idcliente;
            _idcopia = idcopia;
            _abierto = abierto;
            _plazo = plazo;
        }

        public Copia copia;
        public Pelicula pelicula;
        public Cliente cliente;

        private int _idcliente;
        private int _idcopia;
        private int _idprestamo;
        //private DateTime _fechadevolucionreal; --> no es necesario declararlo
        private DateTime _fechadevoluciontentativa;
        private DateTime _fechaprestamo;
        private bool _abierto;
        private int _plazo;


        [DataMember(Name = "idCliente")]
        public int Idcliente
        {
            get
            {
                return _idcliente;
            }
            set
            {
                _idcliente = value;
            }
        }

        [DataMember(Name = "idCopia")]
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

        [DataMember(Name = "id")]
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

        [DataMember(Name = "fechaDevolucionReal")]
        public DateTime Fechadevolucionreal
        {
            get
            {
                return _fechaprestamo.AddDays(10);
            }
        }

        [DataMember(Name = "fechaDevolucionTentativa")]
        public DateTime Fechadevoluciontentativa
        {
            get
            {
                return _fechadevoluciontentativa;
            }
            set
            {
                _fechadevoluciontentativa = value;
            }
        }

        [DataMember(Name = "fechaPrestamo")]
        public DateTime Fechaprestamo
        {
            get
            {
                return DateTime.Now;
            }
        }

        [DataMember(Name = "abierto")]
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

        [DataMember(Name = "plazo")]
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

        public override string ToString()
        {
            return $"id: {Idprestamo} - Pelicula: {pelicula.Titulo} - Cliente: {cliente.Idcliente} - {cliente.Nombre} - {cliente.Apellido} - Plazo: {Plazo}";
        }


    }
}
