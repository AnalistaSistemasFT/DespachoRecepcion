using System;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace CAD
{
    public class DBDAC : IDAC
    {


        string sDbKey = string.Empty;
        string sTable = string.Empty;
        DbDataAdapter adaProxy = null;
        DbProviderFactory dpfProxy = null;

        public DbDataAdapter Adapter
        {
            get
            {
                return adaProxy;
            }
        }

        public DBDAC(string sDBKey, string sTable)
        {
            this.sDbKey = sDBKey;
            this.sTable = sTable;
            this.adaProxy = this.CrearAdaptador(this.sTable);
        }

        private string TablaSinEsquema()
        {
            string[] aux = this.sTable.Split(".".ToCharArray());
            if (aux.Length > 1)
            {
                return aux[aux.Length - 1];
            }
            else
            {
                return this.sTable;
            }
        }
        private void Factory()
        {
            if (dpfProxy == null)
            {
                string strProvider = ConfigurationManager.ConnectionStrings[sDbKey].ProviderName;
                dpfProxy = DbProviderFactories.GetFactory(strProvider);
            }
        }
        private DbDataAdapter CrearAdaptador(string strNombreTable)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                string strSelect = string.Format("SELECT * FROM {0}", strNombreTable);
                DbCommand cmdProxy = CrearCommando();
                cmdProxy.CommandText = strSelect;
                cmdProxy.Connection = conProxy;

                DbDataAdapter adaProxy = CrearAdaptador();
                adaProxy.SelectCommand = cmdProxy;

                DbCommandBuilder cblProxy = dpfProxy.CreateCommandBuilder();
                cblProxy.DataAdapter = adaProxy;
                cblProxy.ConflictOption = ConflictOption.OverwriteChanges;
                adaProxy.InsertCommand = cblProxy.GetInsertCommand(true);
                adaProxy.DeleteCommand = cblProxy.GetDeleteCommand(true);
                adaProxy.UpdateCommand = cblProxy.GetUpdateCommand(true);

                return adaProxy;
            }
        }

        public DbConnection AbrirConexion()
        {
            if (dpfProxy == null) Factory();
            string strCon = ConfigurationManager.ConnectionStrings[sDbKey].ConnectionString;
            DbConnection conProxy = dpfProxy.CreateConnection();
            conProxy.ConnectionString = strCon;
            conProxy.Open();
            return conProxy;
        }
        public DbCommand CrearCommando()
        {
            if (dpfProxy == null) Factory();
            DbCommand cmdProxy = dpfProxy.CreateCommand();
            return cmdProxy;
        }

        public DbParameter CrearParametro()
        {
            if (dpfProxy == null) Factory();
            DbParameter parProxy = dpfProxy.CreateParameter();
            return parProxy;
        }
        public DbDataAdapter CrearAdaptador()
        {
            if (dpfProxy == null) Factory();
            DbDataAdapter adaProxy = dpfProxy.CreateDataAdapter();
            return adaProxy;
        }

        public DataSet EjecutarConsulta(string strSelect)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return EjecutarConsulta(strSelect, conProxy, null);
            }
        }
        public DataSet EjecutarConsulta(string strSelect, DbConnection conProxy, DbTransaction trnProxy)
        {
            DbCommand cmdProxy = CrearCommando();
            cmdProxy.CommandText = strSelect;
            return EjecutarConsulta(cmdProxy, conProxy, trnProxy);
        }
        public DataSet EjecutarConsulta(DbCommand cmdProxy)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return EjecutarConsulta(cmdProxy, conProxy, null);
            }
        }
        public DataSet EjecutarConsulta(DbCommand cmdProxy, DbConnection conProxy, DbTransaction trnProxy)
        {
            cmdProxy.Connection = conProxy;
            cmdProxy.Transaction = trnProxy;

            DataSet dtsProxy = new DataSet();
            DbDataAdapter adaProxy = CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;
            adaProxy.Fill(dtsProxy);
            return dtsProxy;
        }
        public DataSet Consultar(string sWhere)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return Consultar(sWhere, conProxy, null);
            }
        }
        public DataSet Consultar(string sWhere, DbConnection conProxy, DbTransaction trnProxy)
        {
            string strSelect = string.Format("SELECT * FROM {0}", this.sTable);
            if (!string.IsNullOrEmpty(sWhere))
            {
                strSelect += string.Format(" WHERE {0}", sWhere);
            }
            DbCommand cmdProxy = CrearCommando();
            cmdProxy.CommandText = strSelect;
            cmdProxy.Connection = conProxy;
            cmdProxy.Transaction = trnProxy;

            DataSet dtsProxy = new DataSet();
            DbDataAdapter adaProxy = CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;
            adaProxy.Fill(dtsProxy, TablaSinEsquema());
            return dtsProxy;
        }
        public DataSet Consultar(DbParameter[] aParams)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return Consultar(aParams, conProxy, null);
            }
        }
        public DataSet Consultar(DbParameter[] aParams, DbConnection conProxy, DbTransaction trnProxy)
        {
            DbCommand cmdProxy = CrearCommando();

            string sWhere = string.Empty;
            foreach (DbParameter parProxy in aParams)
            {
                if (string.IsNullOrEmpty(sWhere))
                {
                    sWhere += string.Format("{0} = @{0}", parProxy.SourceColumn);
                }
                else
                {
                    sWhere += string.Format("AND {0} = @{0}", parProxy.SourceColumn);
                }

                cmdProxy.Parameters.Add(parProxy);
            }

            string strSelect = string.Empty;
            if (string.IsNullOrEmpty(sWhere))
                strSelect = string.Format("SELECT * FROM {0}", this.sTable);
            else
                strSelect = string.Format("SELECT * FROM {0} WHERE {1}", this.sTable, sWhere);

            cmdProxy.CommandText = strSelect;
            cmdProxy.Connection = conProxy;
            cmdProxy.Transaction = trnProxy;

            DataSet dtsProxy = new DataSet();
            DbDataAdapter adaProxy = CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;
            adaProxy.Fill(dtsProxy);
            return dtsProxy;
        }
        public int EjecutarComando(string strDML)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return EjecutarComando(strDML, conProxy, null);
            }
        }
        public int EjecutarComando(string strDML, DbTransaction trnProxy)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return EjecutarComando(strDML, conProxy, trnProxy);
            }
        }
        public int EjecutarComando(string strDML, DbConnection conProxy, DbTransaction trnProxy)
        {
            DbCommand cmdProxy = CrearCommando();
            cmdProxy.CommandText = strDML;
            return EjecutarComando(cmdProxy, conProxy, trnProxy);
        }
        public int EjecutarComando(DbCommand cmdProxy)
        {
            using (DbConnection conProxy = AbrirConexion())
            {
                return EjecutarComando(cmdProxy, conProxy, null);
            }
        }
        public int EjecutarComando(DbCommand cmdProxy, DbConnection conProxy, DbTransaction trnProxy)
        {
            cmdProxy.Connection = conProxy;
            cmdProxy.Transaction = trnProxy;
            return cmdProxy.ExecuteNonQuery();
        }
    }

}
