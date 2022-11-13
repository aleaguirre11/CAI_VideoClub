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
    public class PrestamoMapper
    {

        // Método para traer todos los préstamos que persisten en el JSON de la API
        public List<Prestamo> TraerTodos()
        {
            string json = WebHelper.Get("VideoClub/Prestamos");
            List<Prestamo> resultado = MapList(json);
            return resultado;
        }


        // Método para insertar nuevos préstamos dentro del JSON "Prestamos", mediante el POST-REQUEST
        public TransactionResult Insertar(Prestamo nuevoPrestamo)
        {
            NameValueCollection obj = ReverseMap(nuevoPrestamo);
            string result = WebHelper.Post("VideoClub/Prestamo", obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }

        // Método privado utilizado por el POST-REQUEST para mapear los valores de las variables correspondientes
        private NameValueCollection ReverseMap(Prestamo prestamo)
        {
            NameValueCollection pres = new NameValueCollection();
            pres.Add("idCliente", prestamo.Idcliente.ToString()); 
            pres.Add("idCopia", prestamo.Idcopia.ToString()); 
            pres.Add("Plazo", prestamo.Plazo.ToString());
            pres.Add("Abierto", prestamo.Abierto.ToString());
            pres.Add("FechaPrestamo", prestamo.Fechaprestamo.ToString());
            pres.Add("FechaDevolucionTentativa", prestamo.Fechadevoluciontentativa.ToString());
            pres.Add("FechaDevolucionReal", prestamo.Fechadevolucionreal.ToString());
            pres.Add("id", prestamo.Idprestamo.ToString());
            return pres;
        }


        // Método privado utilizado por los GET-REQUEST para formatear el resultado del listado de préstamos 
        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lst;
        }

        // Método privado utilizado por el POST/PUT/DELETE-REQUEST para recibir el resultado de los request en el JSON. El número 200 significa que el request funcionó correctamente.
        private TransactionResult MapResultado(string json)
        {
            TransactionResult tr = JsonConvert.DeserializeObject<TransactionResult>(json);
            return tr;
        }


    }
}
