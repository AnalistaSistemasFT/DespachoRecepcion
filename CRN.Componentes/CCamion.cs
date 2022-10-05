using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CCamion : oledb
    {
        public CCamion()
        {
            this.sConnName = "SQLSERVER";
        }

        public DataSet SeleccionarCamion()
        {
            
            string sInsert = @"select Id_Camion, Placa, Marca from tblCatCamion order by Placa asc";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }

        public DataSet SeleccionarCamionId(int icamion)
        {

            string sInsert = @"select Id_Camion, Placa, Marca from tblCatCamion where Id_Camion="+icamion;
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }

        public DataSet TraerFabricantes()
        {

            string sInsert = @"select Nombre Nombre,Nombre Fabricante from tblCatProveedor order by Nombre asc ";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet TraerCeldas(int ialmacen)
        {

            string sInsert = @"SELECT  tblceldas.celdaid CeldaId,tblceldas.celdaid FROM tblCeldas WHERE AlmacenId = " + ialmacen;
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }

    }
}
