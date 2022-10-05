using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADCatalogoProducto : DBDAC
    {
        public CADCatalogoProducto() : base("SQLSERVER", "tblCatalogoProductos")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@p_Id_producto";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @p_Id_producto=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarProducto(CatalogoProducto _catalogoProducto)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@p_Id_producto"].Value = _catalogoProducto.Id_producto;
            cmdInsert.Parameters["@p_Nombre"].Value = _catalogoProducto.Nombre;
            cmdInsert.Parameters["@p_Descripcion"].Value = _catalogoProducto.Descripcion;
            return EjecutarComando(cmdInsert);
        }
        public int ModificarProducto(CatalogoProducto _catalogoProducto)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@p_Id_Producto"].Value = _catalogoProducto.Id_producto;
            cmdModificar.Parameters["@p_Nombre"].Value = _catalogoProducto.Nombre;
            cmdModificar.Parameters["@p_Descripcion"].Value = _catalogoProducto.Descripcion;
            return EjecutarComando(cmdModificar);
        }
        public DataSet TraerTodoProducto()
        {
            return this.Consultar("");
        }
    }
}
