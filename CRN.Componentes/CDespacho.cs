using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Transactions;

using CRN.Entidades;
using CAD;
using System.Data.SqlClient;
using System.Data.Common;
using static System.Net.Mime.MediaTypeNames;

namespace CRN.Componentes
{
    public class CDespacho : oledb
    {
        private string DespachoId;
        private DateTime Fecha;
        private string NroOrden;
        private int Id_Camion;
        private string Placa;
        private string Marca;
        private string Chofer;
        private string CI;
        private string Destino;
        private string Login;
        private string status;
        private int Correlativo;
        private string Obs;
        private string Tipo;
        private string Cargador;
        private string NumTraspaso;
        private int SucursalId;
        private int SucDestino;
        private DateTime HorarioPartida;
        private DateTime HorarioLlegada;
        private string Naturaleza;
        private int Anticipado;
        private int Entregado;
        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public DateTime p_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public string p_NroOrden
        {
            get { return NroOrden; }
            set { NroOrden = value; }
        }
        public int p_Id_Camion
        {
            get { return Id_Camion; }
            set { Id_Camion = value; }
        }
        public string p_Placa
        {
            get { return Placa; }
            set { Placa = value; }
        }
        public string p_Marca
        {
            get { return Marca; }
            set { Marca = value; }
        }
        public string p_Chofer
        {
            get { return Chofer; }
            set { Chofer = value; }
        }
        public string p_CI
        {
            get { return CI; }
            set { CI = value; }
        }
        public string p_Destino
        {
            get { return Destino; }
            set { Destino = value; }
        }
        public string p_Login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string p_status
        {
            get { return status; }
            set { status = value; }
        }
        public int p_Correlativo
        {
            get { return Correlativo; }
            set { Correlativo = value; }
        }
        public string p_Obs
        {
            get { return Obs; }
            set { Obs = value; }
        }
        public string p_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public string p_Cargador
        {
            get { return Cargador; }
            set { Cargador = value; }
        }
        public string p_NumTraspaso
        {
            get { return NumTraspaso; }
            set { NumTraspaso = value; }
        }
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
        public int p_SucDestino
        {
            get { return SucDestino; }
            set { SucDestino = value; }
        }
        public DateTime p_HorarioPartida
        {
            get { return HorarioPartida; }
            set { HorarioPartida = value; }
        }
        public DateTime p_HorarioLlegada
        {
            get { return HorarioLlegada; }
            set { HorarioLlegada = value; }
        }
        public string p_Naturaleza
        {
            get { return Naturaleza; }
            set { Naturaleza = value; }
        }
        public int p_Anticipado
        {
            get { return Anticipado; }
            set { Anticipado = value; }
        }
        public int p_Entregado
        {
            get { return Entregado; }
            set { Entregado = value; }
        }
        //
        public CDespacho()
        {
            this.sConnName = "SQLSERVER"; 
        }
        CADDespacho cadDespacho = new CAD.CADDespacho();

