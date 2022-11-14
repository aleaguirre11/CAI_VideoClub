using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocio
{
    public class CopiaNegocio
    {
        private CopiaMapper _copiaMapper;
        private List<Copia> _listaCopias;
        public CopiaNegocio()
        {

            _copiaMapper = new CopiaMapper();
            _listaCopias = new List<Copia>();

        }

        //Dar de alta a las copias pidiendole al mapper que los inserte (post)
        public void AltaCopia(int idcopia,string observaciones, double precio, DateTime fechaalta, int idpelicula)
        {
            Copia copia = new Copia();
            copia.Idcopia = idcopia;
            copia.Observaciones = observaciones;
            copia.Precio = precio;
            copia.Fechaalta = fechaalta;
            copia.Idpelicula = idpelicula;
           
            

            //Validar que no se pueda dar de alta a una copia si ya se registro ese id

            TransactionResult transaction = _copiaMapper.Insertar(copia);

            //if (!transaction.IsOk)
            //    throw new Exception(transaction.Error);
        }

        //pedirle al mapper la lista de copias
        public List<Copia> TraerLista()
        {
            List<Copia> lst = _copiaMapper.TraerTodos();

            return lst;
        }

        //traer copia por id de pelicula
        public List<Copia> TraerPorIdPelicula(int idpelicula)
        {

            List<Copia> lst1 = new List<Copia>();

            if (_listaCopias.Count() > 0)
            {
                lst1.AddRange(_listaCopias.Where(item => item.Idpelicula == idpelicula));
            }
            else
                throw new Exception("No se han registrado copias de la pelicula aun.");

            return lst1;
        }

        //traer copia por nro de id
        //public Copia TraerPorId(int idcopia)
        //{
        //    foreach (var item in TraerLista())
        //    {
        //        if (idcopia == item.id)
        //            return item;
        //    }

        //    return null;
        //}

        //pedirle al mapper que actualice la copia (update)
        //private void ActualizarCopia(Copia copia)
        //{


        //    TransactionResult transaction = _copiaMapper.Actualizar(copia);

        //    if (!transaction.IsOk)
        //       throw new Exception(transaction.Error);
        //}

        //pedirle al mapper que elimine una copia (delete)
        //private void EliminarCopia(Copia copia)
        //{


        //    TransactionResult transaction = _copiaMapper.Eliminar(copia);

        //    if (!transaction.IsOk)
        //       throw new Exception(transaction.Error);
        //}
    }
}
