using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class oledb
    {
        protected string CadenaConexion = string.Empty;
        protected string sConnName = string.Empty;
        protected DbProviderFactory objFactory;

        protected System.Data.Common.DbConnection conectar()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings[sConnName].ToString();
            objFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[sConnName].ProviderName);
            DbConnection obconexion = objFactory.CreateConnection();
            obconexion.ConnectionString = CadenaConexion;
            obconexion.Open();
            return obconexion;
        }

        protected System.Data.Common.DbTransaction IniciarTransaccion()
        {
            
            System.Data.Common.DbConnection obconexion = conectar();
            return obconexion.BeginTransaction();
        }
        protected System.Data.Common.DbTransaction IniciarTransaccion(string sCon)
        {
            sConnName = sCon;
            System.Data.Common.DbConnection obconexion = conectar();
            return obconexion.BeginTransaction();
        }

        protected System.Data.Common.DbTransaction inicio_tr()
        {
            return IniciarTransaccion();
        }

        protected System.Data.DataSet consultar(string csql)
        {
            System.Data.Common.DbConnection obconexion = conectar(); 
            System.Data.Common.DbTransaction obtransaccion = obconexion.BeginTransaction();
            DataSet ds = consultar(csql, obtransaccion);
            obconexion.Close();
            return ds;
        }
        protected System.Data.DataSet consultar(string csql,string sConexion)
        {
            sConnName = sConexion;
            System.Data.Common.DbConnection obconexion = conectar();
            System.Data.Common.DbTransaction obtransaccion = obconexion.BeginTransaction();
            DataSet ds = consultar(csql, obtransaccion);
            obconexion.Close();
            return ds;
        }

        protected System.Data.DataSet consultar(string csql, System.Data.Common.DbTransaction obtransaccion)
        {
            System.Data.Common.DbCommand comando = obtransaccion.Connection.CreateCommand();
            comando.CommandTimeout = 0;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = obtransaccion.Connection;
            comando.Transaction = obtransaccion;
            comando.CommandText = csql;

            objFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[sConnName].ProviderName);
            System.Data.Common.DbDataAdapter adaptador = objFactory.CreateDataAdapter();
            adaptador.SelectCommand = comando;
            System.Data.DataSet ConjuntoDatos = new System.Data.DataSet();
            adaptador.Fill(ConjuntoDatos);
            return ConjuntoDatos;
        }

        protected int ejecutar(ref string er, string csql)
        {
            System.Data.Common.DbConnection obconexion = conectar();
            System.Data.Common.DbTransaction obtransaccion = obconexion.BeginTransaction();
            int i = ejecutar(ref er, csql, obtransaccion);
            obtransaccion.Commit();
            obconexion.Close();
            return i;
        }

        protected int ejecutar1(ref string er, string csql, System.Data.Common.DbTransaction obtransaccion)
        {
            try
            {
                System.Data.Common.DbCommand comando = obtransaccion.Connection.CreateCommand();
                comando.CommandText = csql;
                comando.Transaction = obtransaccion;
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return 0;
            }
        }

        protected int ejecutar(ref string er, string csql, System.Data.Common.DbTransaction obtransaccion)
        {
            try
            {
                System.Data.Common.DbCommand comando = obtransaccion.Connection.CreateCommand();
                comando.CommandText = csql;
                comando.Transaction = obtransaccion;
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return 0;
            }
        }

        protected System.Data.DataTable consultarD(string csql)
        {
            System.Data.Common.DbConnection obconexion = conectar();
            System.Data.Common.DbTransaction obtransaccion = obconexion.BeginTransaction();
            DataTable dt = consultarD(csql, obtransaccion);
            obconexion.Close();
            return dt;
        }

        protected System.Data.DataTable consultarD(string csql, System.Data.Common.DbTransaction obtransaccion)
        {
            System.Data.Common.DbCommand comando = obtransaccion.Connection.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = obtransaccion.Connection;
            comando.Transaction = obtransaccion;
            comando.CommandText = csql;

            objFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[sConnName].ProviderName);
            System.Data.Common.DbDataAdapter adaptador = objFactory.CreateDataAdapter();
            adaptador.SelectCommand = comando;
            System.Data.DataTable ConjuntoDatos = new System.Data.DataTable();
            adaptador.Fill(ConjuntoDatos);
            return ConjuntoDatos;
        }



    }
}
