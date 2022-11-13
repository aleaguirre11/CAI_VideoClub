using NLayer.Entidades;
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

        //public List<Cliente> TraerClientes()
        //{
        //    List<Cliente> result = ClienteMapper.TraerTodos();
        //    return result;
        //}

        public ClienteNegocio()
        {
            _clienteMapper = new ClienteMapper();
        }


        //pedirle al mapper la lista de clientes
        public List<Cliente> TraerLista()
        {
            List<Cliente> lst = _clienteMapper.TraerTodos();

            return lst;
        }

        //traer cliente por nro de id
        public Cliente TraerPorId(int idCliente)
        {
            foreach (var item in TraerLista())
            {
                if (idCliente == item.id)
                    return item;
            }

            return null;
        }

        //Pedirle al mappaer los clientes a partir del nro de telefono (CORREGIR EN MAPPER INT)
        //Validar que no se pueda dar de alta a un cliente si ya se registro ese nro de telefono
        public Cliente TraerPorTelefono(string telefono)
        {
            Cliente client = _clienteMapper.TraerPorTelefono(telefono);

            return client;
        }

        //Dar de alta a los clientes pidiendole al mapper que los inserte (post)
        public void AltaClientes(string idcliente, string fechaalta, bool cliActivo, string host, string usuario, 
            string nombre, string apellido, string direccion, int dni, string telefono, string mail, DateTime fechaNac)
        {
            Cliente cliente = new Cliente();
            cliente.Idcliente = idcliente;
            cliente.Fechaalta = fechaalta;
            cliente.CliActivo = cliActivo;
            cliente.Host = host;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Direccion = direccion;
            cliente.DNI = dni;
            cliente.Telefono = telefono;
            cliente.Email = mail;
            cliente.FechaNacimiento = fechaNac;

            //Validar que no se pueda dar de alta a un cliente si ya se registro ese nro de telefono
            //Validar que no se pueda dar de alta a un cliente si ya se registro ese dni
            //Validar que no se pueda dar de alta a un cliente si ya se registro ese mail

            TransactionResult transaction = _clienteMapper.Insertar(cliente);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
        }

        //pedirle al mapper que actualice el cliente (update)
        private void ActualizarCliente(Cliente cliente)
        {


            TransactionResult transaction = _clienteMapper.Actualizar(cliente);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
        }

        //pedirle al mapper que elimine un cliente (delete)
        private void EliminarCliente(Cliente cliente)
        {


            TransactionResult transaction = _clienteMapper.Eliminar(cliente);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
        }
    }
}
