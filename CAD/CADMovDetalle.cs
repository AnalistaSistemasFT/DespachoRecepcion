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
    public class CADMovDetalle : DBDAC
    {
        public CADMovDetalle()
            : base("SQLSERVER", "dbo.tblMovDetalle")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@MovimientoId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @MovimientoId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }

        public void GuardarMovDetalle(MovDetalle oMovDetalle, String Tipo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@MovimientoId"].Value = oMovDetalle.MovimientoId;
            cmdInsert.Parameters["@ItemId"].Value = oMovDetalle.ItemId;
            cmdInsert.Parameters["@CantidadLiberada"].Value = oMovDetalle.CantidadLiberada;
            cmdInsert.Parameters["@CantEnPaq"].Value = oMovDetalle.CantEnPaq;
            cmdInsert.Parameters["@Cantidad"].Value = oMovDetalle.Cantidad;
            cmdInsert.Parameters["@Costo"].Value = oMovDetalle.Costo;
            cmdInsert.Parameters["@SucursalId"].Value = oMovDetalle.SucursalId;
            cmdInsert.Parameters["@ItemF"].Value = oMovDetalle.ItemF;
            cmdInsert.Parameters["@Unidad"].Value = oMovDetalle.Unidad;
            cmdInsert.Parameters["@Peso"].Value = oMovDetalle.Peso;
            cmdInsert.Parameters["@Calidad"].Value = oMovDetalle.Calidad;
            cmdInsert.Parameters["@Espesor"].Value = oMovDetalle.Espesor;
            cmdInsert.Parameters["@Piezas"].Value = oMovDetalle.Piezas;

            EjecutarComando(cmdInsert);

        }

        public int ModificarStock(int Sucursal, String ItemId, decimal Cantidad, decimal Peso, int Piezas, string Tipo)
        {
            string consulta;
            string mov = Tipo.Substring(0, 6);

            if (mov == "MOV001")
            {

                consulta = "update tblsucitem set stock=stock+" + Cantidad + ",Peso=Peso+" + Peso + ",Piezas=Piezas+" + Piezas + ","
                               + "TotalEntradas=TotalEntradas+" + Cantidad + " where sucursalid=" + Sucursal + " and itemid='" + ItemId + "'";
            }
            else
            {
                consulta = "update tblsucitem set stock=stock-" + Cantidad + ",Peso=Peso-" + Peso + ",Piezas=Piezas-" + Piezas + ","
                               + "TotalSalidas=TotalSalidas+" + Cantidad + " where sucursalid=" + Sucursal + " and itemid='" + ItemId + "'";
            }

            return this.EjecutarComando(consulta);
        }

        public int ModificarMovDetalle(MovDetalle oMovDetalle)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@MovimientoId"].Value = oMovDetalle.MovimientoId;
            cmdModificar.Parameters["@ItemId"].Value = oMovDetalle.ItemId;
            cmdModificar.Parameters["@CantidadLiberada"].Value = oMovDetalle.CantidadLiberada;
            cmdModificar.Parameters["@CantEnPaq"].Value = oMovDetalle.CantEnPaq;
            cmdModificar.Parameters["@Cantidad"].Value = oMovDetalle.Cantidad;
            cmdModificar.Parameters["@Costo"].Value = oMovDetalle.Costo;
            cmdModificar.Parameters["@SucursalId"].Value = oMovDetalle.SucursalId;
            cmdModificar.Parameters["@ItemF"].Value = oMovDetalle.ItemF;
            cmdModificar.Parameters["@Unidad"].Value = oMovDetalle.Unidad;
            cmdModificar.Parameters["@Peso"].Value = oMovDetalle.Peso;
            cmdModificar.Parameters["@Calidad"].Value = oMovDetalle.Calidad;
            cmdModificar.Parameters["@Espesor"].Value = oMovDetalle.Espesor;
            cmdModificar.Parameters["@Piezas"].Value = oMovDetalle.Piezas;
            return EjecutarComando(cmdModificar);
        }
        public DataSet TraerTodoMovDetalle()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoMovDetalle(string where)
        {
            return this.Consultar(where);
        }
        public DataSet TraerMovimientoDetalle(string Movimiento)
        {
            string Consulta = @"select d.MovimientoId,d.ItemId,i.Descripcion,d.Unidad,d.Cantidad,d.Peso,d.Piezas from tblMovDetalle d inner join 
                                    tblItem i on d.ItemId = i.ItemId
                                     where MovimientoId = '{0}'";
            Consulta = string.Format(Consulta, Movimiento);
            return EjecutarConsulta(Consulta);
        }
    }
}

