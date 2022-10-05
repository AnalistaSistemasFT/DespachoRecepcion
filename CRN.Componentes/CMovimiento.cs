using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Transactions;

using CRN.Entidades;
using CAD;
namespace CRN.Componentes
{
    public class CMovimiento
    {
        CADMovimiento cadMovimiento = new CAD.CADMovimiento();
        CADMovDetalle cadMovDetalle= new CAD.CADMovDetalle ();

        public Movimiento oMovimiento=new Movimiento();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        public void GuardarMovimiento()
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            using (TransactionScope ts = new TransactionScope())
            {
                cadMovimiento.GuardarMovimiento (oMovimiento );
                foreach (MovDetalle  oDet in oMovimiento.Detalle )
                {
                    cadMovDetalle.GuardarMovDetalle(oDet,oMovimiento.TipoMovimiento );
                    int Numreg = cadMovDetalle.ModificarStock(oDet.SucursalId, oDet.ItemId, oDet.Cantidad, oDet.Peso, oDet.Piezas, oMovimiento.TipoMovimiento);
                }
                ts.Complete();
            }
        }
        public DataSet TraerTodoMovSync()
        {
            return cadMovimiento.TraerTodoMovSync();
        }
        public DataSet TraerTodoMovSync(string where)
        {
            return cadMovimiento.TraerTodoMovSync(where);
        }
        public DataSet TraerTodosLoscontenidos(int idcarpeta)
        {
            return cadMovimiento.TraerTodosLoscontenidos(idcarpeta);
        }
        public DataSet TraerOrdenRecepcionada(string OrdenId)
        {
            return cadMovimiento.TraerOrdenRecepcionada(OrdenId);
        }
        public DataSet TraerOrdenDespachada(string OrdenId)
        {
            return cadMovimiento.TraerOrdenDespachada(OrdenId);
        }
        public DataSet Consumido(string Centro,string Orden)
        {
            return cadMovimiento.Consumido(Orden, Centro);
        }
        public DataSet Producido(string Centro, string Orden)
        {
            return cadMovimiento.Producido(Orden, Centro);
        }

        //public int ModificarArchivo(MovSync oOrden )
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");
        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    return cadMovimiento.ModificarArchivos(oOrden);
        //}
     

        ////public Archivo TraerArchivo(int cod)
        ////{
        ////    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        ////    return oArchivo;
        ////}
        //public int EliminarArchivo(int cod)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadMovimiento.EliminarArchivosCarpetas(cod);
        //    return c;
        //}
        //public int MarcarEliminado(int cod, int Valor)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadMovimiento.MarcarEliminado(cod, Valor);
        //    return c;
        //}

        public bool ContieneArchivos(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoMovSync(where);
            //Agarra toda la tabla
            DataTable tArchivo = ds.Tables[0];
            //
            if (tArchivo.Rows.Count == 0)
            {
                return false;
            }
            else
                return true;

        }

        public DataSet BuscarDocumento(string nombDocumento)
        {
            return cadMovimiento.BuscarDocumento(nombDocumento);
        }
        //public void GuardarMovSync(MovSync oMovSync)
        //{
        //    //if (string.IsNullOrEmpty(oMovSync.Responsable))
        //    //    throw new ArgumentNullException("Responsable");
        //    //if (oPedido.Sucursal <= 0)
        //    //    throw new ArgumentOutOfRangeException("Sucursal");
        ////    if (oMovSync.SucursalPedido < 0)
        ////        throw new ArgumentOutOfRangeException("Sucursal de Origen");
        ////    foreach (MovSyncDetalle oDir in oPedido.Detalle)
        ////    {
        ////        if (oDir.Cantidad <= 0)
        ////            throw new ArgumentOutOfRangeException("Cantidad");
        ////    }
        //    if (string.IsNullOrEmpty(oMovSync.p_CentroTrabajo))
        //        throw new ArgumentNullException("CentroTrabajo");

        //    if (string.IsNullOrEmpty(oMovSync.p_Status))
        //        throw new ArgumentNullException("Status");

        //    if (string.IsNullOrEmpty(oMovSync.p_TipoOrden))
        //        throw new ArgumentNullException("TipoOrden");

        //    if (oMovSync.p_SucursalId <= 0)
        //        throw new ArgumentOutOfRangeException("Sucursal");
        //    DateTime Fecha = DateTime.Now;
        //    DateTime FechaCierre = DateTime.Now;

        //    //if (oPedido.Sucursal <= 0)
        //    //    throw new ArgumentOutOfRangeException("Sucursal");
        ////    DateTime fechaModificacion = DateTime.Now;

        ////    oPedido.Estado = ESTADO_VIGENTE;
        ////    oPedido.LoginReg = "";//Autenticacion.Usuario.Login;
        ////    oPedido.FechaReg = fechaModificacion;
        ////    oPedido.LoginMod = "";//Autenticacion.Usuario.Login;
        ////    oPedido.FechaMod = fechaModificacion;

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadMovimiento.GuardarMovSync(oMovSync);

        //        foreach (MovSyncDetalle oDir in oMovSync.Detalle)
        //        {
        //            oDir.p_OrdenId = oMovSync.p_OrdenId;

        //           //cadMovimiento.GuardarMovSync(oDir);
        //        }

        //        ts.Complete();
        //    }
        //}

        public void AnularPedido(int idCompra)
        {
            //cadPedido.AnularPedido(idCompra, Autenticacion.Usuario.Login, DateTime.Now);
        }
        //public MovSync traerEntrada(string OrdenId)
        //{

        //    MovSync oMovSync = cadMovimiento.TraerMovSync(OrdenId);
        //    List<MovSyncDetalle> detalle = cadMovSyncDetalle.TraerEntrada(OrdenId);
        //    foreach (MovSyncDetalle oDet in detalle)
        //    {
        //        oMovSync.Detalle.Add(oDet);
        //    }

        //    return oMovSync;
        //}
        public int UltimoNumero(int Gestion, int sucursal)
        {
           return cadMovimiento.UltimoNumero(Gestion, sucursal);
        }
         public string NuevoNumero(DateTime Fecha, int sucursal)
        {
            int gestion; int mes;
            gestion = Fecha.Year;
            mes = Fecha.Month;
            //oMovimiento = new Movimiento();
            Sucursal oSucursal = new Sucursal();
            CSucursal cSucursal = new CSucursal();
            oSucursal = cSucursal.TraerSucursal(sucursal);
            int newnumero = cadMovimiento.UltimoNumero(gestion, sucursal) + 1;
            oMovimiento.Correlativo = newnumero;
             
            string SNuevoNumero = oSucursal.Prefijo + "M" + gestion.ToString().Substring(2, 2) + serializa(newnumero, 6);
            //string SNuevoNumero = oSucursal.Prefijo + "M" + gestion.ToString().Substring(3, 2).Length + serializa(newnumero, 6).Length;
            return  SNuevoNumero;
        }
        public string serializa(int num, int dig)
        {
            string snum;
            snum = num.ToString().Trim();
            if (snum.Length > dig)

                snum = snum.Substring(3, dig);
            else
            {
                while (snum.Length < dig)
                {
                    snum = "0" + snum;

                }
            }
            return snum;
        }
    }
}
