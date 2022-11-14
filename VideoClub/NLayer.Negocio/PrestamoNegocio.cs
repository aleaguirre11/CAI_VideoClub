using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Negocio.ValidacionesNegocio;

namespace NLayer.Negocio
{
    public class PrestamoNegocio
    {
        private PrestamoMapper _prestamoMapper;
        private List<Prestamo> _listaPrestamos;
        public PrestamoNegocio()
        {
            _prestamoMapper = new PrestamoMapper();
            _listaPrestamos = new List<Prestamo>();

        }

        public void AltaPrestamo(int idprestamo, DateTime fechadevolucionreal, DateTime fechadevoluciontentativa, DateTime fechaprestamo, bool abierto, int plazo, int idcopia, int idcliente)
        {
            // validar prestamo no nulo

            Prestamo prestamo = new Prestamo();
            prestamo.Idprestamo = idprestamo;
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
            List<Prestamo> lst = _prestamoMapper.TraerTodos();

            return lst;
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
                copias.
                prestamos.AddRange(_listaPrestamos.Where(item => item.Idcopia == idcopia));
            }
            else
                throw new Exception("No se han otorgado prestamos de la copia {0} aun." + idcopia);

            return prestamos;
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



