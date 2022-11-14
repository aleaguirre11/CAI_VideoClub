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
                throw new Exception("No hay clientes.");

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

        //Pedirle al mappaer los clientes a partir del nro de telefono 
        //Validar que no se pueda dar de alta a un cliente si ya se registro ese nro de telefono
        public List<Cliente> TraerPorTelefono(string telefono)
        {
            List < Cliente > lst = _clienteMapper.TraerPorTelefono(telefono);

            return lst;
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
            cliente.Dni = dni;
            cliente.Telefono = telefono;
            cliente.Mail = mail;
            cliente.FechaNacimiento = fechaNac;

            //Validar que no se pueda dar de alta a un cliente si ya se registro ese nro de telefono
            //Validar que no se pueda dar de alta a un cliente si ya se registro ese dni
            //Validar que no se pueda dar de alta a un cliente si ya se registro ese mail

            TransactionResult transaction = _clienteMapper.Insertar(cliente);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
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

        public override bool Equals(object obj)
        {
            if (!(obj is Cliente))
                return false;
            Cliente cObj = (Cliente)obj;

            if (cObj.Telefono != telefono)
                return false;


            return true;
        }
    }
}