        public int GuardarDespacho(Despacho oDespacho, DbTransaction dbTr)
        {
            return cadDespacho.GuardarDespacho(oDespacho, dbTr);
        }
        public DataSet TraerUltimoId()
        {
            return cadDespacho.TraerUltimoId();
        }
        public DataSet TraerTodoDespacho()
        {
            return cadDespacho.TraerTodoDespacho();
        }
	    public DataSet TraerEditarDetalleDespacho(string IdDespacho)
        {
            return cadDespacho.TraerEditarDetalleDespacho(IdDespacho);
        }
        public DataSet TraerDespachoBuscar(string IdDespacho)
        {
            return cadDespacho.TraerDespachoBuscar(IdDespacho);
        }
        public DataSet TraerDespachoAbierto(int _idSucursal)
        {
            return cadDespacho.TraerDespachoAbierto(_idSucursal);
        }
        public DataSet TraerDespachoAbiertoVenta(int _idSucursal)
        {
            return cadDespacho.TraerDespachoAbiertoVenta(_idSucursal);
        }
        public DataSet TraerDespachoEnProgreso(int _idSucursal)
        {
            return cadDespacho.TraerDespachoEnProceso(_idSucursal);
        }
        public DataSet TraerDespachoEnProgresoVenta(int _idSucursal)
        {
            return cadDespacho.TraerDespachoEnProcesoVenta(_idSucursal);
        }
        public DataSet TraerDespachoParcial(int _idSucursal)
        {
            return cadDespacho.TraerDespachoParcial(_idSucursal);
        }
        public DataSet TraerDespachoParcialVenta(int _idSucursal)
        {
            return cadDespacho.TraerDespachoParcialVenta(_idSucursal);
        }
        public DataSet TraerDespachoPorCerrar(int _idSucursal)
        {
            return cadDespacho.TraerDespachoPorCerrar(_idSucursal);
        }
        public DataSet TraerDespachoPorCerrarVenta(int _idSucursal)
        {
            return cadDespacho.TraerDespachoPorCerrarVenta(_idSucursal);
        }
        public DataSet TraerDespachoCerrado(int _idSucursal)
        {
            return cadDespacho.TraerDespachoCerrado(_idSucursal);
        }
        public DataSet TraerDespachoCerradoVenta(int _idSucursal)
        {
            return cadDespacho.TraerDespachoCerradoVenta(_idSucursal);
        }
        public DataSet TraerTodosLosDespachos(int _idSucursal)
        {
            return cadDespacho.TraerTodosLosDespachos(_idSucursal);
        }
        public DataSet TraerTodosLosDespachosVenta(int _idSucursal)
        {
            return cadDespacho.TraerTodosLosDespachosVenta(_idSucursal);
        }
        public DataSet TraerDespachosPendientes(int _idSucursal)
        {
            return cadDespacho.TraerDespachosPendientes(_idSucursal);
        }
        public DataSet TraerDespachoTransito(int _idSucursal)
        {
            return cadDespacho.TraerDespachoTransito(_idSucursal);
        }
        public DataSet TraerDespachoCancelado(int _idSucursal)
        {
            return cadDespacho.TraerDespachoCancelado(_idSucursal);
        }
        public DataSet TraerDespachoEntregar(int _idSucursal)
        {
            return cadDespacho.TraerDespachoEntregar(_idSucursal);
        }
        public DataSet TraerDetalleDespacho(string _idDespacho)
        {
            return cadDespacho.TraerDetalleDespacho(_idDespacho);
        }
        public DataSet TraerDetalleDespachoSumCelda(string _idDespacho, string _itemId)
        {
            return cadDespacho.TraerDetalleDespachoSumCelda(_idDespacho, _itemId);
        }
        public DataSet TraerDetalleDespachoSumSob(string _idDespacho, string _itemId)
        {
            return cadDespacho.TraerDetalleDespachoSumSob(_idDespacho, _itemId);
        }
        public DataSet TraerPzaPaq(int _idSucursal, string _ItemId)
        {
            return cadDespacho.TraerPzaPaq(_idSucursal, _ItemId);
        }
        public DataSet TraerDetalleDespachoEntrega(string _idDespacho)
        {
            return cadDespacho.TraerDetalleDespachoEntrega(_idDespacho);
        }
        //ModificarDespacho
        public int EditarDespacho(DespachoEditar _despEdit)
        {
            return cadDespacho.EditarDespacho(_despEdit);
        }
        //Para traspaso
        public DataSet TraerDespDetalleTrasp(string _idDespacho)
        {
            return cadDespacho.TraerDespDetalleTrasp(_idDespacho);
        }
        public DataSet TraerDespProducto(string _idDespacho)
        {
            return cadDespacho.TraerDespProductos(_idDespacho);
        }
        public DataSet TraerDetalleCerrarDespacho(string _idDespacho)
        {
            return cadDespacho.TraerDetalleCerrarDespacho(_idDespacho);
        }
        public DataSet TraerTodoDespacho(string where)
        {
            return cadDespacho.TraerTodoDespacho(where);
        }
        public DataSet TraerTodoDespacho(string estado, int sucursal)
        {
            return cadDespacho.TraerTodoDespacho(estado, sucursal);
        }
        public int ModificarArchivo(Despacho oDespacho)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadDespacho.ModificarDespacho(oDespacho);
        }
        public DataSet TraerDestinoId(string _idDespacho)
        {
            return cadDespacho.TraerDestinoId(_idDespacho);
        }
        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}

        public int MarcarEliminado(int cod, int Valor)
        {
            //MovSync oMovSync = new MovSync();
            int c = cadDespacho.MarcarEliminado(cod, Valor);
            return c;
        }

        public bool ContieneArchivos(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoDespacho(where);
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
        public DataSet BuscarDespacho(string nombDocumento)
        {
            return cadDespacho.BuscarDespacho(nombDocumento);
        }
        public DataSet ConsultarDespacho(string _IdDespacho)
        {
            return cadDespacho.ConsultarDespacho(_IdDespacho);
        }
        public DataSet ConsultarDespachoEntrega(string _IdDespacho)
        {
            return cadDespacho.ConsultarDespachoEntrega(_IdDespacho);
        }
        public DataSet TraerDataNroOrden(int _IdSucursal, string _ItemFId)
        {
            return cadDespacho.TraerDataNroOrden(_IdSucursal, _ItemFId);
        }
        public int EliminarDespacho(string _IdDespacho)
        {
            return cadDespacho.EliminarDespacho(_IdDespacho);
        }
        //Ejecutar
        public int ModificarEjecutarAenProceso(string _IdDespacho)
        {
            return cadDespacho.ModificarEjecutarAenProceso(_IdDespacho);
        }
        public int ModificarEjecutarAParcial(string _IdDespacho)
        {
            return cadDespacho.ModificarEjecutarAParcial(_IdDespacho);
        }
        public int ModificarEjecutarAListaACerrar(string _IdDespacho)
        {
            return cadDespacho.ModificarEjecutarAListaACerrar(_IdDespacho);
        }
        public int ModificarEjecutarACerrar(string _IdDespacho)
        {
            return cadDespacho.ModificarEjecutarACerrar(_IdDespacho);
        }
        //Undo
        public int ModificarUndoAListaACerrar(string _idDespacho)
        {
            return cadDespacho.ModificarUndoAListaACerrar(_idDespacho);
        }
        public int ModificarUndoAParcial(string _idDespacho)
        {
            return cadDespacho.ModificarUndoAParcial(_idDespacho);
        }
        public int ModificarUndoAEnProceso(string _idDespacho)
        {
            return cadDespacho.ModificarUndoAEnProceso(_idDespacho);
        }
        public int ModificarUndoAAbierto(string _idDespacho)
        {
            return cadDespacho.ModificarUndoAAbierto(_idDespacho);
        }
        //Obs
        public DataSet TraerObsDespacho(string _idDespacho)
        {
            return cadDespacho.TraerObsDespacho(_idDespacho);
        }
        public int ModificarObsDespacho(string _idDespacho, string _obs)
        {
            return cadDespacho.ModificarObsDespacho(_idDespacho, _obs);
        }
        //InsertarDespacho
        public int InsertDespacho(Despacho _despacho, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblDespacho
                                    ([DespachoId],[Fecha],[NroOrden],[Id_Camion],[Placa],[Marca],[Chofer],[CI],[Destino],[Login],[status],[Correlativo],[Obs],[Tipo],[Cargador],[NumTraspaso],[SucursalId],[SucDestino],[HorarioPartida],[HorarioLlegada],[Naturaleza],[Anticipado], [Entregado])
                                VALUES
                                      ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}',{16},{17},{18},{19},'{20}',{21}, {22})";
            sInsert = string.Format(sInsert, _despacho.p_DespachoId, _despacho.p_Fecha.ToString("dd/MM/yyyy"), _despacho.p_NroOrden, _despacho.p_Id_Camion, _despacho.p_Placa, _despacho.p_Marca, _despacho.p_Chofer, _despacho.p_CI, _despacho.p_Destino, _despacho.p_Login, _despacho.p_status, _despacho.p_Correlativo, _despacho.p_Obs, _despacho.p_Tipo, _despacho.p_Cargador, _despacho.p_NumTraspaso, _despacho.p_SucursalId, _despacho.p_SucDestino, _despacho.p_HorarioPartida.ToString("dd/MM/yyyy"), _despacho.p_HorarioLlegada.ToString("dd/MM/yyyy"), _despacho.p_Naturaleza, _despacho.p_Anticipado, _despacho.p_Entregado);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        //Buscar para traspaso
        public DataSet TraerDespachoTraspaso(string _despachoId)
        {
            return cadDespacho.TraerDespachoTraspaso(_despachoId);
        }
        //TraerSecuencia
        public string TraerSecuencia(int Suscursal, string sTipo)
        {
            string sSelet = "select * from Sys_Secuencia where Operacion = '{0}' and sucursal={1}";
            sSelet = string.Format(sSelet, sTipo, Suscursal);
            DataTable dtsResult = consultar(sSelet).Tables[0];
            string sSecuencia = "";
            if (dtsResult.Rows.Count > 0)
            {
                string sContador = dtsResult.Rows[0]["Contador"].ToString();
                string sFijo = dtsResult.Rows[0]["Fijo"].ToString();
                int iSiguiente = 0;
                string year = "0";
                switch (dtsResult.Rows[0]["Reset"].ToString())
                {

                    case "y":
                        year = (sContador.Substring(2, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        ///////////////////////////////////////////////////////////////////
                        iSiguiente = Convert.ToInt32(sContador.Substring(4, 6)) + 1;
                        sSecuencia = sFijo + year + (iSiguiente.ToString("D6"));
                        break;
                    case "m":
                        year = (sContador.Substring(0, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        string Mes = (sContador.Substring(2, 2));
                        if (Mes != DateTime.Now.Month.ToString())
                            Mes = DateTime.Now.Month.ToString("D2");
                        iSiguiente = Convert.ToInt32(sContador.Substring(6, 5)) + 1;
                        sSecuencia = year + Mes + sFijo + (iSiguiente.ToString("D5"));
                        break;
                }
            }
            return sSecuencia;
        }
        //Actualizar Secuencia
        public int ActualizarSecuencia(int iSucursal, string Operacion, string Contador, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "update Sys_Secuencia set Contador = '" + Contador + "' where  sucursal=" + iSucursal + " and Operacion = '" + Operacion + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy);
        }
        public int InsertarDespacho(out string sError, Despacho _despacho, DataTable dt, int isucursal)
        {
            sError = string.Empty;
            string _metodo = "Ok";
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                CSys_Secuencia C_sysSecuencia = new CSys_Secuencia();
                string sDespacho = C_sysSecuencia.TraerSecuencia(isucursal, "DESPACHO");
                _metodo = "Insertar Despacho";
                int a = this.InsertDespacho(_despacho, trnSql);
                if (a > 0)
                {
                    DespDetalle _despDetalle = new DespDetalle();
                    if (dt.Rows.Count == 0)
                    {
                        _metodo = "Actualizar Secuencia";
                        a = ActualizarSecuencia(isucursal, "DESPACHO", sDespacho, trnSql);
                        if (a > 0)
                        {
                            trnSql.Commit();
                            //trnSql.Rollback();
                            //trnSql.Dispose();
                        }
                        else
                        {
                            trnSql.Rollback();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            _despDetalle.p_DespachoId = dt.Rows[i][0].ToString();
                            _despDetalle.p_ItemId = dt.Rows[i][1].ToString();
                            _despDetalle.p_Cantidad = Convert.ToDecimal(dt.Rows[i][2]);
                            _despDetalle.p_SolPiezasSueltas = Convert.ToInt32(dt.Rows[i][3]);
                            _despDetalle.p_ConfPiezasSueltas = Convert.ToInt32(dt.Rows[i][4]);
                            _despDetalle.p_CantConfirmada = Convert.ToDecimal(dt.Rows[i][5]);
                            _despDetalle.p_Unidad = dt.Rows[i][6].ToString();
                            _despDetalle.p_Status = dt.Rows[i][7].ToString();
                            _despDetalle.p_SucursalId = Convert.ToInt32(dt.Rows[i][8]);
                            a = _despDetalle.InsertarDespDetalle(trnSql);
                            if (a == 0)
                            {
                                break;
                            }
                        }
                        if (a > 0)
                        {
                            _metodo = "Actualizar Secuencia_";
                            a = ActualizarSecuencia(isucursal, "DESPACHO", sDespacho, trnSql);
                            if (a > 0)
                            {
                                trnSql.Commit();
                                //trnSql.Rollback();
                                //trnSql.Dispose();
                            }
                            else
                            {
                                trnSql.Rollback();
                            }
                        }
                        else
                        {
                            trnSql.Rollback();
                            trnSql.Dispose();
                        }
                    }
                }
                return a;
            }
        }
        //public DataTable ejecutarConsulta1(string sentencia)
        //{
        //    //List<Parametro> listaEmpleados = new List<Parametro>();
        //    DataTable data = new DataTable();
        //    using (SqlConnection con = new SqlConnection(cadenaConexion))
        //    {
        //        con.Open();
        //        using (SqlCommand comando = new SqlCommand(sentencia, con))
        //        {
        //            using (SqlDataAdapter reader = new SqlDataAdapter(comando))
        //            {
        //                reader.Fill(data);
        //            }
        //        }
        //        con.Close();
        //        return data;
        //    }
        //}
        protected int ejecutar(ref string er, string csql, System.Data.SqlClient.SqlTransaction obtransaccion)
        {
            try
            {
                System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(csql, obtransaccion.Connection);
                comando.Transaction = obtransaccion;
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return 0;
            }
        }
        //Control despacho
        public DataSet TraerControlDespacho(string _idDespacho)
        {
            return cadDespacho.TraerControlDespacho(_idDespacho);
        }
        public DataSet TraerTotalControlDespacho(string _idDespacho)
        {
            return cadDespacho.TraerTotalControlDespacho(_idDespacho);
        }
        //Reportes
        public DataSet TraerDespachoImpCabeceraA(string _idDespacho)
        {
            return cadDespacho.TraerDespachoImpCabeceraA(_idDespacho);
        }
        public DataSet TraerDespachoImpDetalleA(string _idDespacho)
        {
            return cadDespacho.TraerDespachoImpDetalleA(_idDespacho);
        }
        //Sucursal
        public DataSet TraerSucursalesDespacho()
        {
            return cadDespacho.TraerSucursalesDespacho();
        }
        //Cronograma
        public DataSet TraerPaquetesCronograma(int _idSucursal, string _ItemId, int _Piezas)
        {
            return cadDespacho.TraerPaquetesCronograma(_idSucursal, _ItemId, _Piezas);
        }
        public DataSet TraerSobrantesCronograma(int _idSucursal, string _ItemId, string _despachoId)
        {
            return cadDespacho.TraerSobrantesCronograma(_idSucursal, _ItemId, _despachoId);
        }
        //TraerDespProg
        public DataSet TraerDespProg(string _DespachoId, string _ItemId)
        {
            return cadDespacho.TraerDespProg(_DespachoId, _ItemId);
        }
        //TraerSobProg
        public DataSet TraerSobProg(string _DespachoId, string _ItemId)
        {
            return cadDespacho.TraerSobProg(_DespachoId, _ItemId);
        }
        //Traer Sucursales
        public DataSet TraerSucursalesVenta()
        {
            return cadDespacho.TraerSucursalesVenta();
        }
        //Correlativo
        public DataSet TraerCorrelativo(int _idSucursal, string Tipo)
        {
            return cadDespacho.TraerCorrelativo(_idSucursal, Tipo);
        }
        //TraerPaqueteOrdenProduccion
        public DataSet TraerPaqProduccion(string _OrdenId)
        {
            return cadDespacho.TraerPaqProduccion(_OrdenId);
        }
        public DataSet TraerInfoPaquete(string _paqueteId, int _idSucursal)
        {
            return cadDespacho.TraerInfoPaquete(_paqueteId, _idSucursal);
        }
        //TraerSucursalTransito
        public DataSet TraerCodigoTransito(int _IdSucursal)
        {
            return cadDespacho.TraerCodigoTransito(_IdSucursal);
        }
        //TraerSucursalLista
        public DataSet TraerSucursalLista()
        {
            return cadDespacho.TraerSucursalLista();
        }
        //Traspaso
        public int ModificarNumTraspasoDespacho(string _idDespacho, string _numTrasp)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE [LYBK].[dbo].[tblDespacho] SET NumTraspaso = '" + _numTrasp + "' WHERE DespachoId = '" + _idDespacho + "'";
            //string sUpdate = @"";
            return ejecutar(ref sError, sUpdate);
        }
        //TraerNumeroTraspaso
        public DataSet TraerTraspaso(string _idDespacho)
        {
            return cadDespacho.TraerTraspaso(_idDespacho);
        }
        //Reporte Despachos Autorizados
        public DataSet TraerDespachosAut(string _idDespacho)
        {
            return cadDespacho.TraerDespachosAut(_idDespacho);
        }
        //Reporte Orden de Carga
        public DataSet TraerOrdenCarga(string _idDespacho)
        {
            return cadDespacho.TraerOrdenCarga(_idDespacho);
        }
        //Reporte Orden de Entrega
        public DataSet TraerOrdenEntrega(string _idDespacho, int _idSucursal)
        {
            return cadDespacho.TraerOrdenEntrega(_idDespacho, _idSucursal);
        }
        //Reporte despacho cabecera
        public DataSet TraerCabeceraDespacho(string _idDespacho)
        {
            return cadDespacho.TraerCabeceraDespacho(_idDespacho);
        }
        //Traer Secuencia Palet
        public string TraerSecuenciaPalet(int Suscursal)
        {
            string sSelet = "select * from Sys_Secuencia where Operacion = 'PALET' and sucursal={0}";
            sSelet = string.Format(sSelet, Suscursal);
            DataTable dtsResult = consultar(sSelet).Tables[0];
            string sSecuencia = "";
            if (dtsResult.Rows.Count > 0)
            {
                string sContador = dtsResult.Rows[0]["Contador"].ToString();
                string sFijo = dtsResult.Rows[0]["Fijo"].ToString();
                int iSiguiente = 0;
                string year = "0";

                year = (sContador.Substring(0, 2));
                if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                    year = DateTime.Now.Year.ToString().Substring(2, 2);
                ///////////////////////////////////////////////////////////////////
                iSiguiente = Convert.ToInt32(sContador.Substring(5, 6));
                int iSig = iSiguiente + 1;
                sSecuencia = year + sFijo + (iSig.ToString("D6"));
            }
            return sSecuencia;
        }
        //Crear Palet
        public int CrearPalet(Palet _palet, int _idSucursal, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sCreate = @"INSERT INTO tblPalet ([PaletId],[ItemId],[ItemFId],[SucursalId],[Cantidad_Paqs],[Peso_Paqs], [Estado])
                                VALUES ('" + _palet.p_PaletId + "', '" + _palet.p_ItemId + "', " + _palet.p_ItemFerro + ", " + _palet.p_SucursalId + ", " + _palet.p_Cantidad_Paqs + ", " + _palet.p_Peso_Paqs +", '" + _palet.p_Estado + "')"; 
            return ejecutar(ref sError, sCreate);
        }
        public int ActualizarPaquete(string _Palet, string _idPaquete, int _idSucursal, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "UPDATE tblPaquetes set Contenedor = '" + _Palet + "' WHERE SucursalId = " + _idSucursal + " AND PaqueteId = '" + _idPaquete + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy); 
        }
        public int ActualizarCorrelativoPalet(string Contador, int _idSucursal, string Operacion, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "update Sys_Secuencia set Contador = '" + Contador + "' where  sucursal = " + _idSucursal + " and Operacion = '" + Operacion + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy);
        }
        //GuardarPalet
        public int InsertarPalet(out string sError, string _CorrelativoNuevo, int isucursal, Palet _palet, List<PaletLecturado> _paqList)
        {
            sError = string.Empty; 
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                int a = this.CrearPalet(_palet, isucursal, trnSql);
                if (a > 0)
                { 
                    if (_paqList.Count > 0)
                    { 
                        foreach(var item in _paqList)
                        {
                            a = ActualizarPaquete(_CorrelativoNuevo, item.p_PaqueteId, isucursal, trnSql);
                            if(a == 0)
                            {
                                break;
                            }
                        }
                        if (a > 0)
                        { 
                            a = ActualizarCorrelativoPalet(_CorrelativoNuevo, isucursal, "PALET", trnSql);
                            if (a > 0)
                            {
                                trnSql.Commit();
                            }
                            else
                            {
                                trnSql.Rollback();
                            } 
                        }
                        else
                        {
                            trnSql.Rollback();
                        }
                    }
                    else
                    {
                        a = 0;
                        trnSql.Rollback();
                    }
                }
                else
                {
                    trnSql.Rollback();
                }
                return a;
            }
        } 
         
        public int RBTraspDesp(string _idDespacho)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE tblDespacho SET NumTraspaso = '0000' WHERE DespachoId = '" + _idDespacho + "'";
            return ejecutar(ref sError, sUpdate);
        }
    }
}
