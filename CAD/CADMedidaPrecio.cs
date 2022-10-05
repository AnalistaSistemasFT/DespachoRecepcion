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
     public class CADMedidaPrecio:DBDAC
    {
         public CADMedidaPrecio()
            : base("SQLSERVER", "dbo.tblMedidaPrecio")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@Medida";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @Medida=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
         public void GuardarMedidaPrecio(MedidaPrecio oMedidaPrecio)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CentroId"].Value = oMedidaPrecio.CentroId;
            cmdInsert.Parameters["@Medida"].Value = oMedidaPrecio.Medida;
            cmdInsert.Parameters["@PrecioTon"].Value = oMedidaPrecio.PrecioTon;
            EjecutarComando(cmdInsert);
        }

         public DataSet TraerTodoMedidaPrecio()
        {
            return this.Consultar("");
        }
         public DataSet TraerTodoMedidaPrecio(string where)
        {
            return this.Consultar(where);
        }
        public int ModificarMedidaPrecio(MedidaPrecio oMedidaPrecio)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@CentroId"].Value = oMedidaPrecio.CentroId;
            cmdModificar.Parameters["@Medida"].Value = oMedidaPrecio.Medida;
            cmdModificar.Parameters["@PrecioTon"].Value = oMedidaPrecio.PrecioTon;
            return EjecutarComando(cmdModificar);
        }
        public MedidaPrecio TraerMedidaPrecio(string Centro,decimal medida)
        {
        DataSet ds = this.Consultar("CentroId='" + Centro +"' and Medida="+medida);
            DataTable tMP = ds.Tables[0];
            if (tMP.Rows.Count == 0)
            {
                return null;
            }
            DataRow rMP = tMP.Rows[0];
            MedidaPrecio  oMP = new MedidaPrecio();
            oMP.CentroId = Centro;
            oMP.Medida = medida;
            oMP.PrecioTon= Convert.ToDecimal(rMP["PrecioTon"]);
            return oMP;
        }
        public int EliminarMedidaPrecio(string Centro, decimal medida)
        {
            return EjecutarComando("DELETE FROM dbo.tblMedidaPrecio WHERE CentroId='" + Centro + "' and Medida=" + medida);
        }
    }
}
