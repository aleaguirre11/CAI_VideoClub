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
            return resultado
        }


        // Método para traer todos los clientes según un número de registro enviado por parámetro (en nuestro caso siempre vamos a utilizar 890191)
        public List<Cliente> TraerPorRegistro(int registro)
        {
            string json = WebHelper.Get("cliente/" + registro.ToString());
            List<Cliente> resultado = MapList(json);
            return resultado;
        }


        // Método para traer todos los clientes según un número de teléfono
         public List<Cliente> TraerPorTelefono(int telefono)
        {
            string json = WebHelper.Get("cliente/" + telefono.ToString() + "/telefono");
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
        public TransactionResult Actualizar(Cliente cliente)
        {
            NameValueCollection obj = ReverseMapActualizar(cliente);
            string result = WebHelper.Put("cliente", obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        // Método para eliminar un cliente en particular dentro del JSON "Cliente", mediante el DELETE-REQUEST
        public TransactionResult Eliminar(Cliente eliminarCliente)
        {
            NameValueCollection obj = ReverseMap(eliminarCliente);
            string result = WebHelper.Post("cliente/"+eliminarCliente.id, obj);
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
            c.Add("id", cliente.id.ToString());
            c.Add("Nombre", cliente.Nombre);
            c.Add("Apellido", cliente.Apellido);
            c.Add("Direccion", cliente.Direccion);
            c.Add("Telefono", cliente.Telefono);
            c.Add("Email", cliente.Email);
            c.Add("DNI", cliente.DNI.ToString());
            c.Add("Activo", cliente.Activo.ToString());
            c.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            c.Add("Usuario", "890191");
            return c;
        }


        // Método privado utilizado por el PUT-REQUEST para mapear los nuevos valores de las variables correspondientes
        private NameValueCollection ReverseMapActualizar(ClienteMapper cliente)
        {
            NameValueCollection c = new NameValueCollection();
            c.Add("id", cliente.id.ToString());
            c.Add("Nombre", cliente.Nombre);
            c.Add("Apellido", cliente.Apellido);
            c.Add("Direccion", cliente.Direccion);
            c.Add("Telefono", cliente.Telefono);
            c.Add("Email", cliente.Email);
            c.Add("DNI", cliente.DNI.ToString());
            c.Add("Activo", cliente.Activo.ToString());
            c.Add("FechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            return c;
        }



        // Método privado utilizado por el POST/PUT/DELETE-REQUEST para formatear el resultado del objeto cliente
        private TransactionResult MapResultado(string json)
        {
            TransactionResult tr = JsonConvert.DeserializeObject<TransactionResult>(json);
            return tr;
        }

    }
}
