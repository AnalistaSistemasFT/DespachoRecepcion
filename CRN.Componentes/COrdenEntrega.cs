using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class COrdenEntrega : oledb
    { 
        public COrdenEntrega()
        {
            this.sConnName = "SQLSERVER";
        }
        CADOrdenEntrega cadOrdenEnt = new CADOrdenEntrega();
        public DataSet TraerOrdenesEntregas()
        {
            return cadOrdenEnt.TraerOrdenesEntregas();
        }
        public DataSet TraerTodasOrdenEntrega(string Estado)
        {
            return cadOrdenEnt.TraerTodasOrdenEntrega(Estado);
        }
        public DataSet TraerTodasOrdenEntregaList(string Estado)
        {
            return cadOrdenEnt.TraerTodasOrdenEntregaList(Estado);
        }
        public DataSet TraerTodasOrdenDetalleDespacho(string IdDespacho)
        {
            return cadOrdenEnt.TraerTodasOrdenDetalleDespacho(IdDespacho);
        }
        //InsertarOrden
        public int InsertOrden(OrdenEntrega _ordenEntrega, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblOrdenEntrega
                                    ([DespachoId],[Fecha_salida],[Fecha_llegada],[Chofer],[Placa],[Origen_Id],[Destino_Id],[Login],[Cantidad_total],[Peso_total],[Estado],[Tipo_entrega],[Obs]) 
                                OUTPUT INSERTED.Id_orden_entrega
                                VALUES
                                      ('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}',{8},{9},'{10}','{11}','{12}')";
            sInsert = string.Format(sInsert, _ordenEntrega.p_DespachoId, _ordenEntrega.p_Fecha_salida.ToString("dd/MM/yyyy"), _ordenEntrega.p_Fecha_llegada.ToString("dd/MM/yyyy"), _ordenEntrega.p_Chofer, _ordenEntrega.p_Placa, _ordenEntrega.p_Origen_Id, _ordenEntrega.p_Destino_Id, _ordenEntrega.p_Login, _ordenEntrega.p_Cantidad_total, _ordenEntrega.p_Peso_total, _ordenEntrega.p_Estado, _ordenEntrega.p_Tipo_entrega, _ordenEntrega.p_Obs);
            
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        //TraerIdInsertado
        public DataSet TraerIdInsertado(string _despachoId)
        {
            return cadOrdenEnt.TraerIdInsertado(_despachoId);
        }
        //Pasar orden a parcial
        public int ModificarDespachoAParcial(string idDespacho, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE tblDespacho SET Status = 'Parcial' WHERE DespachoId = '" + idDespacho + "'";
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        //Actualizar Celda
        public int ActualizarCelda(string _celdaId, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"update tblCeldas set unidades=unidades-1 where celdaid='{0}'";
            sUpdate = string.Format(sUpdate, _celdaId);
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        //Paquetes a estado Transito
        public int PaquetesATransito(string _paqueteId, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = string.Empty;
            sUpdate = @"update tblPaquetes set Status = 'TRANSITO' where PaqueteId = '{0}'";
            sUpdate = string.Format(sUpdate, _paqueteId);
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        //Insertar
        public int InsertarOrdenEntrega(out string sError, OrdenEntrega _ordenEnt, DataTable dt, int isucursal, string IdDespacho)
        {
            int _idReciente = 0;
            DataSet dataId = TraerIdInsertado(_ordenEnt.p_DespachoId);
            foreach (DataRow itemId in dataId.Tables[0].Rows)
            {
                _idReciente = Convert.ToInt32(itemId[0]);
            }
            sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                int a = this.InsertOrden(_ordenEnt, trnSql);
                if (a > 0)
                {
                    //
                    _idReciente = _idReciente + 1;
                    OrdenEntregaDetalle _ordenDetalle = new OrdenEntregaDetalle();
                    if (dt.Rows.Count > 0)
                    {
                        if (a > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                _ordenDetalle.p_DespachoId = dt.Rows[i][0].ToString();
                                _ordenDetalle.p_PaqueteId = dt.Rows[i][1].ToString();
                                _ordenDetalle.p_ItemId = dt.Rows[i][2].ToString();
                                _ordenDetalle.p_ItemFId = Convert.ToInt32(dt.Rows[i][3]);
                                _ordenDetalle.p_Cantidad = Convert.ToInt32(dt.Rows[i][4]);
                                _ordenDetalle.p_Peso = Convert.ToDecimal(dt.Rows[i][5]);
                                _ordenDetalle.p_Estado = dt.Rows[i][6].ToString();
                                _ordenDetalle.p_Obs = dt.Rows[i][7].ToString();
                                _ordenDetalle.p_Fecha = Convert.ToDateTime(dt.Rows[i][8]);
                                _ordenDetalle.p_Id_orden_entrega = _idReciente;
                                a = _ordenDetalle.InsertarOrdenDetalle(trnSql);
                                if (a == 0)
                                {
                                    break;
                                }
                                else if(a == 1)
                                {
                                    string _celda = dt.Rows[i][9].ToString();
                                    a = ActualizarCelda(_celda, trnSql);
                                    if(a == 0)
                                    {
                                        break;
                                    }
                                    else if(a == 1)
                                    {
                                        string _paquete = dt.Rows[i][1].ToString();
                                        a = PaquetesATransito(_paquete, trnSql);
                                        if(a == 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            if (a > 0)
                            {
                                a = ModificarDespachoAParcial(IdDespacho, trnSql);
                                if(a>0)
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
                                trnSql.Dispose();
                            }
                        }
                        else
                        {
                            trnSql.Rollback();
                        }
                    }
                    else
                    {
                        trnSql.Rollback();
                        Console.WriteLine("################### = dt.Rows.Count = 0");
                    }
                }
                return a;
            }
        }
    }
}