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
        public Prestamo(int idcliente, int idcopia, bool abierto) 
        {
            _idcliente = idcliente;
            _idcopia = idcopia;
            _abierto = abierto;
        }

        private Copia _copia;
        private Cliente _cliente;

        private int _idcliente;
        private int _idcopia;
        private int _idprestamo;
        private DateTime _fechadevolucionreal;
        //private DateTime _fechadevoluciontentativa; --> no es necesario declararlo
        //private DateTime _fechaprestamo; --> no es necesario declararlo
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

        [DataMember(Name = "FechaDevolucionReal")]
        public DateTime Fechadevolucionreal
        {

            get
            {
                return _fechadevolucionreal;
            }
            set
            {
                _fechadevolucionreal = value;
            }

        }

        [DataMember(Name = "FechaDevolucionTentativa")]
        public DateTime Fechadevoluciontentativa
        {
            get
            {
                return DateTime.Now.AddDays(_plazo); //Le agregamos el plazo a la fecha de devolucion tentativa
            }
        }

        [DataMember(Name = "FechaPrestamo")]
        public DateTime Fechaprestamo
        {
            get
            {
                return DateTime.Now;
            }
        }

        [DataMember(Name = "Abierto")]
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

        [DataMember(Name = "Plazo")]
        public int Plazo
        {
            get
            {
                return _plazo = 10; // por regla de negocio, establecimos que la cantidad máxima de días que se puede otorgar un préstamo es de 10.
            }
            set
            {
                _plazo = value; 
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        }

        public Copia Copia
        {
            get
            {
                return _copia;
            }
            set
            {
                _copia = value;
            }
        }


        
            

        public override string ToString()
        {
            return $"ID Prestamo: {Idprestamo} - ID Copia: {this.Idcopia} - ID Cliente: {this.Idcliente} - Plazo: {Plazo}";
        }


    }
}
