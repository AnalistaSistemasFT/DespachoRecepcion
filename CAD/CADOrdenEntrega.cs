using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADOrdenEntrega : DBDAC
    {
        
        public CADOrdenEntrega() : base("SQLSERVER", "dbo.tblOrdenEntrega")
        {

        }
        public DataSet TraerOrdenesEntregas()
        {
            string cadena = "select * from tblOrdenEntrega";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenEntrega(string Estado)
        {
            string cadena = "select * from tblOrdenEntrega where Estado = '" + Estado + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenEntregaList(string Estado, int _idSucursal)
        {
            string cadena = "select DespachoId, Fecha_salida as Fechas, Chofer, Placa, Cantidad_total as Cantidad, Peso_total as Peso, Login from tblOrdenEntrega where Origen_id = " + _idSucursal + " AND Estado = '" + Estado + "' order by Fecha_salida desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenDetalleDespacho(string IdDespacho)
        {
            string cadena = "select * from tblOrdenEntregaDetalle where DespachoId = '" + IdDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerIdInsertado(string _despachoId)
        {
            string cadena = "select Id_orden_entrega from tblOrdenEntrega order by Id_orden_entrega";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet dts1()
        {
            //string cadena = "select DespachoId, d.ItemId,i.Descripcion,sum(d.Cantidad) as Cantidad,0 as SolPiezasSueltas,0 as ConfPiezasSueltas,0 as CantConfirmada ,i.UnidadCalculo as Unidad,''as Status, d.Peso from tblOrdenEntregaDetalle d inner join tblItem i on d.ItemId = i.ItemId where id_orden_entrega = 205 group by d.DespachoId, d.ItemId, i.Descripcion,UnidadCalculo, d.Peso";
            string cadena = "select * from tblMovSyncDet where ordenid = '8D23001834'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet dts2()
        {
            string cadena = "select * from tblMovSyncDet where ordenid = '8D23001833'"; 
            return this.EjecutarConsulta(cadena);
        }
        public int DataUpdate()
        {
            string consulta = "";
            //"UPDATE tblPaquetes SET CeldaId = 'AL5:1B-4S2' WHERE SucursalId = 12080 and AlmacenId = 5 and CeldaId = 'AL1:4C-11S2';" +
            //"UPDATE tblPaquetes SET CeldaId = 'AL5:1B-4S2' WHERE SucursalId = 12080 and AlmacenId = 5 and CeldaId = 'AL1:1C-12S2';" +
            //"UPDATE tblPaquetes SET CeldaId = 'AL5:1B-4S2' WHERE SucursalId = 12080 and AlmacenId = 5 and CeldaId = 'AL5:1B-2S3';" +
            //"UPDATE tblPaquetes SET CeldaId = 'AL5:1B-4S2' WHERE SucursalId = 12080 and AlmacenId = 5 and CeldaId = 'AL5:1A-2S3';" +
            //"UPDATE tblPaquetes SET CeldaId = 'AL5:1B-4S2' WHERE SucursalId = 12080 and AlmacenId = 5 and CeldaId = 'AL1:1B-15S1';";
            //"INSERT INTO tblCeldas (SucursalId, CeldaId, AlmacenId, Area, Segmento, Fila, Nave, Columna, ItemId, Unidades, Kgs, Status, Proceso, PreAsignado, CeldaTemp) VALUES(12080, 'AL5:1B-4S2', 5, 4, 'S2', 'GEN-B', 1, 'B', 'GEN-B', 0, 0, 1, 'Llenado', 1, '')";

            //"UPDATE tblPaquetes set ";
            //"DELETE FROM tblDespProductos WHERE ProductoId = '2212L10224' and DespachoId = '5D23000009';" +
            //"UPDATE tblPaquetes SET Status = 'ACTIVO' WHERE PaqueteId = '2212L10224' and SucursalId = 12080;";
            //"UPDATE tblDespProductos SET Cantidad = 1, Piezas = 1 WHERE DespachoId = '1D22001788';";
            //    "
            // +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 3 WHERE EstanteId = '7' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 3 WHERE EstanteId = '8'" +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 3 WHERE EstanteId = '9'" +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 4 WHERE EstanteId = '10' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 4 WHERE EstanteId = '11' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 4 WHERE EstanteId = '12' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 5 WHERE EstanteId = '13' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 5 WHERE EstanteId = '14' " +
            //"UPDATE tblCeldasEstante SET Rack = 1, Piso = 5 WHERE EstanteId = '15' ";

            //string consulta = "delete from tblRecepcionProductos Where ProductoId = '2212V30123'";
            //string consulta = "UPDATE tblDespacho SET Status = 'CLOSE' WHERE DespachoId = '1D22001845'";
            //string consulta = "CREATE TABLE tblEstantes( " +
            //                "SucursalId int NOT NULL, " +
            //                "EstanteId varchar(10) NOT NULL, " +
            //                "Filas int NOT NULL, " +
            //                "Columnas int NOT NULL, " +
            //                "CeldaId varchar (20) NOT NULL, " +
            //                "PRIMARY KEY (SucursalId, EstanteId)) ";
            return EjecutarComando(consulta);
        }
    }
}
