﻿using NLayer.Entidades;
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
        public void AltaCopia(/*int idcopia,*/string observaciones, double precio, DateTime fechaalta, int idpelicula)
        {
            Copia copia = new Copia();
            //copia.Idcopia = idcopia; //Se comenta porque el id se autogenera
            copia.Observaciones = observaciones;
            copia.Precio = precio;
            copia.Fechaalta = fechaalta;
            copia.Idpelicula = idpelicula;

            //Validar que no se pueda dar de alta a una copia si ya se registro ese id
            //bool flag = ValidarCopiaExistente(copia.Idcopia); //Se comenta porque el id se autogenera
            //Validar que no se pueda dar de alta a una copia si no se registro el id de pelicula
            bool flag1 = ValidarPeliculaExistente(copia.Idpelicula);
            //Validar que precio no sea inferior a $500
            bool flag2 = ValidarPrecioCopia(copia.Precio);


            //if(flag == true) 
            //{
            //    throw new Exception("Ya existe una copia con ese ID.");
            //}
            if (flag1 == false)
            {
                throw new Exception("No existe la película ingresada.");
            }
            if (flag2 == false)
            {
                throw new Exception("Se ingresó un precio no válido.");
            }

            TransactionResult transaction = _copiaMapper.Insertar(copia);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        //se comenta porque el ID se autogenera
        //public bool ValidarCopiaExistente(int idcopy)
        //{
        //    if (!(_listaCopias.Count() > 0))
        //        throw new Exception("No se han registrado copias aun.");

        //    foreach (var item in TraerLista())
        //    {
        //        if (idcopy == item.Idcopia)
        //            return true;
        //    }

        //    return false;
        //}

        //Validación de pelicula existente 
        public bool ValidarPeliculaExistente(int idpeli)
        {
            PeliculaNegocio peliN = new PeliculaNegocio();


            if (!(peliN.TraerLista().Count() > 0))
            throw new Exception("No se han registrado películas aun.");


            foreach (var item in peliN.TraerLista())
            {
                if (idpeli == item.IdPelicula)
                    return true;
            }

            return false;
        }

        //Validar precio de la copia no inferior a 500 para darla de alta
        public bool ValidarPrecioCopia(double price)
        {
            if (price >= 500.0)
                return true;

            return false;
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

        //Una pelicula tiene un unico id pero puede tener mas de una copia
        public int TraerTotalCopias(int idpelicula)
        {
            //validar id no nulo
            int contador = 0;

            foreach (var item in TraerLista())
            {
                if (idpelicula == item.Idpelicula)
                    contador++;

            }

            return contador;
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

        //Poder emitir un reporte de copias por película.
    }
}
