using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLayer.Entidades;
using NLayer.Datos.Utilidades;

namespace NLayer.Datos
{
    public class ClienteMapper
    {

        // Método para traer todos los clientes que persisten en el JSON de la API
        public List<Cliente> TraerTodos()
        {
            string json = WebHelper.Get("cliente");
            List<Cliente> resultado = MapList(json);
            return resultado;
        }


        // Método para traer todos los clientes según un número de registro enviado por parámetro (en nuestro caso siempre vamos a utilizar 890191)
        public List<Cliente> TraerPorRegistro(string registro)
        {
            string json = WebHelper.Get("cliente/" + registro);
            List<Cliente> resultado = MapList(json);
            return resultado;
        }


        // Método para traer todos los clientes según un número de teléfono
        public List<Cliente> TraerPorTelefono(string telefono)
        {
            string json = WebHelper.Get("cliente/" + telefono + "/telefono");
            List<Cliente> resultado = MapList(json);
            return resultado;
        }


        // Método para insertar nuevos clientes dentro del JSON "Cliente", mediante el POST-REQUEST
        public TransactionResult Insertar(Cliente nuevoCliente)
        {
            NameValueCollection obj = ReverseMap(nuevoCliente);
            string result = WebHelper.Post("cliente", obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        // Método para actualizar un cliente en particular dentro del JSON "Cliente", mediante el PUT-REQUEST
        public TransactionResult Actualizar(Cliente actualizarCliente)
        {
            NameValueCollection obj = ReverseMapActualizar(actualizarCliente);
            string result = WebHelper.Put("cliente/" + actualizarCliente.Idcliente, obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        // Método para eliminar un cliente en particular dentro del JSON "Cliente", mediante el DELETE-REQUEST
        public TransactionResult Eliminar(Cliente eliminarCliente)
        {
            NameValueCollection obj = ReverseMap(eliminarCliente);
            string result = WebHelper.Post("cliente/" + eliminarCliente.Idcliente, obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }



        // Método privado utilizado por los GET-REQUEST para formatear el resultado del listado de clientes 
        private List<Cliente> MapList(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return lst;
        }


        // Método privado utilizado por el POST-REQUEST para mapear los valores de las variables correspondientes
        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection c = new NameValueCollection();
            c.Add("id", cliente.Idcliente.ToString());
            c.Add("Nombre", cliente.Nombre);
            c.Add("Apellido", cliente.Apellido);
            c.Add("Direccion", cliente.Direccion);
            c.Add("Telefono", cliente.Telefono);
            c.Add("Email", cliente.Mail);
            c.Add("DNI", cliente.Dni.ToString());
            c.Add("Activo", cliente.CliActivo.ToString());
            c.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            c.Add("Usuario", "890191");
            return c;
        }


        // Método privado utilizado por el PUT-REQUEST para mapear los nuevos valores de las variables correspondientes
        private NameValueCollection ReverseMapActualizar(Cliente cliente)
        {
            NameValueCollection c = new NameValueCollection();
            c.Add("id", cliente.Idcliente.ToString());
            c.Add("Nombre", cliente.Nombre);
            c.Add("Apellido", cliente.Apellido);
            c.Add("Direccion", cliente.Direccion);
            c.Add("Telefono", cliente.Telefono);
            c.Add("Email", cliente.Mail);
            c.Add("DNI", cliente.Dni.ToString());
            c.Add("Activo", cliente.CliActivo.ToString());
            c.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            return c;
        }



        // Método privado utilizado por el POST/PUT/DELETE-REQUEST para recibir el resultado de los request en el JSON. El número 200 significa que el request funcionó correctamente.
        private TransactionResult MapResultado(string json)
        {
            TransactionResult tr = JsonConvert.DeserializeObject<TransactionResult>(json);
            return tr;
        }

    }
}