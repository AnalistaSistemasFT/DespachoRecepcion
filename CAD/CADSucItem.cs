using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
    public class CADSucItem:DBDAC
    {
        public CADSucItem()
            : base("SQLSERVER", "dbo.tblSucItem")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@ItemId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @ItemId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }

        public void GuardarSucItem(SucItem oSucItem)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@SucursalId"].Value = oSucItem.SucursalId;
            cmdInsert.Parameters["@ItemId"].Value = oSucItem.ItemId;
            cmdInsert.Parameters["@Stock"].Value = oSucItem.Stock;
            cmdInsert.Parameters["@StckLiberadas"].Value = oSucItem.StckLiberadas;
            cmdInsert.Parameters["@StckEnPaquetes"].Value = oSucItem.stckPaquetes;
            cmdInsert.Parameters["@CapVertical"].Value = oSucItem.CapVertical;
            cmdInsert.Parameters["@CapHorizontal"].Value = oSucItem.CapHorizontal;
            cmdInsert.Parameters["@UnidadesXCelda"].Value = oSucItem.UnidadesXCelda;
            cmdInsert.Parameters["@Peso"].Value = oSucItem.peso;
            cmdInsert.Parameters["@Piezas"].Value = oSucItem.piezas;
            cmdInsert.Parameters["@TotalEntradas"].Value = oSucItem.TotalEntradas;
            cmdInsert.Parameters["@TotalSalidas"].Value = oSucItem.TotalSalidas;
            
            EjecutarComando(cmdInsert);
        }
        public void ModificarSucItem(SucItem oSucItem)
        {
            DbCommand cmdUpdate = Adapter.UpdateCommand;
            cmdUpdate.Parameters["@SucursalId"].Value = oSucItem.SucursalId;
            cmdUpdate.Parameters["@ItemId"].Value = oSucItem.ItemId;
            cmdUpdate.Parameters["@Stock"].Value = oSucItem.Stock;
            cmdUpdate.Parameters["@StckLiberadas"].Value = oSucItem.StckLiberadas;
            cmdUpdate.Parameters["@StckEnPaquetes"].Value = oSucItem.stckPaquetes;
            cmdUpdate.Parameters["@CapVertical"].Value = oSucItem.CapVertical;
            cmdUpdate.Parameters["@CapHorizontal"].Value = oSucItem.CapHorizontal;
            cmdUpdate.Parameters["@UnidadesXCelda"].Value = oSucItem.UnidadesXCelda;
            cmdUpdate.Parameters["@Peso"].Value = oSucItem.peso;
            cmdUpdate.Parameters["@Piezas"].Value = oSucItem.piezas;
            cmdUpdate.Parameters["@TotalEntradas"].Value = oSucItem.TotalEntradas;
            cmdUpdate.Parameters["@TotalSalidas"].Value = oSucItem.TotalSalidas;

            EjecutarComando(cmdUpdate);
        }


        public DataSet TraerTodoSucItem()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoSucItem(string where)
        {
            return this.Consultar(where);
        }
 
        //public Cliente TraerCliente(int idCliente)
        //{
        //    DataSet ds = this.Consultar("IdCliente=" + idCliente);
        //    DataTable tClientes = ds.Tables[0];
        //    if (tClientes.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    DataRow rCliente = tClientes.Rows[0];
        //    Cliente oCliente = new Cliente();
        //    oCliente.IdCliente = idCliente;
        //    oCliente.Nombre = rCliente["Nombre"].ToString();
        //    oCliente.ApellidoPaterno = rCliente["ApellidoPaterno"].ToString();
        //    oCliente.ApellidoMaterno = rCliente["ApellidoMaterno"].ToString();
        //    oCliente.Documento = rCliente["Documento"].ToString();
        //    oCliente.Sexo = rCliente["Sexo"].ToString();
        //    oCliente.CantidadHijos = Convert.ToInt32(rCliente["CantidadHijos"]);
        //    return oCliente;
        //}
    }
}
