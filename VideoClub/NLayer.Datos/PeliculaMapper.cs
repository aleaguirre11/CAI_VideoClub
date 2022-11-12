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
    public class PeliculaMapper
    {

        // Método para traer todas las películas que persisten en el JSON de la API
        public List<Pelicula> TraerTodos()
        {
            string json = WebHelper.Get("VideoClub/Pelicula");
            List<Pelicula> resultado = MapList(json);
            return resultado;
        }


        // Método para traer todas las películas según el id de la película
        public List<Pelicula> TraerPorID(int id)
        {
            string json = WebHelper.Get("VideoClub/Pelicula/" + id.ToString());
            List<Pelicula> resultado = MapList(json);
            return resultado;
        }


        // Método para insertar nuevas películas dentro del JSON "Pelicula", mediante el POST-REQUEST
        public TransactionResult Insertar(Pelicula nuevaPelicula)
        {
            NameValueCollection obj = ReverseMap(nuevaPelicula);
            string result = WebHelper.Post("VideoClub/Pelicula", obj);
            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        // Método privado utilizado por los GET-REQUEST para formatear el resultado del listado de películas 
        private List<Pelicula> MapList(string json)
        {
            List<Pelicula> lst = JsonConvert.DeserializeObject<List<Pelicula>>(json);
            return lst;
        }


        // Método privado utilizado por el POST-REQUEST para mapear los valores de las variables correspondientes
        private NameValueCollection ReverseMap(Pelicula pelicula)
        {
            NameValueCollection p = new NameValueCollection();
            p.Add("anio", pelicula.Anio.ToString());
            p.Add("duracion", pelicula.Duracion.ToString());
            p.Add("titulo", pelicula.Titulo);
            p.Add("director", pelicula.Director);
            p.Add("productora", pelicula.Productora);
            p.Add("genero", pelicula.Genero);
            p.Add("id", pelicula.IdPelicula.ToString());
            return p;
        }



        // Método privado utilizado por el POST/PUT/DELETE-REQUEST para recibir el resultado de los request en el JSON. El número 200 significa que el request funcionó correctamente.
        private TransactionResult MapResultado(string json)
        {
            TransactionResult tr = JsonConvert.DeserializeObject<TransactionResult>(json);
            return tr;
        }

    }
}