using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CDetalleTraspaso
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
        private decimal scmvicme;
        private decimal scmvpumo;
        private decimal scmvicmo;
        private decimal scmvpvus;
        private decimal scmvivus;
        private decimal scmvpvmn;
        private decimal scmvivmn;
        private decimal scmvsssu;
        private decimal scmvisco;
        private decimal scmvssco;

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
        public decimal p_scmvicme
        {
            get { return scmvicme; }
            set { scmvicme = value; }
        }
        public decimal p_scmvpumo
        {
            get { return scmvpumo; }
            set { scmvpumo = value; }
        }
        public decimal p_scmvicmo
        {
            get { return scmvicmo; }
            set { scmvicmo = value; }
        }
        public decimal p_scmvpvus
        {
            get { return scmvpvus; }
            set { scmvpvus = value; }
        }
        public decimal p_scmvivus
        {
            get { return scmvivus; }
            set { scmvivus = value; }
        }
        public decimal p_scmvpvmn
        {
            get { return scmvpvmn; }
            set { scmvpvmn = value; }
        }
        public decimal p_scmvivmn
        {
            get { return scmvivmn; }
            set { scmvivmn = value; }
        }
        public decimal p_scmvsssu
        {
            get { return scmvsssu; }
            set { scmvsssu = value; }
        }
        public decimal p_scmvisco
        {
            get { return scmvisco; }
            set { scmvisco = value; }
        }
        public decimal p_scmvssco
        {
            get { return scmvssco; }
            set { scmvssco = value; }
        }

        //InsertarDetalleTraspaso
        public int InsertarDespDetalle(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"Insert into scmovart
                              (scmvtdoc, scmvndoc, scmvnart, scmvctra, scmvfdoc, scmvfreg, scmvcsuc, scmvcmov, scmvcant, scmvicme, scmvpumo, scmvicmo, scmvpvus, scmvivus, scmvpvmn, scmvivmn, scmvsssu, scmvisco, scmvssco)
                              VALUES
                              ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})";
            sInsert = string.Format(sInsert, p_scmvtdoc, p_scmvndoc, p_scmvnart, p_scmvctra, p_scmvfdoc.ToString("dd/MM/yyyy"), p_scmvfreg.ToString("dd/MM/yyyy"), p_scmvcsuc, p_scmvcorr, p_scmvcmov, p_scmvcant, p_scmvicme, p_scmvpumo, p_scmvicmo, p_scmvpvus, p_scmvivus, p_scmvpvmn, p_scmvivmn, p_scmvsssu, p_scmvisco, p_scmvssco);
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
