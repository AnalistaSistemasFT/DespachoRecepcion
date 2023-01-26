using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CDevolucion : oledb
    {
        public CDevolucion()
        {
            this.sConnName = "SQLSERVER";
        }
        public DataSet TraerDevoluciones()
        {
            string sInsert = @"select * from tblDevolucion";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet TraerDevolucion(int _IdDevolucion)
        {
            string sInsert = @"select * from tblDevolucion where Id_devolucion  = " + _IdDevolucion;
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet TraerDetalleDevolucion(int _IdDevolucion)
        {
            string sInsert = @"select * from tblDevolucionDetalle where Id_devolucion  = " + _IdDevolucion;
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public int AgregarDevolucion(Devolucion _devolucion, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblDevolucion
                                    ([Id_Devolucion],[Cod_cliente],[Nom_cliente],[Sucursal],[Monto],[Vendedor],[Fecha_entrega],[Fecha_recepcion],[Chofer],[Placa],[OrdenVenta],[NuevaOrdenVenta],[Motivo])
                                VALUES
                                      ({0},{1},'{2}',{3},{4},{5},'{6}','{7}','{8}','{9}',{10},{11},'{12}')";
            sInsert = string.Format(sInsert, _devolucion.p_Id_Devolucion, _devolucion.p_Cod_cliente, _devolucion.p_Nom_cliente, _devolucion.p_Sucursal, _devolucion.p_Monto, _devolucion.p_Vendedor, _devolucion.p_Fecha_entrega.ToString("dd/MM/yyyy"), _devolucion.p_Fecha_recepcion.ToString("dd/MM/yyyy"), _devolucion.p_Chofer, _devolucion.p_Placa, _devolucion.p_OrdenVenta, _devolucion.p_NuevaOrdenVenta, _devolucion.p_Motivo );
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int AgregarDetalleDevolucion( DevolucionDetalle _devDetalle, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblDespacho
                                    ([Id_devolucion],[Codigo],[CodigoFerro],[Descripcion],[Cantidad],[Unidad],[Reincorporado],[Observaciones])
                                VALUES
                                      ({0},'{1}',{2},'{3}',{4},'{5}',{6},'{7}')";
            sInsert = string.Format(sInsert, _devDetalle.p_Id_devolucion, _devDetalle.p_Codigo, _devDetalle.p_CodigoFerro, _devDetalle.p_Descripcion, _devDetalle.p_Cantidad, _devDetalle.p_Unidad, _devDetalle.p_Reincorporado, _devDetalle.p_Observaciones);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int InsertarDevolucion(Devolucion _devolucion, DataTable dt)
        {
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                int a = this.AgregarDevolucion(_devolucion, trnSql);
                if (a > 0)
                {
                    DevolucionDetalle _devDetalle = new DevolucionDetalle();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _devDetalle.p_Id_devolucion = 0;
                        _devDetalle.p_Codigo = dt.Rows[i][0].ToString();
                        _devDetalle.p_CodigoFerro = Convert.ToInt32(dt.Rows[i][1]);
                        _devDetalle.p_Descripcion = dt.Rows[i][2].ToString();
                        _devDetalle.p_Cantidad = Convert.ToInt32(dt.Rows[i][3]);
                        _devDetalle.p_Unidad = dt.Rows[i][4].ToString();
                        _devDetalle.p_Reincorporado = Convert.ToInt32(dt.Rows[i][5]);
                        _devDetalle.p_Observaciones = dt.Rows[i][6].ToString();
                        a = this.AgregarDetalleDevolucion(_devDetalle, trnSql);
                        if (a == 0)
                        {
                            break;
                        }
                    }
                    if (a > 0)
                    {
                        //trnSql.Commit();
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
                return a;
            }
        } 
    }
}
