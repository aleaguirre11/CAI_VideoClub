using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    public class Cliente : Persona
    {
        private string _idcliente;
        private string _fechaalta;
        private bool _cliActivo;
        private string _host;
        private string _usuario;

        //public Cliente(string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac) : base(nombre, apellido, direccion, dni, telefono, mail, fechaNac)
        //{

        //}
        public Cliente() : base()
        {

        }
        public Cliente(string idcliente, string fechaalta, bool cliActivo, string host, string usuario, string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac) : base(nombre, apellido, direccion, dni, telefono, mail, fechaNac)
        {
            _idcliente = idcliente;
            _fechaalta = fechaalta;
            _cliActivo = cliActivo;
            _host = host;
            _usuario = usuario;
        }

        public string Idcliente
        {
            get
            {
                return _idcliente;
            }
        }

        public string Fechaalta
        {
            get
            {
                return _fechaalta;
            }
        }

        public bool CliActivo
        {
            get
            {
                return _cliActivo;
            }
            set
            {
                _cliActivo = value;
            }
        }

        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }

    }
}
