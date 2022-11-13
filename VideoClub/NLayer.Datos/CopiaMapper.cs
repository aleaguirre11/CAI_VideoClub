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
    public class CopiaMapper
    {
        // Método para traer todas las copias que persisten en el JSON de la API
        public List<Copia> TraerTodos()
        {
            string json = WebHelper.Get("VideoClub/Copia");
            List<Copia> resultado = MapList(json);
            return resultado;
        }


        // Método para traer todas las çopias según el id de la película
        public List<Copia> TraerPorIdPelicula(int idPelicula)
        {
            string json = WebHelper.Get("VideoClub/Copia/" + idPelicula.ToString());
            List<Copia> resultado = MapList(json);
            return resultado;
        }

        // Método para insertar nuevas películas dentro del JSON "Copia", mediante el POST-REQUEST
        public TransactionResult Insertar(Copia nuevaCopia)
        {
            NameValueCollection obj = ReverseMap(nuevaCopia);
            string result = WebHelper.Post("VideoClub/Copia", obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        // Método privado utilizado por el POST-REQUEST para mapear los valores de las variables correspondientes
        private NameValueCollection ReverseMap(Copia copia)
        {
            NameValueCollection cop = new NameValueCollection();
            cop.Add("idPelicula", copia.Idpelicula.ToString());
            cop.Add("Observaciones", copia.Observaciones);
            cop.Add("Precio", copia.Precio.ToString());
            cop.Add("FechaAlta", copia.Fechaalta.ToString("yyyy-MM-dd"));
            cop.Add("id", copia.Idcopia.ToString());
            return cop;

        }


        // Método privado utilizado por los GET-REQUEST para formatear el resultado del listado de copias 
        private List<Copia> MapList(string json)
        {
            List<Copia> lst = JsonConvert.DeserializeObject<List<Copia>>(json);
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
