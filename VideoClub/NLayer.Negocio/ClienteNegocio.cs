﻿using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NLayer.Negocio
{
    public class ClienteNegocio
    {
        private ClienteMapper _clienteMapper;
        private List<Cliente> _listaClientes;

        //public List<Cliente> TraerClientes()
        //{
        //    List<Cliente> result = ClienteMapper.TraerTodos();
        //    return result;
        //}

        public ClienteNegocio()
        {
            _clienteMapper = new ClienteMapper();
            _listaClientes = new List<Cliente>();
        }


        //pedirle al mapper la lista de clientes
        public List<Cliente> TraerLista()
        {
            _listaClientes = _clienteMapper.TraerTodos();

            if (_listaClientes == null)
                throw new Exception("No se han registrado clientes aun.");

            return _listaClientes;
        }

        //traer cliente por nro de id
        public Cliente TraerPorId(string idCliente)
        {

            foreach (var item in TraerLista())
            {
                if (idCliente == item.Idcliente)
                    return item;
            }

            return null;
        }

        //obtener el id del cliente por DNI
        public string TraerIdPorDNI(int dni)
        {
            foreach (var item in TraerLista())
            {
                if (dni == item.Dni)
                    return item.Idcliente;
            }

            return null;
        }

        //traer cliente por nro de registro validando que hayan clientes registrados
        public List<Cliente> TraerPorRegistro(string usuario)
        {

            List<Cliente> lst1 = new List<Cliente>();

            if (_listaClientes.Count() > 0)
            {
                lst1.AddRange(_listaClientes.Where(item => item.Usuario == usuario));
            }
            else
                throw new Exception("No se han registrado clientes aun.");

            return lst1;

        }

        //Pedirle al mappaer los clientes a partir del nro de telefono 
 
        public List<Cliente> TraerPorTelefono(string telefono)
        {
            if (!(_listaClientes.Count() > 0))
                throw new Exception("No se han registrado clientes aun.");

            List < Cliente > lst = _clienteMapper.TraerPorTelefono(telefono);

            return lst;
        }

        //Dar de alta a los clientes pidiendole al mapper que los inserte (post)
        public void AltaClientes(/*string idcliente,*/ string fechaalta, bool cliActivo, string host, string usuario, 
            string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac)
        {
            Cliente cliente = new Cliente();
            //cliente.Idcliente = idcliente;
            cliente.Fechaalta = fechaalta;
            cliente.CliActivo = true;
            cliente.Host = host;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Direccion = direccion;
            cliente.Dni = dni;
            cliente.Telefono = telefono;
            cliente.Mail = mail;
            cliente.FechaNacimiento = fechaNac;

            //Validar que no se pueda dar de alta a un cliente si ya se registro ese dni
            bool flag = ValidarDNI(cliente.Dni);
            //Validar que no se pueda dar de alta a un cliente si ya se registro ese mail
            bool flag1 = ValidarMail(cliente.Mail);

            if (flag == true)
            {
                throw new Exception("Ya existe un cliente con el DNI ingresado.");
            }
            else if (flag1 == true)
            {
                throw new Exception("Ya existe un cliente con el mail ingresado.");
            }

            TransactionResult transaction = _clienteMapper.Insertar(cliente);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
        public bool ValidarDNI(int dni)
        {
            if (!(_listaClientes.Count() > 0))
                throw new Exception("No se han registrado clientes aun.");

            foreach (var item in TraerLista())
            {
                if (dni == item.Dni)
                    return true;
            }

            return false;
        }
        public bool ValidarMail(string mail)
        {
            if (!(_listaClientes.Count() > 0))
                throw new Exception("No se han registrado clientes aun.");

            foreach (var item in TraerLista())
            {
                if (mail == item.Mail)
                    return true;
            }

            return false;
        }

        //pedirle al mapper que actualice el cliente (update)
        private void ActualizarCliente(Cliente cliente)
        {


            TransactionResult transaction = _clienteMapper.Actualizar(cliente);

            if (!transaction.IsOk)
               throw new Exception(transaction.Error);
        }

        //pedirle al mapper que elimine un cliente (delete)
        private void EliminarCliente(Cliente cliente)
        {


            TransactionResult transaction = _clienteMapper.Eliminar(cliente);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

    }
}
