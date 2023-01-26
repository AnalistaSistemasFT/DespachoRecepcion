using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADAlmacen : DBDAC
    {
        public CADAlmacen() : base("SQLSERVER", "dbo.tblAlmacen")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Camion";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Camion=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public DataSet TraerAlmacen(int Sucursal)
        {
            string Consulta = @" select * from tblAlmacen where SucursalId = {0}";
            Consulta = string.Format(Consulta, Sucursal);
            return EjecutarConsulta(Consulta);
        }
        public DataSet TraerAlmacenDetalleItem(int Sucursal, int Almacen)
        {
            string Consulta = @"select tblCeldas.ItemId, tblitem.Descripcion, (tblItem.CapVertical* tblItem.Caphorizontal) as paqXcelda, count(*) as celdaUtil,(tblItem.CapVertical* tblItem.Caphorizontal* COUNT(*)) as capinst,
                                 SUM(tblceldas.unidades) as caputil, (tblItem.CapVertical* tblItem.Caphorizontal* COUNT(*)*tblitem.pesopaq) as capinstkg,(SUM(tblceldas.unidades)* tblItem.PesoPaq) as caputilkg
                                    from tblCeldas, tblItem
                                    where tblCeldas.ItemId=tblitem.itemid and tblCeldas.sucursalid={0} and tblCeldas.AlmacenId= {1}
                                  group by tblCeldas.ItemId, tblitem.descripcion, tblItem.CapHorizontal, tblItem.CapVertical, tblItem.PesoPaq";
            Consulta = string.Format(Consulta, Sucursal, Almacen);
            return EjecutarConsulta(Consulta);
        }
        public DataSet TraerAlmacenDetalleXItem(string Item)
        {
            string Consulta = @" select PaqueteId, CeldaId, Fecha, FechaVenc, Piezas, Peso, CantOriginal from tblPaquetes where ItemId = '09782' and Status = 'ACTIVO'";
            Consulta = string.Format(Consulta, Item);
            return EjecutarConsulta(Consulta);
        }
    }
}
