using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NLayer.Negocio
{
    public class PrestamoNegocio
    {
        private PrestamoMapper _prestamoMapper;
        public PrestamoNegocio()
        {
            _prestamoMapper = new PrestamoMapper();

        }

        public void AltaPrestamo(int idprestamo, DateTime fechadevolucionreal, DateTime fechadevoluciontentativa, DateTime fechaprestamo, bool abierto, int plazo, int idcopia, int idcliente)
        {
            // validar prestamo no nulo

            Prestamo prestamo = new Prestamo();
            prestamo.Idprestamo = idprestamo;
            prestamo.Fechadevolucionreal = fechadevolucionreal;
            prestamo.Fechadevoluciontentativa = fechadevoluciontentativa;
            prestamo.Fechaprestamo = fechaprestamo;
            prestamo.Abierto = abierto;
            prestamo.Plazo = plazo;
            prestamo.Idcopia = idcopia;
            prestamo.Idcliente = idcliente;


            TransactionResult transaction = _prestamoMapper.Insertar(prestamo);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
        }

        public List<Prestamo> TraerLista()
        {
            List<Prestamo> lst = _prestamoMapper.TraerTodos();

            return lst;
        }

        public Prestamo TraerPrestamoPorCliente(Prestamo idcliente)
        {
            //validar id no nulo
            List<Prestamo> lst1 = _prestamoMapper.TraerPorId(idcliente);

            return lst1;
        }

        //public Prestamo TraerPrestamoPorCliente(Cliente idcliente)
        //{
        //    // validar cliente no nulo
        //    List<Prestamo> lst = _prestamoMapper.TraerPorId(cliente.idcliente);

        //    return lst;
        //}


        public Prestamo TraerPorId(int idprestamo)
        {
            foreach (var item in TraerLista())
            {
                if (idprestamo == item.id)
                    return item;
            }

            return null;
        }

        //cancelar el prestamo por su id (unico prestamo)
        public void CancelarPrestamoPorIdPrestamo(Prestamo idprestamo)
        {
            
            // validar prestamo no nulo
            var item = TraerPorId(idprestamo);

            ActualizarPrestamo(item);
            TransactionResult transaction = _prestamoMapper.Cancelar(item);

        }

        //si el cliente desea cancelar todos sus prestamos de una vez, buscar por Id del cliente y cancelar todos
        public void CancelarPrestamoPorIdCliente(Prestamo idcliente)
        {
            // validar idcliente no nulo

            foreach (var item in TraerPrestamoPorCliente(idcliente))
            {
                if (item.abierto == true)
                    ActualizarPrestamo(item);
                TransactionResult transaction = _prestamoMapper.Cancelar(item);
            }

        }

        public void ActualizarPrestamo(Prestamo prestamo)
        { 
            // validar prestamo no nulo y no cancelado

            prestamo.abierto = false;
            
        }
    }

}



