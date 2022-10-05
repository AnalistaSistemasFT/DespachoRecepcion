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
    public class CADRecepcionProductosDel:DBDAC
    {
        public CADRecepcionProductosDel()
            : base("SQLSERVER", "dbo.tblRecepcionProductosDel")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@RecepcionId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @RecepcionId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }

        public void GuardarRecepcionProductosDel(RecepcionProductosDel oRecepcionProductosDel)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@RecepcionId"].Value = oRecepcionProductosDel.RecepcionId;
            cmdInsert.Parameters["@ProductoId"].Value = oRecepcionProductosDel.ProductoId;
            cmdInsert.Parameters["@Fabricante"].Value = oRecepcionProductosDel.Fabricante;
            cmdInsert.Parameters["@ItemId"].Value = oRecepcionProductosDel.ItemId;
            cmdInsert.Parameters["@Piezas"].Value = oRecepcionProductosDel.Piezas;
            cmdInsert.Parameters["@Peso"].Value = oRecepcionProductosDel.Peso;
            cmdInsert.Parameters["@Colada"].Value = oRecepcionProductosDel.Colada;
            cmdInsert.Parameters["@SucursalId"].Value = oRecepcionProductosDel.SucursalId;
            cmdInsert.Parameters["@AlmacenId"].Value = oRecepcionProductosDel.AlmacenId;
            cmdInsert.Parameters["@CeldaId"].Value = oRecepcionProductosDel.CeldaId;
            cmdInsert.Parameters["@Fecha"].Value = oRecepcionProductosDel.Fecha;
            cmdInsert.Parameters["@FechaEliminacion"].Value = oRecepcionProductosDel.FechaEliminacion;
            cmdInsert.Parameters["@Correlativo"].Value = oRecepcionProductosDel.Correlativo;
            cmdInsert.Parameters["@Login"].Value = oRecepcionProductosDel.Login;
            cmdInsert.Parameters["@Status"].Value = oRecepcionProductosDel.Status;
            cmdInsert.Parameters["@CodPackList"].Value = oRecepcionProductosDel.CodPackList;
            cmdInsert.Parameters["@PesoNetoProveedor"].Value = oRecepcionProductosDel.PesoNetoProveedor;
            cmdInsert.Parameters["@PesoBrutoProveedor"].Value = oRecepcionProductosDel.PesoBrutoProveedor;
            cmdInsert.Parameters["@EsDeCliente"].Value = oRecepcionProductosDel.EsDeCliente;
            cmdInsert.Parameters["@Id_TipoObservacion"].Value = oRecepcionProductosDel.Id_TipoObservacion;
            EjecutarComando(cmdInsert);
        }
        public void ModificarRecepcionProductoDel(RecepcionProductosDel oRecepcionProducto)
        {
            string sql = "update tblRecepcionProductosDel set Peso=" + oRecepcionProducto.Peso +
            ",PesoNetoProveedor=" + oRecepcionProducto.PesoNetoProveedor + ",Piezas=" + oRecepcionProducto.Piezas +
            ",Colada='" + oRecepcionProducto.Colada + "',CodPackList='" + oRecepcionProducto.CodPackList + "',CeldaId='" + oRecepcionProducto.CeldaId +
            "',Fabricante='" + oRecepcionProducto.Fabricante + "' where productoid='" + oRecepcionProducto.ProductoId + "'";
            EjecutarComando(sql);
        }
        public void EliminarRecepcionProductoDel(string ProductoId, string RecepcionId)
        {
            string sql = "Delete from tblRecepcionProductosDel where ProductoId='" + ProductoId + "' and RecepcionId='" + RecepcionId + "'";
            //DbCommand cmdDelete = Adapter.DeleteCommand;
            //cmdDelete.Parameters["@Original_ProductoId"].Value = vRecepcionId;
            EjecutarComando(sql);
        }

        public RecepcionProductosDel TraerRecepcionProducto(string ProductoId)
        {
            DataSet ds = this.Consultar("ProductoId='" + ProductoId + "'");
            DataTable tRecepcionProducto = ds.Tables[0];
            if (tRecepcionProducto.Rows.Count == 0)
            {
                return null;
            }
            DataRow rRecepcionProducto = tRecepcionProducto.Rows[0];
            RecepcionProductosDel  oRecepcionProducto = new RecepcionProductosDel();
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

    }
}
 