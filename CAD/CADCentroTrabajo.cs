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
    public class CADCentroTrabajo:DBDAC
    {
        public CADCentroTrabajo()
            : base("SQLSERVER", "dbo.tblCentroTrabajo")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@CentroId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @CentroId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public void GuardarCentroTrabajo(CentroTrabajo oCentroTrabajo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CentroId"].Value = oCentroTrabajo.CentroId;
            cmdInsert.Parameters["@Nombre"].Value = oCentroTrabajo.Nombre;
            cmdInsert.Parameters["@Sincronizacion"].Value = oCentroTrabajo.Sincronizacion;
            cmdInsert.Parameters["@SucursalId"].Value = oCentroTrabajo.SucursalId;
            cmdInsert.Parameters["@TipoCosteo"].Value = oCentroTrabajo.TipoCosteo;
            cmdInsert.Parameters["@Area"].Value = oCentroTrabajo.Area;
            cmdInsert.Parameters["@Localizacion"].Value = oCentroTrabajo.Localizacion;
            cmdInsert.Parameters["@CT_Operacion"].Value = oCentroTrabajo.CT_Operacion;
            cmdInsert.Parameters["@FechaInicioSync"].Value = oCentroTrabajo.FechaInicioSync;
            cmdInsert.Parameters["@SelectSQL"].Value = oCentroTrabajo.SelectSQL;
            cmdInsert.Parameters["@WhereSQL"].Value = oCentroTrabajo.WhereSQL;
            cmdInsert.Parameters["@LocalizacionFija"].Value = oCentroTrabajo.LocalizacionFija;
            cmdInsert.Parameters["@CeldaId"].Value = oCentroTrabajo.CeldaId;
            cmdInsert.Parameters["@Revision"].Value = oCentroTrabajo.Revision;
            cmdInsert.Parameters["@SelectFuente"].Value = oCentroTrabajo.SelectFuente;
            cmdInsert.Parameters["@WhereSinPlan"].Value = oCentroTrabajo.WhereSinPlan;
            cmdInsert.Parameters["@WhereConPlan"].Value = oCentroTrabajo.WhereConPlan;
            cmdInsert.Parameters["@Costeo"].Value = oCentroTrabajo.Costeo;
            cmdInsert.Parameters["@PrecioTon"].Value = oCentroTrabajo.PrecioTon;
            cmdInsert.Parameters["@PorcDispersion"].Value = oCentroTrabajo.PorcDispersion;
            EjecutarComando(cmdInsert);
        }
        public DataSet TraerCentrosxID(int id) 
        {
            string consulta = String.Format("select centroid, nombre,sucursalid  from tblCentroTrabajo where sucursalid={0}", id);
            return this.EjecutarConsulta(consulta);        
        }

        public DataSet TraerAlmacenes()
        {
            string consulta = String.Format("select SucursalId,Nombre from tblAlmacen");
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerTodoCentroTrabajo()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoCentroTrabajo(string where)
        {
            return this.Consultar(where);
        }
        public int ModificarCentroTrabajo(CentroTrabajo oCentroTrabajo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@CentroId"].Value = oCentroTrabajo.CentroId;
            cmdModificar.Parameters["@Nombre"].Value = oCentroTrabajo.Nombre;
            cmdModificar.Parameters["@Sincronizacion"].Value = oCentroTrabajo.Sincronizacion;
            cmdModificar.Parameters["@SucursalId"].Value = oCentroTrabajo.SucursalId;
            cmdModificar.Parameters["@TipoCosteo"].Value = oCentroTrabajo.TipoCosteo;
            cmdModificar.Parameters["@Area"].Value = oCentroTrabajo.Area;
            cmdModificar.Parameters["@Localizacion"].Value = oCentroTrabajo.Localizacion;
            cmdModificar.Parameters["@CT_Operacion"].Value = oCentroTrabajo.CT_Operacion;
            cmdModificar.Parameters["@FechaInicioSync"].Value = oCentroTrabajo.FechaInicioSync;
            cmdModificar.Parameters["@SelectSQL"].Value = oCentroTrabajo.SelectSQL;
            cmdModificar.Parameters["@WhereSQL"].Value = oCentroTrabajo.WhereSQL;
            cmdModificar.Parameters["@LocalizacionFija"].Value = oCentroTrabajo.LocalizacionFija;
            cmdModificar.Parameters["@CeldaId"].Value = oCentroTrabajo.CeldaId;
            cmdModificar.Parameters["@Revision"].Value = oCentroTrabajo.Revision;
            cmdModificar.Parameters["@SelectFuente"].Value = oCentroTrabajo.SelectFuente;
            cmdModificar.Parameters["@WhereSinPlan"].Value = oCentroTrabajo.WhereSinPlan;
            cmdModificar.Parameters["@WhereConPlan"].Value = oCentroTrabajo.WhereConPlan;
            cmdModificar.Parameters["@Costeo"].Value = oCentroTrabajo.Costeo;
            cmdModificar.Parameters["@PrecioTon"].Value = oCentroTrabajo.PrecioTon;
            cmdModificar.Parameters["@PorcDispersion"].Value = oCentroTrabajo.PorcDispersion;
            cmdModificar.Parameters["@Original_CentroId"].Value = oCentroTrabajo.CentroId;
            return EjecutarComando(cmdModificar);
        }

        public CentroTrabajo TraerCentroTrabajo(string vCentroId)
        {
            DataSet ds = this.Consultar("CentroId='" + vCentroId +"'");
            DataTable tCentroTrabajo = ds.Tables[0];
            if (tCentroTrabajo.Rows.Count == 0)
            {
                return null;
            }
            DataRow rCentroTrabajo = tCentroTrabajo.Rows[0];
            CentroTrabajo oCentroTrabajo = new CentroTrabajo();
            oCentroTrabajo.CentroId = Convert.ToString(rCentroTrabajo["CentroId"]);
            oCentroTrabajo.Nombre = Convert.ToString(rCentroTrabajo["Nombre"]);
            oCentroTrabajo.Sincronizacion = Convert.ToBoolean(rCentroTrabajo["Sincronizacion"]);
            oCentroTrabajo.SucursalId = Convert.ToInt32(rCentroTrabajo["SucursalId"]);
            oCentroTrabajo.TipoCosteo = Convert.ToInt32(rCentroTrabajo["TipoCosteo"]);
            oCentroTrabajo.Area = Convert.ToString(rCentroTrabajo["Area"]);
            oCentroTrabajo.Localizacion = Convert.ToBoolean(rCentroTrabajo["Localizacion"]);
            oCentroTrabajo.CT_Operacion = Convert.ToString(rCentroTrabajo["CT_Operacion"]);
            oCentroTrabajo.FechaInicioSync = Convert.ToDateTime(rCentroTrabajo["FechaInicioSync"]);
            oCentroTrabajo.SelectSQL = Convert.ToString(rCentroTrabajo["SelectSQL"]);
            oCentroTrabajo.WhereSQL = Convert.ToString(rCentroTrabajo["WhereSQL"]);
            oCentroTrabajo.LocalizacionFija = Convert.ToBoolean(rCentroTrabajo["LocalizacionFija"]);
            oCentroTrabajo.CeldaId = Convert.ToString(rCentroTrabajo["CeldaId"]);
            oCentroTrabajo.Revision = Convert.ToBoolean(rCentroTrabajo["Revision"]);
            oCentroTrabajo.SelectFuente = Convert.ToString(rCentroTrabajo["SelectFuente"]);
            oCentroTrabajo.WhereSinPlan = Convert.ToString(rCentroTrabajo["WhereSinPlan"]);
            oCentroTrabajo.WhereConPlan = Convert.ToString(rCentroTrabajo["WhereConPlan"]);
            oCentroTrabajo.Costeo = Convert.ToBoolean(rCentroTrabajo["Costeo"]);
            oCentroTrabajo.PrecioTon = Convert.ToDecimal(rCentroTrabajo["PrecioTon"]);
            oCentroTrabajo.PorcDispersion= Convert.ToInt32(rCentroTrabajo["PorcDispersion"]);
            return oCentroTrabajo;
        }

       
        public int EliminarCentroTrabajo(string vCentro)
        {
            return EjecutarComando("DELETE FROM dbo.tblCentroTrabajo WHERE docId='" + vCentro+"'");
        }

        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.tblCentroTrabajo set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarCentroTrabajo(string nombDocumento)
        {
            string cadena = "select Centroid,nombre,precioTon from tblCentroTrabajo where nombre like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
        }
    }
}
