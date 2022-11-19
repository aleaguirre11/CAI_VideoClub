using NLayer.Entidades;
using NLayer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AltaPrestamo(/*int idprestamo, DateTime fechadevolucionreal, DateTime fechadevoluciontentativa, DateTime fechaprestamo,*/ bool abierto,/* int plazo,*/ int idcopia, int idcliente)
        {
            // validar préstamo no nulo

            Prestamo prestamo = new Prestamo();
            //prestamo.Idprestamo = idprestamo;
            //prestamo.Fechadevolucionreal = fechadevolucionreal;
            //prestamo.Fechadevoluciontentativa = fechadevoluciontentativa; //(DateTime.Now).AddDays(10)
            //prestamo.Fechaprestamo = fechaprestamo;
            prestamo.Abierto = true;
            //prestamo.Plazo = plazo;
            prestamo.Idcopia = idcopia;
            prestamo.Idcliente = idcliente;

            //Validar que el cliente existe
            bool flag = ValidarCliente(prestamo.Idcliente);
            //Validar que la copia existe
            bool flag1 = ValidarCopia(prestamo.Idcopia);

            if (flag == false)
            {
                throw new Exception("No existe el cliente ingresado.");
            }
            else if (flag1 == false)
            {
                throw new Exception("No existe la copia ingresada.");
            }

            //Validar que no se pueda dar de alta un préstamos si el cliente tiene más de 3 préstamos abiertos
            int result = ValidarPrestamosIdCliente(prestamo.Idcliente);
            if (result >= 3)
            {
                throw new ExcepcionesNegocio.PrestamoLimiteException();

                //throw new Exception("El cliente ingresado hoy tiene 3 préstamos abiertos.");
            }

            TransactionResult transaction = _prestamoMapper.Insertar(prestamo);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public bool ValidarCliente(int idcli)
        {
            ClienteNegocio cn = new ClienteNegocio();

            if (!(cn.TraerLista().Count() > 0))
            {
                throw new ExcepcionesNegocio.ClienteException();

                //throw new Exception("No se han registrado clientes aun.");
            }
            else if (cn.TraerLista().Count() > 0)
            {
                foreach (var item in cn.TraerLista())
                {
                    if (idcli == item.Idcliente)
                    {
                        return true;
                    }
                        
                }
            }

            return false;
        }

        public bool ValidarCopia(int idcopy)
        {
            bool flag = false;
            CopiaNegocio copyN = new CopiaNegocio();
            
            List<Copia> copias = copyN.TraerLista();

            if (!(copias.Count() > 0))
            {
                throw new ExcepcionesNegocio.CopiaInexistenteEx();

                //throw new Exception("No se han registrado copias aun.");
            }
            else if (copias.Count() > 0)
            {
                foreach (var item in copias)
                {
                    if (idcopy == item.Idcopia)
                    {
                        
                        flag = false;
                        return flag;

                    }
                    else return true;

                }
            }
            else { throw new Exception("No existe la copia solicitada."); }


            return flag;
        }

        public int ValidarPrestamosIdCliente(int idclient)
        {
            int contador = 0;
            _listaPrestamos = _prestamoMapper.TraerTodos();
            if (!(_listaPrestamos.Count() > 0))
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }


            foreach (var item in TraerLista())//.TakeWhile(item => item.Abierto == true))
            {
                if(item.Abierto == true)
                {
                    if (idclient == item.Idcliente)
                        contador += 1;
                }
                
            }

            return contador;
        }

        public List<Prestamo> TraerLista()
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();

            if (!(_listaPrestamos.Count() > 0))
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }

            return _listaPrestamos;

        }


        //Consultar préstamos segun id del cliente
        public List<Prestamo> TraerPrestamoPorCliente(int idcliente)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            List<Prestamo> lst = new List<Prestamo>();

            if (_listaPrestamos.Count() > 0)
            {
                lst.AddRange(_listaPrestamos.Where(item => item.Idcliente == idcliente));
            }
            else
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }

            return lst;
        }

        //Consultar préstamos segun dni del cliente
        public List<Prestamo> TraerPrestamoPorDNI(int dni)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            List<Prestamo> lst = new List<Prestamo>();
            ClienteNegocio cn = new ClienteNegocio();

            if (_listaPrestamos.Count() > 0)
            {

                int id = cn.TraerIdPorDNI(dni);

                lst.AddRange(_listaPrestamos.Where(item => item.Idcliente == id));
            }
            else
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }

            return lst;
        }

        public Prestamo TraerPorId(int idprestamo)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            Prestamo p = new Prestamo();

            if (!(_listaPrestamos.Count() > 0))
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }

            foreach (var item in TraerLista())
            {
                if (idprestamo == item.Idprestamo)
                {
                    p = item;
                    return p;
                }
                else
                {
                    p = null;
                    return p;
                }
                    
            }

            return p;


        }

        //trar préstamos por id de copia
        public List<Prestamo> TraerPorIdCopia(int idcopia)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            List<Prestamo> lst = new List<Prestamo>();


            if (_listaPrestamos.Count() > 0)
            {
                lst.AddRange(_listaPrestamos.Where(item => item.Idcopia == idcopia));
            }
            else
                throw new Exception("No se han otorgado prestamos de la copia {0} aun." + idcopia);

            return lst;
        }


        //Consultar préstamos por id pelicula
        public List<Prestamo> TraerPorIdPelicula(int idpelicula)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();

            List<Prestamo> prestamos = new List<Prestamo>();
            List<Copia> copias = new List<Copia>();
            CopiaNegocio CN = new CopiaNegocio();

            _listacopias = CN.TraerLista();

            if (_listaPrestamos.Count() > 0)
            {


                if (_listacopias.Count() > 0)
                {
                    copias.AddRange(_listacopias.Where(c => c.Idpelicula == idpelicula));

                    foreach (var c in copias)
                    {
                        foreach (var p in TraerLista())//.TakeWhile(p => p.Idcopia == c.Idcopia))
                        {
                            if (p.Idcopia == c.Idcopia)
                            {
                                prestamos.Add(p);
                            }
                            
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

        //Consultar préstamos por id pelicula
        public string TraerPorIdPelicula2(int idpelicula)
        {

            _listaPrestamos = _prestamoMapper.TraerTodos();
            CopiaNegocio CN = new CopiaNegocio();
            _listacopias = CN.TraerLista();

            List<Copia> copias = new List<Copia>();
            string acumulador = "Los prestamos asociados a la película ingresada son: " + System.Environment.NewLine;

            if (_listaPrestamos.Count() > 0)
            {

                if (_listacopias.Count() > 0)
                {
                    copias.AddRange(_listacopias.Where(c => c.Idpelicula == idpelicula));

                    foreach (var p in TraerLista())
                    {

                        foreach (var c in copias)//.TakeWhile(c => c.Idcopia == p.Idcopia))
                        {
                            if (c.Idcopia == p.Idcopia)
                            {
                                acumulador += c.ToString() + System.Environment.NewLine;
                            }

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

        //Poder emitir un reporte de préstamos por cliente a partir del ID del cliente.
        public List<Prestamo> ReportePrestamoCliente(int idCliente)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            Cliente c = new Cliente();
            ClienteNegocio cn = new ClienteNegocio();
            c = cn.BuscarClientePorID(idCliente);

            if (c == null)
            {
                throw new Exception("Error de ingreso.");
            }

            if (!(c is Cliente))
            {
                throw new Exception("Error de ingreso.");
            }

            PrestamoNegocio prest = new PrestamoNegocio();
            List<Prestamo> prestamos = prest.TraerLista();

            List<Prestamo> PrCliente = new List<Prestamo>();

            if (!(_listaPrestamos.Count() > 0))
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }
            else if (_listaPrestamos.Count() > 0)
            {
                foreach (Prestamo p in prestamos)//.TakeWhile(p => p.Idcliente == Convert.ToInt32(c.Idcliente)))
                {
                    if (p.Idcliente == c.Idcliente)
                    {
                        PrCliente = prest.TraerPrestamoPorCliente(c.Idcliente);
                    }

                }
            }

            if (!(PrCliente.Count() > 0))
            {
                throw new Exception("El cliente no tiene préstamos aun.");
            }

            return PrCliente;


        }

        //Poder emitir un reporte de préstamos por cliente a partir del DNI del cliente.
        public List<Prestamo> ReportePrestamoCliente2(int dni)
        {
            _listaPrestamos = _prestamoMapper.TraerTodos();
            Cliente c = new Cliente();
            ClienteNegocio cn = new ClienteNegocio();
            c = cn.BuscarClientePorDNI(dni);

            if (c == null)
            {
                throw new Exception("Error de ingreso.");
            }

            if (!(c is Cliente))
            {
                throw new Exception("Error de ingreso.");
            }

            PrestamoNegocio prest = new PrestamoNegocio();
            List<Prestamo> prestamos = prest.TraerLista();

            List<Prestamo> PrCliente = new List<Prestamo>();

            if (!(_listaPrestamos.Count() > 0))
            {
                throw new ExcepcionesNegocio.PrestamoException();

                //throw new Exception("No se han registrado préstamos aun.");
            }
            else if (_listaPrestamos.Count() > 0)
            {
                foreach (Prestamo p in prestamos)//.TakeWhile(p => p.Idcliente == Convert.ToInt32(c.Idcliente)))
                {
                    if (p.Idcliente == c.Idcliente)
                    {
                        PrCliente = prest.TraerPrestamoPorCliente(c.Idcliente);
                    }

                }
            }


            if (!(PrCliente.Count() > 0))
            {
                throw new Exception("El cliente no tiene préstamos aun.");
            }

            return PrCliente;


        }

    }

}



