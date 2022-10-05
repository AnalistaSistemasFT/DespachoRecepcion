using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADMateriaPrima:DBDAC
    {
        public CADMateriaPrima()
            :base("SQLSERVER","dbo.tblOrdenProduccionDetalle")
		{
            /*DbParameter par = this.CrearParametro();
            par.ParameterName = "@PaqueteId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @PaqueteId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);*/
		}
        public void GuardarMateriaPrima(ProduccionDetalle opp)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@OrdenId"].Value = opp.ordenid;
            cmdInsert.Parameters["@ItemId"].Value = opp.itemid;
            cmdInsert.Parameters["@Metroz"].Value = opp.metros;
            cmdInsert.Parameters["@FechaFinal"].Value = opp.fechafinal;
            cmdInsert.Parameters["@Peso"].Value =Convert.ToDecimal(opp.peso);
            cmdInsert.Parameters["@Pieza"].Value = Convert.ToDecimal(opp.piezas);
            cmdInsert.Parameters["@Tipo"].Value = opp.tipo;
            cmdInsert.Parameters["@Turno"].Value = opp.turno;
            cmdInsert.Parameters["@UnidadMedida"].Value = opp.unidadmedida;
            cmdInsert.Parameters["@DescItem"].Value = opp.descitem;
            cmdInsert.Parameters["@Status"].Value = opp.estado;
            cmdInsert.Parameters["@Operador"].Value = opp.operador;
            cmdInsert.Parameters["@PaqueteId"].Value = opp.paqueteid;
            cmdInsert.Parameters["@FechaInicial"].Value = opp.fechainicial;
            EjecutarComando(cmdInsert);
        }

        public DataSet retornardata(string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }

    }
}
