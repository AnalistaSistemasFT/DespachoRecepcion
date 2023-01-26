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
        public DataSet TraerCorrelativo(string tipoDodId)
        {
            return _cadTraspaso.TraerCorrelativo(tipoDodId);
        }
        public DataSet TraerCosto(string _IdProd)
        {
            return _cadTraspaso.TraerCosto(_IdProd);
        }
        public DataSet TraerTransitos()
        {
            return _cadTraspaso.TraerTransitos();
        }
        CDespacho C_Despacho;
        public CTraspaso()
        {
            this.sConnName = "FTINF";
            C_Despacho = new CDespacho();
        }
        //

        public int ObtenerNumeroDocumento(int iCodFin, DbTransaction trnProxy)
        {
            //string sWhere = string.Format("estado = '{0}'", sEstado);
            string sSelect = "SELECT sctcvalo FROM sctabcon WHERE sccodfin = {0}";
            sSelect = string.Format(sSelect, iCodFin);
            DataSet dtsResult = this.consultar(sSelect, trnProxy);
            if (dtsResult.Tables[0].Rows[0]["sctcvalo"] != DBNull.Value)
            {
                return Convert.ToInt32(dtsResult.Tables[0].Rows[0]["sctcvalo"]) + 1;

            }
            else
            {
                return 0;
            }
        }

        //
        public int InserTraspaso(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO scttrasp (sctttdoc, scttndoc, sctiptra, scttfdoc, scttfreg, scttsuce, scttsucr, scttdesc) VALUES ({0}, {1}, {2}, '{3}', '{4}', {5}, {6}, '{7}')";
            sInsert = string.Format(sInsert, p_sctttdoc, p_scttndoc, p_sctiptra, p_scttfdoc.ToString("dd/MM/yyyy"), p_scttfreg.ToString("dd/MM/yyyy"), p_scttsuce, p_scttsucr, p_scttdesc);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public int InserTraspasoDesp(scttrasp _traspaso, DbTransaction trnproxy)
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
        public int ActualizarMovPdv(int tipo, int nro, string mov, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"update tblmovpdv set tipodoc = {0}, nrodoc = {1}, status = 'CLOSE' where movimientoid = '{2}'";
            sUpdate = string.Format(sUpdate, tipo, nro, mov.Trim());
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
        public DataSet ConsultarTraspaso(int tipo, int nrodoc)
        {
            string sError = string.Empty;
            string sSelect = @"select t.sctttdoc,t.scttndoc,t,scttfdoc,t.scttfreg,t.scttsuce, se.sctcdesc as sucent,t.scttsucr,sr.sctcdesc as sucrec,t.scttdesc,m.scmvnart,a.scmadesc,u.sctcdesc as um,a.scmapeso,m.scmvcant,
                        d.sctcdesc desctras, b.sctcdesc tiptra, A.scmanori
                       from scttrasp t inner join
                    scmovart m on t.sctttdoc = m.scmvtdoc and t.scttndoc = m.scmvndoc inner join
                    sctabcon se on t.scttsuce = se.sccodfin inner join
                    sctabcon sr on t.scttsucr = sr.sccodfin inner join
                    scmaster a on m.scmvnart = a.scmanart inner join
                    sctabcon u on a.scmaumed = u.sccodfin inner join
                    sctabcon d on t.sctttdoc = d.sccodfin INNER JOIN
                    sctabcon b on t.sctiptra = b.sccodfin
                    where t.sctttdoc = {0}
            and t.scttndoc = {1}
            and m.scmvcmov = 7001";
            sSelect = string.Format(sSelect, tipo, nrodoc);
            return this.consultar(sSelect);
        }


        //
        public int ModificarArtSuc(scartsuc _SCartsuc, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE  scartsuc SET scasabc1 = '{2}', scasabc2 = '{3}', scasabc3 = '{4}', scasabc4 = '{5}', scasstto = {6}, scasstdi = {7}, scasstco = {8}, scasccin = {9}, scasubic = {10},  scastmin = {11}, scastmax = {12}
                                WHERE scasnsuc = {0} and scasnart = {1} ";
            sUpdate = string.Format(sUpdate, _SCartsuc.p_scasnsuc, _SCartsuc.p_scasnart, _SCartsuc.p_scasabc1, _SCartsuc.p_scasabc2, _SCartsuc.p_scasabc3, _SCartsuc.p_scasabc4, _SCartsuc.p_scasstto, _SCartsuc.p_scasstdi, _SCartsuc.p_scasstco, _SCartsuc.p_scasccin, _SCartsuc.p_scasubic, _SCartsuc.p_scastmin, _SCartsuc.p_scastmax);
            return ejecutar(ref sError, sUpdate, trnproxy);
        }
        public int InsertarArtSuc(scartsuc _SCartsuc, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO scartsuc (scasnsuc, scasnart, scasabc1, scasabc2, scasabc3, scasabc4, scasstto, scasstdi, scasstco, scasccin, scasubic, scastmin, scastmax)
                               VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12})";
            sInsert = string.Format(sInsert, _SCartsuc.p_scasnsuc, _SCartsuc.p_scasnart, _SCartsuc.p_scasabc1, _SCartsuc.p_scasabc2, _SCartsuc.p_scasabc3, _SCartsuc.p_scasabc4, _SCartsuc.p_scasstto, _SCartsuc.p_scasstdi, _SCartsuc.p_scasstco, _SCartsuc.p_scasccin, _SCartsuc.p_scasubic, _SCartsuc.p_scastmin, _SCartsuc.p_scastmax);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public DataSet ConsultarArticulo(int iNroArt, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sSelect = "select * from scmaster where scmanart = " + iNroArt;
            DataSet dtsresult = this.consultar(sSelect, trnProxy);
            return dtsresult;

        }
        
        public int ModificarNumTraspasoDespacho(string _idDespacho, string _numTrasp)
        {
            string sError = string.Empty;
            string sUpdate = @"UPDATE tblDespacho SET NumTraspaso = '" + _numTrasp + "' WHERE DespachoId = '" + _idDespacho + "'";
            return ejecutar(ref sError, sUpdate);
        }
        public int InsertarTraspasoDespacho(scttrasp _traspaso, DataTable dt, string Movimiento, string _IdDespacho)
        {
            int a = 0;
            //sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {
                    int sctcvalo = 0;
                    int sccodfin = Convert.ToInt32(_traspaso.p_sctttdoc);
                    sctcvalo = ObtenerNumeroDocumento(sccodfin, trnSql);
                    string _NumTraspaso = sctcvalo.ToString();
                    this.p_scttndoc = sctcvalo;
                    a = this.InserTraspasoDesp(_traspaso, trnSql);
                    if (a > 0)
                    {
                        a = ActualizarUltimoTraspaso(sctcvalo, sccodfin, trnSql);
                        if (a > 0)
                        {
                            //
                            //a = ActualizarMovPdv(sccodfin, sctcvalo, Movimiento, trnSql);

                            a = C_Despacho.ModificarNumTraspasoDespacho(_IdDespacho, _NumTraspaso);
                            if (a > 0)
                            {
                                for (int intPos = 0; intPos < dt.Rows.Count; ++intPos)
                                {
                                    int itemF = Convert.ToInt32(dt.Rows[intPos]["p_scmvnart"]);
                                    decimal Cantidad = Convert.ToDecimal(dt.Rows[intPos]["p_scmvcant"]);
                                    scmovart _SCmovart = new scmovart();
                                    DataSet dtsMasterFT = ConsultarArticulo(itemF, trnSql);
                                    decimal scmappce = Convert.ToDecimal(dtsMasterFT.Tables[0].Rows[0]["scmappce"]);

                                    _SCmovart.p_scmvtdoc = Convert.ToDecimal(sccodfin);
                                    _SCmovart.p_scmvndoc = Convert.ToDecimal(sctcvalo);
                                    _SCmovart.p_scmvnart = Convert.ToDecimal(itemF);
                                    _SCmovart.p_scmvctra = Convert.ToDecimal(10004);//Convert.ToDecimal(dt.Rows[intPos][3]);
                                    _SCmovart.p_scmvfdoc = DateTime.Now;
                                    _SCmovart.p_scmvfreg = DateTime.Now;
                                    _SCmovart.p_scmvcsuc = Convert.ToDecimal(dt.Rows[intPos]["p_scmvcsuc"]);
                                    //_SCmovart.p_scmvcorr = Convert.ToInt32(dt.Rows[intPos][7]);
                                    _SCmovart.p_scmvcmov = Convert.ToDecimal(7001);
                                    _SCmovart.p_scmvcant = Cantidad;
                                    _SCmovart.p_scmvicme = Cantidad * scmappce;
                                    _SCmovart.p_scmvpumo = scmappce;
                                    _SCmovart.p_scmvicmo = 0;
                                    _SCmovart.p_scmvpvus = 0;
                                    _SCmovart.p_scmvivus = 0;
                                    _SCmovart.p_scmvpvmn = 0;
                                    _SCmovart.p_scmvivmn = 0;
                                    _SCmovart.p_scmvsssu = 0;
                                    _SCmovart.p_scmvisco = 0;
                                    _SCmovart.p_scmvssco = 0;
                                    a = InsertarMovArt(_SCmovart, trnSql);
                                    if (a > 0)
                                    {
                                        DataSet dataSet1 = ConsultarArticuloxSucursal(Convert.ToInt32(_traspaso.p_scttsucr), itemF, trnSql);
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
                                            _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.p_scttsucr);
                                            _SCartsuc.p_scasnart = itemF;
                                            _SCartsuc.p_scasabc1 = dataSet1.Tables[0].Rows[0]["scasabc1"].ToString();
                                            _SCartsuc.p_scasabc2 = dataSet1.Tables[0].Rows[0]["scasabc2"].ToString();
                                            _SCartsuc.p_scasabc3 = dataSet1.Tables[0].Rows[0]["scasabc3"].ToString();
                                            _SCartsuc.p_scasabc4 = dataSet1.Tables[0].Rows[0]["scasabc4"].ToString();
                                            _SCartsuc.p_scasstto = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstto"]) + Cantidad;
                                            _SCartsuc.p_scasstdi = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstdi"]) + Cantidad;
                                            _SCartsuc.p_scasstco = dAssTco;
                                            _SCartsuc.p_scasccin = dAscCin;
                                            _SCartsuc.p_scasubic = dUbicacion;
                                            //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                            _SCartsuc.p_scastmax = dAstMin;
                                            _SCartsuc.p_scastmax = dAstMax;
                                            a = ModificarArtSuc(_SCartsuc, trnSql);
                                            if (a == 0)
                                                break;
                                        }
                                        else
                                        {
                                            _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.p_scttsucr);
                                            _SCartsuc.p_scasnart = itemF;
                                            _SCartsuc.p_scasabc1 = "0";
                                            _SCartsuc.p_scasabc2 = "0";
                                            _SCartsuc.p_scasabc3 = "0";
                                            _SCartsuc.p_scasabc4 = "0";
                                            _SCartsuc.p_scasstto = Cantidad;
                                            _SCartsuc.p_scasstdi = Cantidad;
                                            _SCartsuc.p_scasstco = 0;
                                            _SCartsuc.p_scasccin = 0;
                                            _SCartsuc.p_scasubic = 0;
                                            //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                            _SCartsuc.p_scastmax = 0;
                                            _SCartsuc.p_scastmax = 0;
                                            a = InsertarArtSuc(_SCartsuc, trnSql);
                                            if (a == 0)
                                                break;
                                        }
                                    }
                                    else
                                        break;
                                    if (a > 0)
                                    {
                                        _SCmovart.p_scmvcsuc = Convert.ToDecimal(_traspaso.p_scttsuce);
                                        _SCmovart.p_scmvctra = Convert.ToDecimal(11006);
                                        _SCmovart.p_scmvcmov = Convert.ToDecimal(7002);
                                        a = InsertarMovArt(_SCmovart, trnSql);
                                        if (a > 0)
                                        {
                                            DataSet dtsARTSUC1 = ConsultarArticuloxSucursal(Convert.ToInt32(_traspaso.p_scttsuce), itemF, trnSql);
                                            if (dtsARTSUC1.Tables[0].Rows.Count > 0)
                                            {
                                                Decimal dAssTco = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasstco"].ToString()))
                                                    dAssTco = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstco"].ToString());
                                                Decimal dAscCin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasccin"].ToString()))
                                                    dAscCin = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasccin"].ToString());
                                                Decimal dUbicacion = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasubic"].ToString()))
                                                    dUbicacion = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasubic"].ToString());
                                                Decimal dAstMin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scastmin"].ToString()))
                                                    dAstMin = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scastmin"].ToString());
                                                Decimal dAstMax = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scastmax"].ToString()))
                                                    dAstMax = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scastmax"].ToString());
                                                //if (Cantidad <= Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstto"]))
                                                if (Cantidad > 0)
                                                {
                                                    scartsuc _SCartsuc = new scartsuc();
                                                    _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.p_scttsuce);
                                                    _SCartsuc.p_scasnart = itemF;
                                                    _SCartsuc.p_scasabc1 = dtsARTSUC1.Tables[0].Rows[0]["scasabc1"].ToString();
                                                    _SCartsuc.p_scasabc2 = dtsARTSUC1.Tables[0].Rows[0]["scasabc2"].ToString();
                                                    _SCartsuc.p_scasabc3 = dtsARTSUC1.Tables[0].Rows[0]["scasabc3"].ToString();
                                                    _SCartsuc.p_scasabc4 = dtsARTSUC1.Tables[0].Rows[0]["scasabc4"].ToString();
                                                    _SCartsuc.p_scasstto = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstto"]) - Cantidad;
                                                    _SCartsuc.p_scasstdi = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstdi"]) - Cantidad;
                                                    _SCartsuc.p_scasstco = dAssTco;
                                                    _SCartsuc.p_scasccin = dAscCin;
                                                    _SCartsuc.p_scasubic = dUbicacion;
                                                    //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                                    _SCartsuc.p_scastmax = dAstMin;
                                                    _SCartsuc.p_scastmax = dAstMax;
                                                    a = ModificarArtSuc(_SCartsuc, trnSql);
                                                    if (a == 0)
                                                    {
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    a = -1;
                                                    C_Despacho.RBTraspDesp(_IdDespacho);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                a = -1;
                                                C_Despacho.RBTraspDesp(_IdDespacho);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                C_Despacho.RBTraspDesp(_IdDespacho);
                            }
                            if (a > 0)
                            {
                                //Console.WriteLine("INSERTADO");
                                trnSql.Commit();
                            }
                            else
                            {
                                trnSql.Rollback();
                                C_Despacho.RBTraspDesp(_IdDespacho);
                            } 
                        }
                        else
                        {
                            trnSql.Rollback();
                            C_Despacho.RBTraspDesp(_IdDespacho);
                        } 
                    }
                    else
                    {
                        trnSql.Rollback();
                        trnSql.Dispose();
                        C_Despacho.RBTraspDesp(_IdDespacho);
                    } 
                }
                catch (Exception err)
                {
                    Console.WriteLine("################# = " + err.ToString());
                    a = 0;
                    trnSql.Rollback();
                    trnSql.Dispose();
                    C_Despacho.RBTraspDesp(_IdDespacho);
                }
                return a;
            }
        }
        public int InsertarTraspaso(out int iNroDoc, CTraspaso _traspaso, DataTable dt, string Movimiento)
        {
            int a = 0;
            //sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                int sccodfin = Convert.ToInt32(_traspaso.p_sctttdoc);
                iNroDoc = ObtenerNumeroDocumento(sccodfin, trnSql);
                try
                {
                    this.p_scttndoc = iNroDoc;
                    a = this.InserTraspaso(trnSql);
                    if (a > 0)
                    {
                        a = ActualizarUltimoTraspaso(iNroDoc, sccodfin, trnSql);
                        if (a > 0)
                        {
                            //
                            a = ActualizarMovPdv(sccodfin, iNroDoc, Movimiento, trnSql);
                            if (a > 0)
                            {
                                for (int intPos = 0; intPos < dt.Rows.Count; ++intPos)
                                {
                                    int itemF = Convert.ToInt32(dt.Rows[intPos]["itemf"]);
                                    decimal Cantidad = Convert.ToDecimal(dt.Rows[intPos]["cantidad"]);
                                    scmovart _SCmovart = new scmovart();
                                    DataSet dtsMasterFT = ConsultarArticulo(itemF, trnSql);
                                    decimal scmappce = Convert.ToDecimal(dtsMasterFT.Tables[0].Rows[0]["scmappce"]);

                                    _SCmovart.p_scmvtdoc = Convert.ToDecimal(sccodfin);
                                    _SCmovart.p_scmvndoc = Convert.ToDecimal(iNroDoc);
                                    _SCmovart.p_scmvnart = Convert.ToDecimal(itemF);
                                    _SCmovart.p_scmvctra = Convert.ToDecimal(10004);//Convert.ToDecimal(dt.Rows[intPos][3]);
                                    _SCmovart.p_scmvfdoc = DateTime.Now;
                                    _SCmovart.p_scmvfreg = DateTime.Now;
                                    _SCmovart.p_scmvcsuc = Convert.ToDecimal(dt.Rows[intPos]["sucursalid"]);
                                    //_SCmovart.p_scmvcorr = Convert.ToInt32(dt.Rows[intPos][7]);
                                    _SCmovart.p_scmvcmov = Convert.ToDecimal(7001);
                                    _SCmovart.p_scmvcant = Cantidad;
                                    _SCmovart.p_scmvicme = Cantidad * scmappce;
                                    _SCmovart.p_scmvpumo = scmappce;
                                    _SCmovart.p_scmvicmo = 0;
                                    _SCmovart.p_scmvpvus = 0;
                                    _SCmovart.p_scmvivus = 0;
                                    _SCmovart.p_scmvpvmn = 0;
                                    _SCmovart.p_scmvivmn = 0;
                                    _SCmovart.p_scmvsssu = 0;
                                    _SCmovart.p_scmvisco = 0;
                                    _SCmovart.p_scmvssco = 0;
                                    a = InsertarMovArt(_SCmovart, trnSql);
                                    if (a > 0)
                                    {
                                        DataSet dataSet1 = ConsultarArticuloxSucursal(Convert.ToInt32(_traspaso.scttsucr), itemF, trnSql);
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
                                            _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.scttsucr);
                                            _SCartsuc.p_scasnart = itemF;
                                            _SCartsuc.p_scasabc1 = dataSet1.Tables[0].Rows[0]["scasabc1"].ToString();
                                            _SCartsuc.p_scasabc2 = dataSet1.Tables[0].Rows[0]["scasabc2"].ToString();
                                            _SCartsuc.p_scasabc3 = dataSet1.Tables[0].Rows[0]["scasabc3"].ToString();
                                            _SCartsuc.p_scasabc4 = dataSet1.Tables[0].Rows[0]["scasabc4"].ToString();
                                            _SCartsuc.p_scasstto = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstto"]) + Cantidad;
                                            _SCartsuc.p_scasstdi = Convert.ToDecimal(dataSet1.Tables[0].Rows[0]["scasstdi"]) + Cantidad;
                                            _SCartsuc.p_scasstco = dAssTco;
                                            _SCartsuc.p_scasccin = dAscCin;
                                            _SCartsuc.p_scasubic = dUbicacion;
                                            //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                            _SCartsuc.p_scastmax = dAstMin;
                                            _SCartsuc.p_scastmax = dAstMax;
                                            a = ModificarArtSuc(_SCartsuc, trnSql);
                                            if (a == 0)
                                                break;
                                        }
                                        else
                                        {
                                            _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.p_scttsucr);
                                            _SCartsuc.p_scasnart = itemF;
                                            _SCartsuc.p_scasabc1 = "0";
                                            _SCartsuc.p_scasabc2 = "0";
                                            _SCartsuc.p_scasabc3 = "0";
                                            _SCartsuc.p_scasabc4 = "0";
                                            _SCartsuc.p_scasstto = Cantidad;
                                            _SCartsuc.p_scasstdi = Cantidad;
                                            _SCartsuc.p_scasstco = 0;
                                            _SCartsuc.p_scasccin = 0;
                                            _SCartsuc.p_scasubic = 0;
                                            //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                            _SCartsuc.p_scastmax = 0;
                                            _SCartsuc.p_scastmax = 0;
                                            a = InsertarArtSuc(_SCartsuc, trnSql);
                                            if (a == 0)
                                                break;
                                        }
                                    }
                                    else
                                        break;
                                    if (a > 0)
                                    {
                                        _SCmovart.p_scmvcsuc = Convert.ToDecimal(_traspaso.scttsuce);
                                        _SCmovart.p_scmvctra = Convert.ToDecimal(11006);
                                        _SCmovart.p_scmvcmov = Convert.ToDecimal(7002);
                                        a = InsertarMovArt(_SCmovart, trnSql);
                                        if (a > 0)
                                        {
                                            DataSet dtsARTSUC1 = ConsultarArticuloxSucursal(Convert.ToInt32(_traspaso.scttsuce), itemF, trnSql);
                                            if (dtsARTSUC1.Tables[0].Rows.Count > 0)
                                            {
                                                Decimal dAssTco = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasstco"].ToString()))
                                                    dAssTco = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstco"].ToString());
                                                Decimal dAscCin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasccin"].ToString()))
                                                    dAscCin = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasccin"].ToString());
                                                Decimal dUbicacion = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scasubic"].ToString()))
                                                    dUbicacion = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasubic"].ToString());
                                                Decimal dAstMin = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scastmin"].ToString()))
                                                    dAstMin = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scastmin"].ToString());
                                                Decimal dAstMax = new Decimal(0);
                                                if (!string.IsNullOrEmpty(dtsARTSUC1.Tables[0].Rows[0]["scastmax"].ToString()))
                                                    dAstMax = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scastmax"].ToString());
                                                if (Cantidad <= Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstto"]))
                                                {
                                                    scartsuc _SCartsuc = new scartsuc();
                                                    _SCartsuc.p_scasnsuc = Convert.ToInt32(_traspaso.scttsuce);
                                                    _SCartsuc.p_scasnart = itemF;
                                                    _SCartsuc.p_scasabc1 = dtsARTSUC1.Tables[0].Rows[0]["scasabc1"].ToString();
                                                    _SCartsuc.p_scasabc2 = dtsARTSUC1.Tables[0].Rows[0]["scasabc2"].ToString();
                                                    _SCartsuc.p_scasabc3 = dtsARTSUC1.Tables[0].Rows[0]["scasabc3"].ToString();
                                                    _SCartsuc.p_scasabc4 = dtsARTSUC1.Tables[0].Rows[0]["scasabc4"].ToString();
                                                    _SCartsuc.p_scasstto = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstto"]) - Cantidad;
                                                    _SCartsuc.p_scasstdi = Convert.ToDecimal(dtsARTSUC1.Tables[0].Rows[0]["scasstdi"]) - Cantidad;
                                                    _SCartsuc.p_scasstco = dAssTco;
                                                    _SCartsuc.p_scasccin = dAscCin;
                                                    _SCartsuc.p_scasubic = dUbicacion;
                                                    //_SCartsuc.p_scasfuls = Convert.ToDateTime(dt.Rows[intPos][5]);
                                                    _SCartsuc.p_scastmax = dAstMin;
                                                    _SCartsuc.p_scastmax = dAstMax;
                                                    a = ModificarArtSuc(_SCartsuc, trnSql);
                                                    if (a == 0)
                                                    {
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    a = 0;
                                                    iNroDoc = -1;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                a = 0;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            if (a > 0)
                                trnSql.Commit();
                            else
                                trnSql.Rollback();
                        }
                        else
                            trnSql.Rollback();
                    }
                    else
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