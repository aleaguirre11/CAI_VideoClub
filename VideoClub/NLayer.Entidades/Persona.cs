using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer.Entidades
{
    [DataContract]
    public abstract class Persona
    {

        public Persona() { }
        public Persona(string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac)
        {
            _nombre = nombre;
            _apellido = apellido;
            _direccion = direccion;
            _dni = dni;
            _telefono = telefono;
            _mail = mail;
            _fechaNac = fechaNac;
        }

        protected string _nombre;
        protected string _apellido;
        protected string _direccion;
        protected int _dni;
        protected string _telefono;
        protected string _mail;
        protected DateTime _fechaNac;

        [DataMember(Name = "Nombre")]
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        [DataMember(Name = "Apellido")]
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        [DataMember(Name = "Direccion")]
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        [DataMember(Name = "DNI")]
        public int Dni
        {
            get
            {
                return _dni;
            }
            set
            {
                _dni = value;
            }
        }

        [DataMember(Name = "Telefono")]
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        [DataMember(Name = "Email")]
        public string Mail
        {
            get
            {
                return _mail;   
            }
            set
            {
                _mail = value;
            }
        }

        [DataMember(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNac;
            }
            set
            {
                _fechaNac = value;
            }
        }
    }
}
