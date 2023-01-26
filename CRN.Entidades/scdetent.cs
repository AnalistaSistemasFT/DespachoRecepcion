using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class scdetent
    {
        private decimal scmvtdoc;
        private decimal scmvndoc;
        private decimal scmvnart;
        private decimal scmvctra;
        private DateTime scmvfdoc;
        private DateTime scmvfreg;
        private decimal scmvcsuc;
        private int scmvcorr;
        private decimal scmvcmov;
        private decimal scmvcant;

        public decimal p_scmvtdoc
        {
            get { return scmvtdoc; }
            set { scmvtdoc = value; }
        }
        public decimal p_scmvndoc
        {
            get { return scmvndoc; }
            set { scmvndoc = value; }
        }
        public decimal p_scmvnart
        {
            get { return scmvnart; }
            set { scmvnart = value; }
        }
        public decimal p_scmvctra
        {
            get { return scmvctra; }
            set { scmvctra = value; }
        }
        public DateTime p_scmvfdoc
        {
            get { return scmvfdoc; }
            set { scmvfdoc = value; }
        }
        public DateTime p_scmvfreg
        {
            get { return scmvfreg; }
            set { scmvfreg = value; }
        }
        public decimal p_scmvcsuc
        {
            get { return scmvcsuc; }
            set { scmvcsuc = value; }
        }
        public int p_scmvcorr
        {
            get { return scmvcorr; }
            set { scmvcorr = value; }
        }
        public decimal p_scmvcmov
        {
            get { return scmvcmov; }
            set { scmvcmov = value; }
        }
        public decimal p_scmvcant
        {
            get { return scmvcant; }
            set { scmvcant = value; }
        }
        //InsertarDetalleEntrega
        public int InsertarDetEntrega(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"Insert into scdetent
                              ([scmvtdoc], [scmvndoc], [scmvnart], [scmvctra], [scmvfdoc], [scmvfreg], [scmvcsuc], [scmvcorr], [scmvcmov], [scmvcant])
                              VALUES
                              ({0},{1},{2},{3},'{4}','{5}',{6},{7},{8})";
            sInsert = string.Format(sInsert, scmvtdoc, scmvndoc, scmvnart, scmvctra, scmvfdoc.ToString("dd/MM/yyyy"), scmvfreg.ToString("dd/MM/yyyy"), scmvcsuc, scmvcorr, scmvcmov, scmvcant);
            return ejecutar(ref sError, sInsert, trnproxy);
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
    }
}
