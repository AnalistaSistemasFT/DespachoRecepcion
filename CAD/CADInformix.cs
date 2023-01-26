using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADInformix : oledb
    {
        public CADInformix()
        {
            this.sConnName = "FTINF";
        }
        public DataSet TraerTodosClientes()
        {
            string consulta = "select scclccli, scclnomb from scmaecli";
            return this.consultar(consulta);
        }
        public DataSet TraerDescProducto()
        {
            string consulta = "select scmanart, scmadesc from scmaster";
            return this.consultar(consulta);
        }
        public DataSet TraerEntregas(decimal _idSucursal)
        {
            //string consulta = "SELECT * FROM scentrega WHERE scsucori = " + _idSucursal;
            string consulta = "SELECT a.scnroent as CodigoEntrega, b.sctftdoc as TipoDoc, b.sctfndoc as Nro_venta, b.scnrodoc as Nro_Documento, " +
                "a.scfecent as Fecha, a.scsucori as SucursalOrigen, b.sctfccli as CodigoCliente, " +
                "b.sctfnomb as NombreCliente, b.sctfcven as CodigoVendedor, b.sctffopa as FormaPago, b.sctffdoc as FechaV " +
                "FROM scentrega a INNER JOIN sctfactu b ON a.sctipdoc = b.sctftdoc AND a.scnrodoc = b.sctfndoc";
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleEntregas(decimal _tipoDoc, decimal _nroDoc)
        {
            string consulta = "SELECT * FROM scdetent WHERE scmvtdoc = " + _tipoDoc + " AND scmvndoc = " + _nroDoc;
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleEntSuc(decimal iSucursal, decimal sTipoDoc, decimal sTipoDoc1)
        {
            //string consulta = "SELECT a.scmvnart, b.scmadesc, a.scmvcant, c.scasstto, c.scasstdi " +
            //    "FROM scdetent a INNER JOIN scmaster b ON a.scmvnart = b.scmanart " +
            //    "INNER JOIN scartsuc c ON a.scmvnart = c.scasnart " +
            //    "WHERE a.scmvcsuc = " + _idSucursal;

            //detalle

            //string consulta = "SELECT a.scmvnart, b.scmadesc, a.scmvcant " +
            //   "FROM scdetent a INNER JOIN scmaster b ON a.scmvnart = b.scmanart " +
            //   "WHERE a.scmvcsuc = " + _idSucursal;
            //string consulta = "SELECT a.sctipdoc as Codigo, a.scnrodoc as NroDocumento, b.scnrodoc as Nro_Documento, a.scfecent as Fecha, a.scsucori as SucursalOrigen, b.sctfccli as CodigoCliente, b.sctfnomb as NombreCliente, b.sctfcven as CodigoVendedor " +
            //    "FROM scentrega a INNER JOIN sctfactu b ON a.sctipdoc = b.sctftdoc AND a.scnrodoc = b.sctfndoc WHERE scsucori = " + _idSucursal;
            string consulta = "Select scentrega.scnroent,scentrega.sctipdoc,scentrega.scnrodoc,scfecent,sctfccli,sctfcsuc,scclnomb,TRIM(scdirec1)||' '||TRIM(NVL(scdirec2,'')) as scdirec1, sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso)peso_total,scvdnomb, (select sctcdesc from sctabcon where sccodfin=sctffopa)sctffopa, (select sclatitu from sccliegeo where sccodcli=sctfccli)sclatitu, (select sclongit from sccliegeo where sccodcli=sctfccli)sclongit from scentrega,sctfactu,scmaecli,scmaeven,scregsuc,scmovart Left outer join (select scnroent,sctipdoc,scnrodoc,movorcaart,sum(movorcacan) as movorcacan from scentrega left outer  join scmovorca on movorcaent=scnroent and scanulad=1 and movorcaest=1 group by 1,2,3,4)mc on scmvtdoc = mc.sctipdoc and scmvndoc = mc.scnrodoc and scmvnart = movorcaart,scmaster  where scentrega.sctipdoc=sctfactu.sctftdoc and scentrega.scnrodoc=sctfactu.sctfndoc and sctfccli=scclccli and sctfcven=scvdcven and sctftdoc=scmvtdoc and sctfndoc=scmvndoc and scmvnart=scmanart and scregsuc.sccodsuc =  " + (object)iSucursal + "  and sctfcsuc = sccodsuc and scentrega.sctipdoc in (" + sTipoDoc1 + ") and scanulad=1 and  (scnrotra=0 or scnrotra is null) and exists (select * from sccjafis cf where cf.sctipnot = scentrega.sctipdoc and cf.scnronot = scentrega.scnrodoc) group by 1,2,3,4,5,6,7,8,scvdnomb,sctffopa having  sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso) > 0 " + 
                              "union " +
                              "Select scentrega.scnroent,scentrega.sctipdoc,scentrega.scnrodoc,scfecent,sctfccli,sctfcsuc,scclnomb,TRIM(scdirec1) || ' ' || TRIM(NVL(scdirec2, '')) as scdirec1, sum((scmvcant - NVL(mc.movorcacan, 0)) * scmapeso)peso_total,scvdnomb, (select sctcdesc from sctabcon where sccodfin = sctffopa)sctffopa, (select sclatitu from sccliegeo where sccodcli = sctfccli)sclatitu, (select sclongit from sccliegeo where sccodcli = sctfccli)sclongit from scentrega,sctfactu,scmaecli,scmaeven,scregsuc,scmovart Left outer join(select scnroent, sctipdoc, scnrodoc, movorcaart, sum(movorcacan) as movorcacan from scentrega left outer join scmovorca on movorcaent = scnroent and scanulad = 1 and movorcaest = 1 group by 1,2,3,4)mc on scmvtdoc = mc.sctipdoc and scmvndoc = mc.scnrodoc and scmvnart = movorcaart, scmaster where scentrega.sctipdoc = sctfactu.sctftdoc and scentrega.scnrodoc = sctfactu.sctfndoc and sctfccli = scclccli and sctfcven = scvdcven and sctftdoc = scmvtdoc and sctfndoc = scmvndoc and scmvnart = scmanart and scregsuc.sccodsuc = " + (object)iSucursal + "  and sctfcsuc = sccodsuc and scentrega.sctipdoc in (" + sTipoDoc + ") and scanulad = 1 and(scnrotra = 0 or scnrotra is null) and exists(SELECT* FROM scmaeiva cf WHERE scentrega.sctipdoc = cf.scmitdoc AND scentrega.scnrodoc = cf.scmindoc) group by 1,2,3,4,5,6,7,8,scvdnomb,sctffopa having sum((scmvcant - NVL(mc.movorcacan, 0)) * scmapeso) > 0";
            return this.consultar(consulta);
        }
        public DataSet TraerTodasOrdenes()
        {
            //string consulta = "select a.sctfsuc, a.sctftdoc, a.sctfccli from sctfactu a inner join scmovart b on a.sctftdoc = b.scmvtdoc and a.sctfndoc = b.scmvndoc";
            //string consulta = "select a.sctfndoc as NroOrden from sctfactu a inner join scmovart b on a.sctftdoc = b.scmvtdoc and a.sctfndoc = b.scmvndoc " +
            //string consulta = "SELECT a.scnroent as CodigoEntrega, b.sctftdoc as TipoDoc, b.sctfndoc as OV, b.scnrodoc as Nro_Documento, " +
            //    "a.scfecent as Fecha, a.scsucori as SucursalOrigen, b.sctfccli as CodigoCliente, " +
            //    "b.sctfnomb as NombreCliente, b.sctfcven as CodigoVendedor, b.sctffopa as FormaPago, b.sctffdoc as FechaV " +
            //    "FROM scentrega a INNER JOIN sctfactu b ON a.sctipdoc = b.sctftdoc AND a.scnrodoc = b.sctfndoc where b.sctfndoc = " + 69919;
            //"where a.sctfndoc = 550";
            string consulta = "select COUNT(sctfcsuc) as total from sctfactu where sctfcsuc = 12108";
            //string consulta = "select sctfccli as CodigoCliente, sctfnomb as NombreCliente, sctfndoc as OV, sctfibmn as Monto, sctfcsuc as Sucursal, sctfcven as Vendedor, sctffdoc as FechaEntrega, sctffdoc as FechaRecepcion from sctfactu where sctfndoc = 69919";
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleOV()
        {
            //string consulta = "select * from scdetent where scmvndoc = 69919";
            //string consulta = "select a.scmanart, a.scmadesc, b.sctcdesc, c.scmvcant from scmaster a INNER JOIN sctabcon b ON a.scmaumed = b.sccodfin " +
            //    "INNER JOIN scmovart c ON c.scmvnart = a.scmanart " +
            //    "WHERE c.scmvndoc = 69919";
            string consulta = "select itipodoct from tbltipofact where isucursal_id = 12108";
            return this.consultar(consulta);
        }

        public DataSet TraerMovPdv(string Estado, int Sucursal)
        {
            string consulta = "SELECT * FROM tblmovpdv WHERE STATUS = '{0}' and sucursalid = {1} order by fecha desc";
            consulta = string.Format(consulta, Estado, Sucursal);
            return this.consultar(consulta);
        }

        public DataSet TraerMovDetPdv(string Movimiento)
        {
            string consulta = "select * from tblmovdetpdv where movimientoid = '{0}'";
            consulta = string.Format(consulta, Movimiento);
            return this.consultar(consulta);
        }
        public DataSet TraerCorrelativoCierre(int _idSucursal)
        {
            string sSelect = "select sctindoc + 1 from scentreg where scticsuc = " + _idSucursal;
            return this.consultar(sSelect);
        }
        public DataSet TraerTipoFactu(int _idSucursal)
        {
            string sSelect = "select itipodoct from tbltipofact where isucursal_id = " + _idSucursal;
            return this.consultar(sSelect);
        }
        public DataSet TraerScTipoDoc(int _idSucursal)
        {
            string sSelect = "select itipodoct from tbltipofact where isucursal_id = " + _idSucursal;
            return this.consultar(sSelect);
        }
        public DataSet TraerContadoCredito(int _idSucursal)
        {
            string sSelect = "select * from scentreg where scticsuc = 12081";
            //string sSelect = "select t.itipodoct, c.sctcdesc from tbltipofact t inner join sctabcon c on t.itipodoct = c.sccodfin where t.isucursal_id = 12004";
            return this.consultar(sSelect);
        }
        public DataSet TraerTipoDocEntrega(decimal _tipoFact)
        {
            //string sSelect = "select * from sctabcon";
            string sSelect = "select * from tbltipofact";
            return this.consultar(sSelect);
        }
        /////////////////////SCENTREGA_INFORMIX///////////////
        public int InsertarSCEntrega(scentreg_inf _scent, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            //            string sInsert = @"INSERT INTO [INFORMIX].[siscome].[sistemas].[scentreg] ([sctitdoc],[sctindoc],[sctictra],[sctifdoc],[sctifreg],[scticsuc],[sctidevo],[schraent],[sctipdoc],[scnrodoc]) VALUES ({0},{1},{2},'{3}','{4}',{5},'{6}','{7}',{8},{9})";
            string sInsert = @"INSERT INTO scentreg (sctitdoc,sctindoc,sctictra,sctifdoc,sctifreg,scticsuc,sctidevo,schraent,sctipdoc,scnrodoc) VALUES ({0},{1},{2},'{3}','{4}',{5},'{6}','{7}',{8},{9});";
            sInsert = string.Format(sInsert, _scent.p_sctitdoc, _scent.p_sctindoc, _scent.p_sctictra, _scent.p_sctifdoc.ToString("dd/MM/yyyy"), _scent.p_sctifreg.ToString("dd/MM/yyyy"), _scent.p_scticsuc, _scent.p_sctidevo, _scent.p_schraent, _scent.p_sctipdoc, _scent.p_scnrodoc);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        //public int EditData()
        //{
        //    string sError = string.Empty;
        //    string sUpdate = "UPDATE tblmovdetpdv SET cantidad = '' WHERE movimientoid = ''";
        //    return this.ejecutar(ref sError, sUpdate);
        //}

        public DataSet ConsultarItem(int Item)
        {
            //string sSelect = "select * from sctabcon";
            string sSelect = "select * from scmaster where scmanart = {0}";
            sSelect = string.Format(sSelect, Item);
            return this.consultar(sSelect);
        }

        public DataSet TraerOvPendientes(int iSucursal)
        {
            string consulta = @"select t.sctftdoc,t.sctfndoc,t.sctffreg,t.sctfccli,c.scclnomb NomCLiente,t.sctfnomb NomFactura,t.sctfcven,v.scvdnomb,(sum(m.scmvcant) - (cantidad)) as peso1
                                from sctfactu t inner join 
                                scmovart m on t.sctftdoc = m.scmvtdoc and t.sctfndoc = m.scmvndoc inner join 
                                scmaster a on m.scmvnart = a.scmanart left outer join
                                (select e.sctipdoc,e.scnrodoc, sum(d.scmvcant) cantidad from scentreg e inner join
                                scdetent d on e.sctitdoc = d.scmvtdoc and e.sctindoc = d.scmvndoc
                                group by e.sctipdoc,e.scnrodoc) de on t.sctftdoc = de.sctipdoc and t.sctfndoc = de.scnrodoc  inner join 
                                scmaeven v on t.sctfcven = v.scvdcven inner join 
                                scmaecli c on t.sctfccli = c.scclccli
                                where t.sctfcsuc = {0} and t.sctfstat = 14001
                                group by t.sctftdoc,t.sctfndoc,t.sctffreg,t.sctfccli,c.scclnomb,t.sctfnomb,t.sctfcven,v.scvdnomb,cantidad
                                having (sum(m.scmvcant) - (cantidad)) > 0";
            consulta = string.Format(consulta, iSucursal);
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleNota(int iTipo, int iNro)
        {
            string consulta = @"select m.scmvtdoc,m.scmvndoc,m.scmvnart,a.scmadesc,m.scmvcant,nvl(cantidad, 0) cantidad
                                 from scmovart m inner join
                                scmaster a on m.scmvnart = a.scmanart left outer join
                                (select e.sctipdoc, e.scnrodoc, d.scmvnart, nvl(sum(d.scmvcant), 0) cantidad
                                from scentreg e inner
                                join
                                scdetent d on e.sctitdoc = d.scmvtdoc and e.sctindoc = d.scmvndoc
                                where e.sctipdoc = {0} and e.scnrodoc = {1}
                                group by e.sctipdoc, e.scnrodoc, d.scmvnart) de on m.scmvtdoc = de.sctipdoc and m.scmvndoc = de.scnrodoc  and m.scmvnart = de.scmvnart
                                where m.scmvtdoc = {2} and m.scmvndoc = {3}
                                group by m.scmvtdoc,m.scmvndoc,m.scmvnart,a.scmadesc,m.scmvcant,cantidad";
            consulta = string.Format(consulta, iTipo, iNro, iTipo, iNro);
            return this.consultar(consulta);
        }

    }
}