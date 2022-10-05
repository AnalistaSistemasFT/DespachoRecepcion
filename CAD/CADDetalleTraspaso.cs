using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADDetalleTraspaso : oledb
    {
        public CADDetalleTraspaso()
        {
            this.sConnName = "FTINF";
        }
        public int GuardarDetalleTraspaso(ref string sError, scmovart _DetalleTraspaso)
        {
            string sInsert = "INSERT into scmovart (scmvtdoc, scmvndoc, scmvnart, scmvctra, scmvfdoc, scmvfreg, scmvcsuc, scmvcorr, scmvcmov, scmvcant, scmvicme, scmvpumo, scmvicmo, scmvpvus, scmvivus, scmvpvmn, scmvivmn, scmvsssu, scmvisco, scmvssco" +
                             "values ({1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},'{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')";
            sInsert = string.Format(sInsert, _DetalleTraspaso.p_scmvtdoc, _DetalleTraspaso.p_scmvndoc, _DetalleTraspaso.p_scmvnart, _DetalleTraspaso.p_scmvctra,
                _DetalleTraspaso.p_scmvfdoc, _DetalleTraspaso.p_scmvfreg, _DetalleTraspaso.p_scmvcsuc, _DetalleTraspaso.p_scmvcorr, _DetalleTraspaso.p_scmvcmov,
                _DetalleTraspaso.p_scmvcant, _DetalleTraspaso.p_scmvicme, _DetalleTraspaso.p_scmvpumo, _DetalleTraspaso.p_scmvicmo, _DetalleTraspaso.p_scmvpvus,
                _DetalleTraspaso.p_scmvivus, _DetalleTraspaso.p_scmvpvmn, _DetalleTraspaso.p_scmvivmn, _DetalleTraspaso.p_scmvsssu, _DetalleTraspaso.p_scmvisco,
                _DetalleTraspaso.p_scmvssco);
            sInsert = sInsert.Replace("''", "null");
            return this.ejecutar(ref sError, sInsert);
        }
    }
}
