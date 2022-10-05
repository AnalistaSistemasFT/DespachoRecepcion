using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CTraspaso : oledb
    {
        private decimal sctttdoc; //tipo doc
        private decimal scttndoc; //numero doc
        private decimal sctiptra; //tipo de transaccion = 26001
        private DateTime scttfdoc; //fecha documento(actual)
        private DateTime scttfreg; //fecha registro(actual)
        private decimal scttsuce; //sucursal envia
        private decimal scttsucr; //sucursal recibe
        private string scttdesc; //por defecto "traspaso por abastecimiento por venta (mas numero de despacho)"

        public decimal p_sctttdoc
        {
            get { return sctttdoc; }
            set { sctttdoc = value; }
        }
        public decimal p_scttndoc
        {
            get { return scttndoc; }
            set { scttndoc = value; }
        }
        public decimal p_sctiptra
        {
            get { return sctiptra; }
            set { sctiptra = value; }
        }
        public DateTime p_scttfdoc
        {
            get { return scttfdoc; }
            set { scttfdoc = value; }
        }
        public DateTime p_scttfreg
        {
            get { return scttfreg; }
            set { scttfreg = value; }
        }
        public decimal p_scttsuce
        {
            get { return scttsuce; }
            set { scttsuce = value; }
        }
        public decimal p_scttsucr
        {
            get { return scttsucr; }
            set { scttsucr = value; }
        }
        public string p_scttdesc
        {
            get { return scttdesc; }
            set { scttdesc = value; }
        }
        CADTraspaso _cadTraspaso = new CADTraspaso();
        public int GuardarTraspaso(ref string sError, scttrasp _Traspaso)
        {
            return _cadTraspaso.GuardarTraspaso(ref sError, _Traspaso);
        }
        public DataSet TraerTipoDoc(int _IdSucursal)
        {
            return _cadTraspaso.TraerTipoDoc(_IdSucursal);
        }
        public DataSet TraerCorrelativo(int _IdSucursal)
        {
            return _cadTraspaso.TraerCorrelativo(_IdSucursal);
        }
        public DataSet TraerCosto(string _IdProd)
        {
            return _cadTraspaso.TraerCosto(_IdProd);
        }
        public DataSet TraerTransitos()
        {
            return _cadTraspaso.TraerTransitos();
        }
        public CTraspaso()
        {
            this.sConnName = "FTINF";
        }
        //
        public DataSet TraerCorrTrasp(int _IdSucursal)
        {
            string consulta = "select sctcvalo + 1 from sctabcon where sccodfin = " + _IdSucursal;
            return this.consultar(consulta);
        }
        //
        public int InserTraspaso(scttrasp _traspaso, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO scttrasp (sctttdoc, scttndoc, sctiptra, scttfdoc, scttfreg, scttsuce, scttsucr, scttdesc) VALUES ({0}, {1}, {2}, '{3}', '{4}', {5}, {6}, '{7}')";
            sInsert = string.Format(sInsert, _traspaso.p_sctttdoc, _traspaso.p_scttndoc, _traspaso.p_sctiptra, _traspaso.p_scttfdoc.ToString("dd/MM/yyyy"), _traspaso.p_scttfreg.ToString("dd/MM/yyyy"), _traspaso.p_scttsuce, _traspaso.p_scttsucr, _traspaso.p_scttdesc);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public int ActualizarUltimoTraspaso(int sctcvalo, int sccodfin, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE sctabcon SET sctcvalo = {0} WHERE sccodfin = {1}";
            sUpdate = string.Format(sUpdate, sctcvalo, sccodfin);
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        public int InsertarMovArt(scmovart _SCmovart, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO scmovart (scmvtdoc, scmvndoc, scmvnart, scmvctra, scmvfdoc, scmvfreg, scmvcsuc, scmvcmov, scmvcant, scmvicme, scmvpumo, scmvicmo, scmvpvus, scmvivus, scmvpvmn, scmvivmn, scmvsssu, scmvisco, scmvssco)
                                VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})";
            sInsert = string.Format(sInsert, _SCmovart.p_scmvtdoc, _SCmovart.p_scmvndoc, _SCmovart.p_scmvnart, _SCmovart.p_scmvctra, _SCmovart.p_scmvfdoc.ToString("dd/MM/yyyy"), _SCmovart.p_scmvfreg.ToString("dd/MM/yyyy"), _SCmovart.p_scmvcsuc, _SCmovart.p_scmvcmov, _SCmovart.p_scmvcant, _SCmovart.p_scmvicme, _SCmovart.p_scmvicme, _SCmovart.p_scmvpumo, _SCmovart.p_scmvicmo, _SCmovart.p_scmvpvus, _SCmovart.p_scmvivus, _SCmovart.p_scmvpvmn, _SCmovart.p_scmvivmn, _SCmovart.p_scmvsssu, _SCmovart.p_scmvisco, _SCmovart.p_scmvssco);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        //
        public DataSet ConsultarArticuloxSucursal(int iSucursal, int iNroAericulo, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sSelect = @"select * from scartsuc where scasnsuc = {0} and scasnart = {1}";
            sSelect = string.Format(sSelect, iSucursal, iNroAericulo);
            return this.consultar(sSelect, trnProxy);
        }
        //
        public int ModificarArtSuc(scartsuc _SCartsuc, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE INTO scarsuc SET scasnsuc = {0}, scasnart = {1}, scasabc1 = '{2}', scasabc2 = '{3}', scasabc3 = '{4}', scasabc4 = '{5}', scasstto = {6}, scasstdi = {7}, scasstco = {8}, scasccin = {9}, scasubic = {10}, scasfuls = '{11}', scastmin = {12}, scastmax = {13}
                                WHERE scasnsuc = {0}";
            sUpdate = string.Format(sUpdate, _SCartsuc.p_scasnsuc, _SCartsuc.p_scasnart, _SCartsuc.p_scasabc1, _SCartsuc.p_scasabc2, _SCartsuc.p_scasabc3, _SCartsuc.p_scasabc4, _SCartsuc.p_scasstto, _SCartsuc.p_scasstdi, _SCartsuc.p_scasstco, _SCartsuc.p_scasccin, _SCartsuc.p_scasubic, _SCartsuc.p_scasfuls, _SCartsuc.p_scastmin, _SCartsuc.p_scastmax);
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        public int InsertarArtSuc(scartsuc _SCartsuc, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO scartsuc (scasnsuc, scasnart, scasabc1, scasabc2, scasabc3, scasabc4, scasstto, scasstdi, scasstco, scasstdi, scasstco, scasccin, scasubic, scasfuls, scastmin, scastmax)
                               VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, '{11}', {12}, {13})";
            sInsert = string.Format(sInsert, _SCartsuc.p_scasnsuc, _SCartsuc.p_scasnart, _SCartsuc.p_scasabc1, _SCartsuc.p_scasabc2, _SCartsuc.p_scasabc3, _SCartsuc.p_scasabc4, _SCartsuc.p_scasstto, _SCartsuc.p_scasstdi, _SCartsuc.p_scasstco, _SCartsuc.p_scasstdi, _SCartsuc.p_scasstco, _SCartsuc.p_scasccin, _SCartsuc.p_scasubic, _SCartsuc.p_scasfuls, _SCartsuc.p_scastmin, _SCartsuc.p_scastmax);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public int InsertarTraspaso(scttrasp _traspaso, DataTable dt, int isucursal)
        {
            int a = 0;
            //sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {
                    a = this.InserTraspaso(_traspaso, trnSql);
                    if (a > 0)
                    {

                        if (dt.Rows.Count == 0)
                        {
                            //
                        }
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                CDetalleTraspaso _detalleTrasp = new CDetalleTraspaso();
                                _detalleTrasp.p_scmvtdoc = Convert.ToDecimal(dt.Rows[i][0]);
                                _detalleTrasp.p_scmvndoc = Convert.ToDecimal(dt.Rows[i][1]);
                                _detalleTrasp.p_scmvnart = Convert.ToDecimal(dt.Rows[i][2]);
                                _detalleTrasp.p_scmvctra = Convert.ToDecimal(dt.Rows[i][3]);
                                _detalleTrasp.p_scmvfdoc = Convert.ToDateTime(dt.Rows[i][4]);
                                _detalleTrasp.p_scmvfreg = Convert.ToDateTime(dt.Rows[i][5]);
                                _detalleTrasp.p_scmvcsuc = Convert.ToDecimal(dt.Rows[i][6]);
                                //_detalleTrasp.p_scmvcorr = Convert.ToInt32(dt.Rows[i][7]);
                                _detalleTrasp.p_scmvcmov = Convert.ToDecimal(dt.Rows[i][8]);
                                _detalleTrasp.p_scmvcant = Convert.ToDecimal(dt.Rows[i][9]);
                                _detalleTrasp.p_scmvicme = Convert.ToDecimal(dt.Rows[i][10]);
                                _detalleTrasp.p_scmvpumo = Convert.ToDecimal(dt.Rows[i][11]);
                                _detalleTrasp.p_scmvicmo = Convert.ToDecimal(dt.Rows[i][12]);
                                _detalleTrasp.p_scmvpvus = Convert.ToDecimal(dt.Rows[i][13]);
                                _detalleTrasp.p_scmvivus = Convert.ToDecimal(dt.Rows[i][14]);
                                _detalleTrasp.p_scmvpvmn = Convert.ToDecimal(dt.Rows[i][15]);
                                _detalleTrasp.p_scmvivmn = Convert.ToDecimal(dt.Rows[i][16]);
                                _detalleTrasp.p_scmvsssu = Convert.ToDecimal(dt.Rows[i][17]);
                                _detalleTrasp.p_scmvisco = Convert.ToDecimal(dt.Rows[i][18]);
                                _detalleTrasp.p_scmvssco = Convert.ToDecimal(dt.Rows[i][19]);
                                a = _detalleTrasp.InsertarDespDetalle(trnSql);
                                if (a == 0)
                                {
                                    break;
                                }
                            }
                            if (a > 0)
                            {
                                int sctcvalo = 0;
                                int sccodfin = isucursal;
                                DataSet dataCorr = TraerCorrTrasp(isucursal);
                                foreach (DataRow item in dataCorr.Tables[0].Rows)
                                {
                                    sctcvalo = Convert.ToInt32(item[0]);
                                }
                                a = ActualizarUltimoTraspaso(sctcvalo, sccodfin, trnSql);
                                if (a > 0)
                                {
                                    for (int intPos = 0; intPos < dt.Rows.Count; ++intPos)
                                    {
                                        scmovart _SCmovart = new scmovart();
                                        _SCmovart.p_scmvtdoc = Convert.ToDecimal(dt.Rows[intPos][0]);
                                        _SCmovart.p_scmvndoc = Convert.ToDecimal(dt.Rows[intPos][1]);
                                        _SCmovart.p_scmvnart = Convert.ToDecimal(dt.Rows[intPos][2]);
                                        _SCmovart.p_scmvctra = Convert.ToDecimal(dt.Rows[intPos][3]);
                                        _SCmovart.p_scmvfdoc = Convert.ToDateTime(dt.Rows[intPos][4]);
                                        _SCmovart.p_scmvfreg = Convert.ToDateTime(dt.Rows[intPos][5]);
                                        _SCmovart.p_scmvcsuc = Convert.ToDecimal(dt.Rows[intPos][6]);
                                        //_SCmovart.p_scmvcorr = Convert.ToInt32(dt.Rows[intPos][7]);
                                        _SCmovart.p_scmvcmov = Convert.ToDecimal(dt.Rows[intPos][8]); ;
                                        _SCmovart.p_scmvcant = Convert.ToDecimal(dt.Rows[intPos][9]);
                                        _SCmovart.p_scmvicme = Convert.ToDecimal(dt.Rows[intPos][10]);
                                        _SCmovart.p_scmvpumo = 0;
                                        _SCmovart.p_scmvicmo = 0;
                                        _SCmovart.p_scmvpvus = 0;
                                        _SCmovart.p_scmvivus = 0;
                                        _SCmovart.p_scmvpvmn = 0;
                                        _SCmovart.p_scmvivmn = 0;
                                        _SCmovart.p_scmvsssu = 0;
                                        _SCmovart.p_scmvisco = 0;
                                        _SCmovart.p_scmvssco = 0;
                                        int num = InsertarMovArt(_SCmovart, trnSql);
                                        if (num > 0)
                                        {
                                            int v_scttsucr = Convert.ToInt32(dt.Rows[intPos][6]);
                                            int v_scmvnart = Convert.ToInt32(dt.Rows[intPos][2]); ;
                                            DataSet dataSet1 = ConsultarArticuloxSucursal(v_scttsucr, v_scmvnart, trnSql);
                                            scartsuc _SCartsuc = new scartsuc();
                                            if (dataSet1.Tables[0].Rows.Count > 0)
                                            {
                                                //scartsuc _SCartsuc = new scartsuc();
                                                Decimal dAssTco = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dataSet1.Tables[0].Rows[0]["scasstco"].ToString()))
                                                    dAssTco = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstco"].ToString());
                                                Decimal dAscCin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dataSet1.Tables[0].Rows[0]["scasccin"].ToString()))
                                                    dAscCin = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasccin"].ToString());
                                                Decimal dUbicacion = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dataSet1.Tables[0].Rows[0]["scasubic"].ToString()))
                                                    dUbicacion = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasubic"].ToString());
                                                Decimal dAstMin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dataSet1.Tables[0].Rows[0]["scastmin"].ToString()))
                                                    dAstMin = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scastmin"].ToString());
                                                Decimal dAstMax = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dataSet1.Tables[0].Rows[0]["scastmax"].ToString()))
                                                    dAstMax = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scastmax"].ToString());
                                                _SCartsuc.p_scasnsuc = v_scttsucr;
                                                _SCartsuc.p_scasnart = v_scmvnart;
                                                _SCartsuc.p_scasabc1 = dataSet1.Tables[0].Rows[0]["scasabc1"].ToString();
                                                _SCartsuc.p_scasabc2 = dataSet1.Tables[0].Rows[0]["scasabc2"].ToString();
                                                _SCartsuc.p_scasabc3 = dataSet1.Tables[0].Rows[0]["scasabc3"].ToString();
                                                _SCartsuc.p_scasabc4 = dataSet1.Tables[0].Rows[0]["scasabc4"].ToString();
                                                _SCartsuc.p_scasstto = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstto"]) + Convert.ToDecimal(dt.Rows[intPos][9]);
                                                _SCartsuc.p_scasstdi = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstdi"]) + Convert.ToDecimal(dt.Rows[intPos][9]);
                                                _SCartsuc.p_scasstco = dAssTco;
                                                _SCartsuc.p_scasccin = dAscCin;
                                                _SCartsuc.p_scasubic = dUbicacion;
                                                _SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                                _SCartsuc.p_scastmax = dAstMin;
                                                _SCartsuc.p_scastmax = dAstMax;
                                                num = ModificarArtSuc(_SCartsuc, trnSql);
                                                if (num == 0)
                                                {
                                                    trnSql.Rollback();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                num = InsertarArtSuc(_SCartsuc, trnSql);
                                                if (num == 0)
                                                {
                                                    trnSql.Rollback();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            trnSql.Rollback();
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    trnSql.Rollback();

                                }
                            }
                            else
                            {
                                trnSql.Rollback();
                                trnSql.Dispose();
                            }
                        }
                    }
                    trnSql.Rollback();
                    trnSql.Dispose();
                }
                catch (Exception err)
                {
                    Console.WriteLine("################# = " + err.ToString());
                    trnSql.Rollback();
                    trnSql.Dispose();
                }
                return a;
            }
        }
    }
}