using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADscentrega : oledb
    {
        public CADscentrega()
        {
            this.sConnName = "FTINF";
        }
        public DataSet TraerDetalleNotasEntrega(string idDespacho, int idSucursal)
        {
            string sTipoDoc = "9003";
            string sTipoDoc1 = "9003";
            idSucursal = 12004;
            string consulta = "Select scentrega.scnroent,scentrega.sctipdoc,scentrega.scnrodoc,scfecent,sctfccli,sctfcsuc,scclnomb,TRIM(scdirec1)||' '||TRIM(NVL(scdirec2,'')) as scdirec1, sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso)peso_total,scvdnomb, (select sctcdesc from sctabcon where sccodfin=sctffopa)sctffopa, (select sclatitu from sccliegeo where sccodcli=sctfccli)sclatitu, (select sclongit from sccliegeo where sccodcli=sctfccli)sclongit from scentrega,sctfactu,scmaecli,scmaeven,scregsuc,scmovart Left outer join (select scnroent,sctipdoc,scnrodoc,movorcaart,sum(movorcacan) as movorcacan from scentrega left outer join scmovorca on movorcaent=scnroent and scanulad=1 and movorcaest=1 group by 1,2,3,4)mc on scmvtdoc = mc.sctipdoc and scmvndoc = mc.scnrodoc and scmvnart = movorcaart,scmaster where scentrega.sctipdoc=sctfactu.sctftdoc and scentrega.scnrodoc=sctfactu.sctfndoc and sctfccli=scclccli and sctfcven=scvdcven and sctftdoc=scmvtdoc and sctfndoc=scmvndoc and scmvnart=scmanart and scregsuc.sccodsuc =  " + (object)idSucursal + "  and sctfcsuc = sccodsuc and scentrega.sctipdoc in (" + sTipoDoc1 + ") and scanulad=1 and (scnrotra=0 or scnrotra is null) and exists (select * from sccjafis cf where cf.sctipnot = scentrega.sctipdoc and cf.scnronot = scentrega.scnrodoc) group by 1,2,3,4,5,6,7,8,scvdnomb,sctffopa having  sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso) > 0 union Select scentrega.scnroent,scentrega.sctipdoc,scentrega.scnrodoc,scfecent,sctfccli,sctfcsuc,scclnomb,TRIM(scdirec1)||' '||TRIM(NVL(scdirec2,'')) as scdirec1, sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso)peso_total,scvdnomb, (select sctcdesc from sctabcon where sccodfin=sctffopa)sctffopa, (select sclatitu from sccliegeo where sccodcli=sctfccli)sclatitu, (select sclongit from sccliegeo where sccodcli=sctfccli)sclongit from scentrega,sctfactu,scmaecli,scmaeven,scregsuc,scmovart Left outer join (select scnroent,sctipdoc,scnrodoc,movorcaart,sum(movorcacan) as movorcacan from scentrega left outer join scmovorca on movorcaent=scnroent and scanulad=1 and movorcaest=1 group by 1,2,3,4)mc on scmvtdoc = mc.sctipdoc and scmvndoc = mc.scnrodoc and scmvnart = movorcaart,scmaster where scentrega.sctipdoc=sctfactu.sctftdoc and scentrega.scnrodoc=sctfactu.sctfndoc and sctfccli=scclccli and sctfcven=scvdcven and sctftdoc=scmvtdoc and sctfndoc=scmvndoc and scmvnart=scmanart and scregsuc.sccodsuc =  " + (object)idSucursal + "  and sctfcsuc = sccodsuc and scentrega.sctipdoc in (" + sTipoDoc + ") and scanulad=1 and  (scnrotra=0 or scnrotra is null) and exists (SELECT * FROM scmaeiva cf WHERE scentrega.sctipdoc = cf.scmitdoc AND scentrega.scnrodoc = cf.scmindoc) group by 1,2,3,4,5,6,7,8,scvdnomb,sctffopa  having sum((scmvcant-NVL(mc.movorcacan,0))*scmapeso) > 0";
            return this.consultar(consulta);
        }
    }
}
