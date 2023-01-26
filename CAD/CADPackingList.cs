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
            string sSelect = @"select  p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,m.scmadesc,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,(dPesoNeto - dPesocc) as dPesocc,d.CodPackList,icantidad,p.sLote, p.dtFechaFabricacion 
                                from tblpackinglist p inner join
                                [INFORMIX].[siscome].[sistemas].[scmaster] m on p.iItem_id = m.scmanart left join
                                [192.168.0.200].[LYBK].[dbo].tblanotaciondet d on p.sSerie = d.CodPackList
                                group by p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,dPesocc,
                                m.scmadesc,d.CodPackList,icantidad,p.sLote, p.dtFechaFabricacion 
                                having  d.CodPackList is null or d.CodPackList = '0'";
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

        public DataSet TraerItemSucursal(int Sucursal)
        {
            string sSelect = @"select i.ItemId,i.ItemFId,i.Descripcion,i.Calidad,i.UnidadF,i.UnidadF,i.Caducidad,s.Stock StockPry,a.scasstto StcokAzul,s.TotalEntradas,s.TotalSalidas
                             from  [WIN-SERVER3].[LYBK].[dbo].[tblItem] i inner join 
	                            [WIN-SERVER3].[LYBK].[dbo].[tblSucItem] s on i.ItemId = s.ItemId inner join
	                            [INFORMIX].[siscome].[sistemas].[scartsuc] a on i.ItemFId = cast(a.scasnart as nvarchar(7)) and s.SucursalId = a.scasnsuc
	                            where s.SucursalId = {0}";
            sSelect = string.Format(sSelect, Sucursal);
            return this.consultar(sSelect);
        }
    }
}
