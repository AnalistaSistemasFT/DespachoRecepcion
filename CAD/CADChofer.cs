using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADChofer : DBDAC
    {
        public CADChofer() : base("SQLSERVER", "dbo.tblCatChofer")
        {
            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@CI";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @ci=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarChofer(CatChofer _catChofer)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CI"].Value = _catChofer.ci;
            cmdInsert.Parameters["@Nombre"].Value = _catChofer.nombre;
            cmdInsert.Parameters["@Procedencia"].Value = _catChofer.procedencia;
            return EjecutarComando(cmdInsert);
        }
        public int GuardarCamion(CatCamion _catCamion)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@_Marca"].Value = _catCamion._Marca;
            cmdInsert.Parameters["@_Placa"].Value = _catCamion._Placa;
            cmdInsert.Parameters["@Capacidad"].Value = _catCamion._Capacidad;
            return EjecutarComando(cmdInsert);
        }
        public DataSet TraerChoferes()
        {
            string cadena = "select nombre, ci from tblCatChofer";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet BuscarChoferes(string _nombreB)
        {
            string cadena = "select nombre, ci from tblCatChofer where nombre like '%" + _nombreB + "%'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerPlacas()
        {
            string cadena = "select Id_Camion, placa, marca, capacidad from tblCatCamion";
            return this.EjecutarConsulta(cadena);
        }
        public int EditarCapacidad(string placa, decimal peso)
        {
            return EjecutarComando("UPDATE tblCatCamion set capacidad = " + peso + " WHERE placa = '" + placa + "'");
        }
    }
}
