using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Negocio.ValidacionesNegocio;
using System.ComponentModel;

namespace NLayer.Negocio
{
    public class PrestamoNegocio
    {
        private PrestamoMapper _prestamoMapper;
        private List<Prestamo> _listaPrestamos;
        private List<Copia> _listacopias;
        public PrestamoNegocio()
        {
            _prestamoMapper = new PrestamoMapper();
            _listaPrestamos = new List<Prestamo>();
            _listacopias = new List<Copia>();

        }

        public void AltaPrestamo(/*int idprestamo,*/ DateTime fechadevolucionreal, DateTime fechadevoluciontentativa, DateTime fechaprestamo, bool abierto, int plazo, int idcopia, int idcliente)
        {
            // validar prestamo no nulo

            Prestamo prestamo = new Prestamo();
            //prestamo.Idprestamo = idprestamo;
            prestamo.Fechadevolucionreal = fechadevolucionreal;
            prestamo.Fechadevoluciontentativa = fechadevoluciontentativa; //(DateTime.Now).AddDays(10)
            prestamo.Fechaprestamo = fechaprestamo;
            prestamo.Abierto = true;
            prestamo.Plazo = plazo;
            prestamo.Idcopia = idcopia;
            prestamo.Idcliente = idcliente;


            TransactionResult transaction = _prestamoMapper.Insertar(prestamo);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public List<Prestamo> TraerLista()
        {
            return _prestamoMapper.TraerTodos();

        }

     

        //public List<Prestamo> TraerPrestamoPorCliente(int idcliente)
        //{
        //    // validar cliente no nulo
        //    List<Prestamo> lst = _prestamoMapper.TraerPorId(idcliente);

        //    return lst;
        //}


        public Prestamo TraerPorId(int idprestamo)
        {
            foreach (var item in TraerLista())
            {
                if (idprestamo == item.Idprestamo)
                    return item;
            }

            return null;
        }

        //trar prestamos por id de copia
        public List<Prestamo> TraerPorIdCopia(int idcopia)
        {

            List<Prestamo> lst = new List<Prestamo>();


            if (_listaPrestamos.Count() > 0)
            {
                lst.AddRange(_listaPrestamos.Where(item => item.Idcopia == idcopia));
            }
            else
                throw new Exception("No se han otorgado prestamos de la copia {0} aun." + idcopia);

            return lst;
        }


        //Consultar prestamos por id pelicula
        public List<Prestamo> TraerPorIdPelicula(int idpelicula)
        {

            List<Prestamo> prestamos = new List<Prestamo>();
            List<Copia> copias = new List<Copia>();



            if (_listaPrestamos.Count() > 0)
            {


                if (_listacopias.Count() > 0)
                {
                    copias.AddRange(_listacopias.Where(c => c.Idpelicula == idpelicula));

                    foreach (var c in copias) 
                    {
                        foreach (var p in TraerLista().TakeWhile(p => p.Idcopia == c.Idcopia))
                        {
                            prestamos.Add(p);
                        }

                    }

                }
                else
                    throw new Exception("No se han otorgado préstamos de la copia aun.");

            }
            else
                throw new Exception("No se han otorgado prestamos de la película {0} aun." + idpelicula);

            return prestamos;
        }

        //Consultar prestamos por id pelicula
        public string TraerPorIdPelicula2(int idpelicula)
        {


            List<Copia> copias = new List<Copia>();
            string acumulador = "Los prestamos asociados a la película ingresada son: " + System.Environment.NewLine;

            if (_listaPrestamos.Count() > 0)
            {

                if (_listacopias.Count() > 0)
                {
                    copias.AddRange(_listacopias.Where(c => c.Idpelicula == idpelicula));

                    foreach (var p in TraerLista())
                    {

                        foreach (var c in copias.TakeWhile(c => c.Idcopia == p.Idcopia))
                        {
                            acumulador += c.ToString() + System.Environment.NewLine;

                        }

                    }

                }
                else
                    throw new Exception("No se han otorgado préstamos de la copia aun.");

            }
            else
                throw new Exception("No se han otorgado prestamos de la película {0} aun." + idpelicula);

            return acumulador;
        }

        //cancelar el prestamo por su id(unico prestamo)
        //public void CancelarPrestamoPorIdPrestamo(Prestamo prestamo)
        //{
        //    foreach (Prestamo p in TraerLista())
        //    {
        //        if (prestamo.Idprestamo == p.Idprestamo)
        //            ActualizarPrestamo(p);
        //        TransactionResult transaction = _prestamoMapper.Cancelar(p); //actualizar prestamo

        //        if (!transaction.IsOk)
        //            throw new Exception(transaction.Error);
        //    }

        //}

        //public void ActualizarPrestamo(Object obj)
        //{
        //    // validar prestamo no nulo y no cancelado
        //    if (obj == null) throw new Exception("El prestamo es invalido.");
        //    if (!(obj is Prestamo)) throw new Exception("No se ingresó un prestamo.");

        //    Prestamo pObj = (Prestamo)obj;

        //    if (pObj.Abierto != true)
        //        throw new Exception("El prestamo ya se cerró.");

        //    pObj.Fechadevolucionreal = DateTime.Now;
        //    pObj.Abierto = false;

        //}
    }

}



