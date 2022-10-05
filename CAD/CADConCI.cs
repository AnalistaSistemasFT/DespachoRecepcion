using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADConCI : oledb
    {


        public CADConCI()
        {
            this.sConnName = "FTODO";
        }

        public DataSet TraerTodosCC(string estado, int sucursal)
        {
            string consulta = @"SELECT * FROM tblccargaint WHERE sestado = '{0}'";
            consulta = string.Format(consulta, estado);
            return this.consultar(consulta);
        }

        public DataSet TraerTodosDetalleCC( int iCC)
        {
            string consulta = @" select iccargadet_id, iitem_id, scmadesc, iccarga_id, scolada, spackinglist, dpeso, dPesoNeto, ifabricante_id, scmpnomb, cd.sfacturacomercial
                           from tblccargaintdet cd left outer join
                            INFORMIX.siscome.sistemas.scmaster on iitem_id = scmanart left outer join
                           INFORMIX.siscome.sistemas.scmaepro on cd.ifabricante_id = scmpcpro
       
                           where iccarga_id = {0}
        group by  iccargadet_id,iitem_id,scmadesc,iccarga_id,scolada ,spackinglist,dpeso,dPesoNeto,ifabricante_id,scmpnomb,cd.sfacturacomercial";
            consulta = string.Format(consulta, iCC);
            return this.consultar(consulta);
        }
       

        public DataSet TraerListaPaclinklist()
        {
            string sSelect = @"select  p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,m.scmadesc,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,(dPesoNeto - dPesocc) as dPesocc
                                            from tblpackinglist p inner join
                                            [INFORMIX].[siscome].[sistemas].[scmaster] m on p.iItem_id = m.scmanart
                                            group by p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,dPesocc,
                                            m.scmadesc";
            return this.consultar(sSelect);
        }
        public DataSet TraerListaPaclinklistxSerie(string sPacking)
        {
            string sSelect = @"select* from tblPackingList where sSerie  = '{0}'";
            sSelect = string.Format(sSelect, sPacking);
            return this.consultar(sSelect);
        }
        
        

    }
}
