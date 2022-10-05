using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
    public class CADRecepcionProducto : DBDAC
    {
        public CADRecepcionProducto()
            : base("SQLSERVER", "dbo.tblRecepcionProductos")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@RecepcionId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @RecepcionId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }

        public void GuardarRecepcionProducto(RecepcionProducto oRecepcionProducto)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@RecepcionId"].Value = oRecepcionProducto.RecepcionId;
            cmdInsert.Parameters["@ProductoId"].Value = NuevoNumero(oRecepcionProducto.Fecha, oRecepcionProducto.SucursalId);
            cmdInsert.Parameters["@Fabricante"].Value = oRecepcionProducto.Fabricante;
            cmdInsert.Parameters["@ItemId"].Value = oRecepcionProducto.ItemId;
            cmdInsert.Parameters["@Piezas"].Value = oRecepcionProducto.Piezas;
            cmdInsert.Parameters["@Peso"].Value = oRecepcionProducto.Peso;
            cmdInsert.Parameters["@Colada"].Value = oRecepcionProducto.Colada;
            cmdInsert.Parameters["@SucursalId"].Value = oRecepcionProducto.SucursalId;
            cmdInsert.Parameters["@AlmacenId"].Value = oRecepcionProducto.AlmacenId;
            cmdInsert.Parameters["@CeldaId"].Value = oRecepcionProducto.CeldaId;
            cmdInsert.Parameters["@Fecha"].Value = oRecepcionProducto.Fecha;
            cmdInsert.Parameters["@Correlativo"].Value = UltimoNumero(oRecepcionProducto.Fecha.Year, oRecepcionProducto.SucursalId) + 1;
            cmdInsert.Parameters["@Login"].Value = oRecepcionProducto.Login;
            cmdInsert.Parameters["@Status"].Value = oRecepcionProducto.Status;
            cmdInsert.Parameters["@CodPackList"].Value = oRecepcionProducto.CodPackList;
            cmdInsert.Parameters["@PesoNetoProveedor"].Value = oRecepcionProducto.PesoNetoProveedor;
            cmdInsert.Parameters["@PesoBrutoProveedor"].Value = oRecepcionProducto.PesoBrutoProveedor;
            cmdInsert.Parameters["@EsDeCliente"].Value = oRecepcionProducto.EsDeCliente;
            cmdInsert.Parameters["@Id_TipoObservacion"].Value = oRecepcionProducto.Id_TipoObservacion;
            EjecutarComando(cmdInsert);
        }

        public void ModificarRecepcionProducto(RecepcionProducto oRecepcionProducto)
        {
            string sql = "update tblRecepcionProductos set Peso=" + oRecepcionProducto.Peso +
            ",PesoNetoProveedor=" + oRecepcionProducto.PesoNetoProveedor + ",Piezas=" + oRecepcionProducto.Piezas +
            ",Colada='" + oRecepcionProducto.Colada + "',CodPackList='" + oRecepcionProducto.CodPackList + "',CeldaId='" + oRecepcionProducto.CeldaId +
            "',Fabricante='" + oRecepcionProducto.Fabricante + "' where productoid='" + oRecepcionProducto.ProductoId + "'";
            EjecutarComando(sql);
        }
        public void EliminarRecepcionProducto(string ProductoId,string RecepcionId)
        {
            string sql = "Delete from tblRecepcionProductos where ProductoId='" + ProductoId + "' and RecepcionId='"+RecepcionId+"'";
            //DbCommand cmdDelete = Adapter.DeleteCommand;
            //cmdDelete.Parameters["@Original_ProductoId"].Value = vRecepcionId;
            EjecutarComando(sql);
        }
        public DataSet ObtenerEtiqueta(string id)
        {
            string consulta = "Select r.ItemId,p.Descripcion,r.Peso,r.ProductoId as codigobarra,r.Colada,r.RecepcionId as ordenid from tblRecepcionProductos r inner join tblItem p on r.ItemId=p.ItemId" +
                              " where r.ProductoId='"+id+"'"; 
            return this.EjecutarConsulta(consulta);
        }

        public DataSet TraerTodosRecepcionProducto()
        {
            return this.Consultar("");
        }


        public RecepcionProducto TraerRecepcionProducto(string ProductoId)
        {
            DataSet ds = this.Consultar("ProductoId='" + ProductoId + "'");
            DataTable tRecepcionProducto = ds.Tables[0];
            if (tRecepcionProducto.Rows.Count == 0)
            {
                return null;
            }
            DataRow rRecepcionProducto = tRecepcionProducto.Rows[0];
            RecepcionProducto oRecepcionProducto = new RecepcionProducto();
            oRecepcionProducto.RecepcionId = Convert.ToString(rRecepcionProducto["RecepcionId"]);
            oRecepcionProducto.ProductoId = Convert.ToString(rRecepcionProducto["ProductoId"]);
            oRecepcionProducto.Fabricante = Convert.ToString(rRecepcionProducto["Fabricante"]);
            oRecepcionProducto.ItemId = Convert.ToString(rRecepcionProducto["ItemId"]);
            oRecepcionProducto.Piezas = Convert.ToInt32(rRecepcionProducto["Piezas"]);
            oRecepcionProducto.Peso = Convert.ToDecimal(rRecepcionProducto["Peso"]);
            oRecepcionProducto.Colada = Convert.ToString(rRecepcionProducto["Colada"]);
            oRecepcionProducto.SucursalId = Convert.ToInt32(rRecepcionProducto["SucursalId"]);
            oRecepcionProducto.AlmacenId = Convert.ToInt32(rRecepcionProducto["AlmacenId"]);
            oRecepcionProducto.CeldaId = Convert.ToString(rRecepcionProducto["CeldaId"]);
            oRecepcionProducto.Fecha = Convert.ToDateTime(rRecepcionProducto["Fecha"]);
            oRecepcionProducto.Correlativo = Convert.ToInt32(rRecepcionProducto["Correlativo"]);
            oRecepcionProducto.Login = Convert.ToString(rRecepcionProducto["Login"]);
            oRecepcionProducto.Status = Convert.ToString(rRecepcionProducto["Status"]);
            oRecepcionProducto.CodPackList = Convert.ToString(rRecepcionProducto["CodPackList"]);
            oRecepcionProducto.PesoNetoProveedor = Convert.ToDecimal(rRecepcionProducto["PesoNetoProveedor"]);
            oRecepcionProducto.PesoBrutoProveedor = Convert.ToDecimal(rRecepcionProducto["PesoBrutoProveedor"]);
            oRecepcionProducto.EsDeCliente = Convert.ToBoolean(rRecepcionProducto["EsDeCliente"]);
            oRecepcionProducto.Id_TipoObservacion = Convert.ToInt32(rRecepcionProducto["Id_TipoObservacion"]);
            return oRecepcionProducto;
        }
        public int UltimoNumero(int gestion, int Sucursal)
        {

            //string consulta = "Select isnull(max(Correlativo),0) as id from tblRecepcionProductos where year(fecha)=" + gestion + " and SucursalID=" + Sucursal;
            string consulta = "Select max(Correlativo) as id from tblRecepcionProductos where year(fecha)=" + gestion + " and SucursalID=" + Sucursal;
            int MaxValor=0;
            DataSet ds = this.EjecutarConsulta(consulta);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            DataRow rMovimiento = dt.Rows[0];

            if (rMovimiento["id"] == System.DBNull.Value)
            {
                MaxValor = 0;
            }
            else
                MaxValor = (int)rMovimiento["id"];
            return MaxValor;
        }
        public string NuevoNumero(DateTime Fecha, int sucursal)
        {
            int gestion; int mes;
            gestion = Fecha.Year;
            mes = Fecha.Month;

            int Correlativo = UltimoNumero(gestion, sucursal) + 1;

            string SNuevoNumero = serializa(mes, 2) + gestion.ToString().Substring(2, 2) + "R" + serializa(Correlativo, 6);
            return SNuevoNumero;
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
        public DataSet TraerTodoRecepcionProducto(string Recepcion)
        {
            string consulta = "Select RecepcionId,ProductoId,ItemId,Piezas,Peso,colada,CeldaId,Status from tblRecepcionProductos where RecepcionId='" + Recepcion + "'";
            return this.EjecutarConsulta(consulta);
        }


    }
}
