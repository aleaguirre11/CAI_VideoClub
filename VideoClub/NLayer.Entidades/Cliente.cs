﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NLayer.Entidades
{
    [DataContract]
    public class Cliente : Persona
    {
        private int _idcliente;
        private string _fechaalta;
        private bool _cliActivo;
        private string _host;
        private string _usuario;


        public Cliente() { }//constructor vacío para mapeo

        public Cliente(int idcliente, string fechaalta, bool cliActivo, string host, string usuario, string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac) : base(nombre, apellido, direccion, dni, telefono, mail, fechaNac)
        {
            _idcliente = idcliente;
            _fechaalta = fechaalta;
            _cliActivo = cliActivo;
            _host = host;
            _usuario = usuario;
        }

        [DataMember(Name = "id")]
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

        [DataMember(Name = "fechaAlta")]
        public string Fechaalta
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

        [DataMember(Name = "Activo")]
        public bool CliActivo
        {
            get
            {
                return _cliActivo;
            }set
            {
                _cliActivo = value;
            }
        }

        [DataMember(Name = "host")]
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

        [DataMember(Name = "Usuario")]
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

        public override string ToString()
        {
            return $"ID: {Idcliente} - Apellido: {Apellido} - Nombre: {Nombre} - DNI: {Dni}";
        }
    }
}
