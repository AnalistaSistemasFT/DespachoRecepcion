using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADTraspaso : oledb
    {
        public CADTraspaso()
        {
            this.sConnName = "FTINF";
        }
        public int GuardarTraspaso(ref string sError, scttrasp _Traspaso)
        {
            string sInsert = "INSERT into scttrasp (sctttdoc, scttndoc, sctiptra, scttfdoc, scttfreg, scttsuce, scttsucr, scttdesc " +
                             "values ({1},{2},'{3}','{4}','{5}','{6}','{7}','{8}')";
            sInsert = string.Format(sInsert, _Traspaso.p_sctttdoc, _Traspaso.p_scttndoc, _Traspaso.p_sctiptra, _Traspaso.p_scttfdoc,
                _Traspaso.p_scttfreg, _Traspaso.p_scttsuce, _Traspaso.p_scttsucr, _Traspaso.p_scttdesc);
            sInsert = sInsert.Replace("''", "null");
            return this.ejecutar(ref sError, sInsert);
        }
        public int ModificarTraspaso(ref string sError, int sucursal, int correlativo)
        {
            string sUpdate = "UPDATE sctabcon SET sctcvalo = {0} WHERE sccodfin = {1}";
            sUpdate = string.Format(sUpdate, correlativo, sucursal);
            return this.ejecutar(ref sError, sUpdate);
        }
        public DataSet TraerTipoDoc(int _IdSucursal)
        {
            //string consulta = "select itipodoc, inrodoc from tbltipofact where isucursal_id = " + _IdSucursal;
            string consulta = "select t.itipodoct, c.sctcdesc from tbltipofact t inner join sctabcon c on t.itipodoct = c.sccodfin where t.isucursal_id = " + _IdSucursal;
            return this.consultar(consulta);
        }
        public DataSet TraerTransitos()
        {
            string consulta = "SELECT sccodfin, sctcdesc FROM sctabcon WHERE sctcgrup = 12 AND sctcdesc LIKE'%TRN%'";
            return this.consultar(consulta);
        }
        public DataSet TraerCorrelativo(string tipoDodId)
        {
            string consulta = "select sctcvalo + 1 from sctabcon where sccodfin = " + tipoDodId.Trim();
            return this.consultar(consulta);
        }

        public DataSet TraerCosto(string _IdProd)
        {
            string consulta = "select scmappce from scmaster where scmanart = '" + _IdProd + "'";
            return this.consultar(consulta);
        }
    }
}
