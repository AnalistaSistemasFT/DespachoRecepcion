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
    public class CADItem:DBDAC
    {
        public CADItem()
            : base("SQLSERVER", "dbo.tblItem")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@ItemId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @ItemId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }

        public void GuardarItem(Item oItem)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@ItemId"].Value = oItem.ItemId;
            cmdInsert.Parameters["@Descripcion"].Value = oItem.Descripcion;
            cmdInsert.Parameters["@CapKilos"].Value = oItem.CapKilos;
            cmdInsert.Parameters["@CapVertical"].Value = oItem.CapVertical;
            cmdInsert.Parameters["@CapHorizontal"].Value = oItem.CapHorizontal;
            cmdInsert.Parameters["@PesoPaq"].Value = oItem.PesoPaq;
            cmdInsert.Parameters["@Piezas"].Value = oItem.Piezas;
            cmdInsert.Parameters["@Ancho"].Value = oItem.Ancho;
            cmdInsert.Parameters["@GrupoId"].Value = oItem.GrupoId;
            cmdInsert.Parameters["@ItemFId"].Value = oItem.ItemFId;
            cmdInsert.Parameters["@Calidad"].Value = oItem.Calidad;
            cmdInsert.Parameters["@Espesor"].Value = oItem.Espesor;
            cmdInsert.Parameters["@Uso"].Value = oItem.Uso;
            cmdInsert.Parameters["@Presentacion"].Value = oItem.Presentacion;
            cmdInsert.Parameters["@TipoMaterial"].Value = oItem.TipoMaterial;
            cmdInsert.Parameters["@UnidadF"].Value = oItem.Unidad;
            cmdInsert.Parameters["@Piramide"].Value = oItem.Piramide;
            cmdInsert.Parameters["@UnidadesXCelda"].Value = oItem.UnidadesXCelda;
            cmdInsert.Parameters["@UnidadCalculo"].Value = oItem.UnidadCalculo;

            EjecutarComando(cmdInsert);
        }
        public void ModificarItem(Item oItem)
        {
            DbCommand cmdUpdate = Adapter.UpdateCommand;
            cmdUpdate.Parameters["@ItemId"].Value = oItem.ItemId;
            cmdUpdate.Parameters["@Descripcion"].Value = oItem.Descripcion;
            cmdUpdate.Parameters["@CapKilos"].Value = oItem.CapKilos;
            cmdUpdate.Parameters["@CapVertical"].Value = oItem.CapVertical;
            cmdUpdate.Parameters["@CapHorizontal"].Value = oItem.CapHorizontal;
            cmdUpdate.Parameters["@PesoPaq"].Value = oItem.PesoPaq;
            cmdUpdate.Parameters["@Piezas"].Value = oItem.Piezas;
            cmdUpdate.Parameters["@Ancho"].Value = oItem.Ancho;
            cmdUpdate.Parameters["@GrupoId"].Value = oItem.GrupoId;
            cmdUpdate.Parameters["@ItemFId"].Value = oItem.ItemFId;
            cmdUpdate.Parameters["@Calidad"].Value = oItem.Calidad;
            cmdUpdate.Parameters["@Espesor"].Value = oItem.Espesor;
            cmdUpdate.Parameters["@Uso"].Value = oItem.Uso;
            cmdUpdate.Parameters["@Presentacion"].Value = oItem.Presentacion;
            cmdUpdate.Parameters["@TipoMaterial"].Value = oItem.TipoMaterial;
            cmdUpdate.Parameters["@UnidadF"].Value = oItem.Unidad;
            cmdUpdate.Parameters["@Piramide"].Value = oItem.Piramide;
            cmdUpdate.Parameters["@UnidadCalculo"].Value = oItem.UnidadCalculo;

            EjecutarComando(cmdUpdate);
        }
        public DataSet ListaItemResumen(string _idSucursal)
        {
            string consulta = String.Format("SELECT a.ItemId as Codigo, a.Descripcion, SUM(b.Piezas) as Piezas " +
                "FROM tblItem a INNER JOIN tblPaquetes b ON a.ItemId = b.ItemId INNER JOIN tblSucItem c ON a.ItemId = c.ItemId " +
                "WHERE c.SucursalId = '" + _idSucursal + "' group by a.ItemId, a.Descripcion");
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarItemNombre(string _nombrePr, string _idSucursal)
        {
            string consulta = "SELECT a.ItemId as Codigo, a.Descripcion, SUM(b.Piezas) as Piezas " +
                "FROM tblItem a INNER JOIN tblPaquetes b ON a.ItemId = b.ItemId INNER JOIN tblSucItem c ON a.ItemId = c.ItemId " +
                "WHERE b.Status = 'ACTIVO' AND c.SucursalId = '" + _idSucursal + "' " +
                "AND a.Descripcion like '%" + _nombrePr + "%' GROUP BY a.ItemId, a.Descripcion";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarItemCodigo(string _codigoPr, string _idSucursal)
        {
            string consulta = "SELECT a.ItemId as Codigo, a.Descripcion, SUM(b.Piezas) as Piezas " +
                "FROM tblItem a INNER JOIN tblPaquetes b ON a.ItemId = b.ItemId INNER JOIN tblSucItem c ON a.ItemId = c.ItemId " +
                "WHERE b.Status = 'ACTIVO' AND c.SucursalId = '" + _idSucursal + "' " +
                "AND a.ItemId like '%" + _codigoPr + "%' GROUP BY a.ItemId, a.Descripcion";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarItemDespacho(string _id_producto)
        {
            string consulta = "SELECT ItemId = '" + _id_producto + "'";
            return this.EjecutarConsulta(consulta);
        }

        public DataSet TraerTodoItem()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoItem(string where)
        {
            return this.Consultar(where);
        }

        public DataSet DetalleItemSucursal(string sItem)
        {
            DataSet ds = this.EjecutarConsulta(" select * from tblSucItem where ItemId = '" + sItem + "' and Stock > 0");
            return ds;
        }
        public DataSet BuscarItemFerro(string sItem)
        {
            DataSet ds = this.EjecutarConsulta("select * from tblItem where ItemFId = '"+sItem+"'");
            return ds;
        }

        public DataSet TraerGrupoItem()
        {
            DataSet ds = this.EjecutarConsulta("select * from tblGrupoItem  order by descripcion asc");
            return ds;
        }
        public DataSet TraerNaturaleza()
        {
            DataSet ds = this.EjecutarConsulta("select* from tblCatNaturaleza order by naturaleza asc");
            return ds;
        }
        public DataSet TraerGrupoProducto()
        {
            DataSet ds = this.EjecutarConsulta("select* from Cat_GrupoProducto order by descripcion asc");
            return ds;
        }
        public DataSet TraerSeguimiento()
        {
            DataSet ds = this.EjecutarConsulta("select* from Sys_DimSeguimiento order by id_dimseguimiento asc");
            return ds;
        }
        public DataSet TraerTipoGalvanizado()
        {
            DataSet ds = this.EjecutarConsulta("select* from Sys_TipoGalvanizado");
            return ds;
        }

        public DataSet TraerCatUnidad()
        {
            DataSet ds = this.EjecutarConsulta("select* from tblCatUnidad order by descripcion asc");
            return ds;
        }

        public DataSet TraerCat_Calidad()
        {
            DataSet ds = this.EjecutarConsulta("select* from Cat_Calidad order by descripcion asc");
            return ds;
        }

        public DataSet TraerSucursal()
        {
            DataSet ds = this.EjecutarConsulta("select SucursalID,Nombre  from empleados.dbo.tblSucursal where adscrita='true' order by nombre");
            return ds;
        }


        public DataSet BuscarItems(string _codigoPr, int _idSucursal)
        {
            string consulta = "SELECT a.ItemId as Codigo, c.ItemFId as ItemFerro, a.Piezas, SUM(a.Piezas) as Stock,a.Peso, SUM(a.Peso) as PesoTotal  " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId " +
                "INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND b.SucursalId = " + _idSucursal + " AND a.ItemId = '" + _codigoPr + "' group by a.ItemId, c.ItemFId, a.Piezas, a.Peso";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerProductosConItemFid(int _idSucursal)
        {
            string consulta = String.Format("SELECT c.ItemFId, a.ItemId, c.Descripcion, a.Piezas, SUM(a.Piezas) as Stock, c.PesoPaq as Peso FROM tblPaquetes a " +
                "INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND b.SucursalId = " + _idSucursal + " group by a.ItemId, c.ItemFId, a.Piezas, c.PesoPaq, c.Descripcion");
            return this.EjecutarConsulta(consulta);
        }




        //public DataSet TraerTodoItems(int sucursal)
        //{
        //    string consulta = "Select * from tblItem where TIPOORDEN='PRODUCCION' AND status='" + estado + "' and SucursalID=" + sucursal;
        //    return this.EjecutarConsulta(consulta);
        //}


        public Item TraerItem(string idItem)
        {
            DataSet ds = this.Consultar("ItemId='" + idItem +"'");
            DataTable tItems = ds.Tables[0];
            if (tItems.Rows.Count == 0)
            {
                return null;
            }
            DataRow rItem = tItems.Rows[0];
            Item oItem = new Item();
            oItem.ItemId  = idItem;
            oItem.Descripcion = rItem["Descripcion"].ToString();
            oItem.Unidad = rItem["Unidadf"].ToString();
            return oItem;
        }

        public int VerificarItem(string Item)
        {
            string sError = string.Empty;
            string sInsert = @"select * from tblItem  where ItemFid = '{0}'";
            sInsert = string.Format(sInsert, Item);
            DataSet dts = EjecutarConsulta(sInsert);
            if (dts.Tables[0].Rows.Count > 0)
                return 1;
            else
                return 0;

        }
    }
}
