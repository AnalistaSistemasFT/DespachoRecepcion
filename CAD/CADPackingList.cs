using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADPackingList : oledb
    {


        public CADPackingList()
        {
            this.sConnName = "FTODO";
        }

        public DataSet TraerTodosCC(string estado, int sucursal)
        {
            string consulta = @"SELECT * FROM tblccargaint WHERE sestado = '{0}'";
            consulta = string.Format(consulta, estado);
            return this.consultar(consulta);
        }


        public DataSet TraerListaPaclinklist()
        {
            string sSelect = @"select  p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,m.scmadesc,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,(dPesoNeto - dPesocc) as dPesocc,d.CodPackList
                                from tblpackinglist p inner join
                                [INFORMIX].[siscome].[sistemas].[scmaster] m on p.iItem_id = m.scmanart left join
                                [192.168.0.200].[LYBK].[dbo].tblanotaciondet d on p.sSerie = d.CodPackList
                                group by p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,dPesocc,
                                m.scmadesc,d.CodPackList
                                having  d.CodPackList is null";
            return this.consultar(sSelect);
        }
        public DataSet TraerListaPaclinklistxSerie(string sPacking)
        {
            string sSelect = @"select* from tblPackingList where sSerie  = '{0}'";
            sSelect = string.Format(sSelect, sPacking);
            return this.consultar(sSelect);
        }
        public DataSet traerAnotacionPaquete(string sPacking)
        {
            string sSelect = @"select  * from [192.168.0.200].[LYBK].[dbo].tblanotaciondet d where CodigoBarra = '{0}'";
            sSelect = string.Format(sSelect, sPacking);
            return this.consultar(sSelect);
        }



    }
}
