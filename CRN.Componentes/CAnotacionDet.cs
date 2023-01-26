using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
namespace CRN.Componentes
{
    public class  CAnotacionDet : oledb
    {
        private string CodigoBarra;
        private string AnotacionId;
        private string Fabricante;
        private string ItemId;
        private int Piezas;
        private decimal Peso;
        private string Colada;
        private int SucursalId;
        private int AlmacenId;
        private string CeldaId;
        private DateTime Fecha;
        private int Correlativo;
        private string Login;
        private string Status;
        private string CodPackList;
        private decimal PesoNetoProveedor;
        private decimal PesoBrutoProveedor;
        private bool EsDeCliente;
        private bool Sincronizado;
        private DateTime FechaCaducidad;
        private string sLote;

        public string CodigoBarra1 { get => CodigoBarra; set => CodigoBarra = value; }
        public string AnotacionId1 { get => AnotacionId; set => AnotacionId = value; }
        public string Fabricante1 { get => Fabricante; set => Fabricante = value; }
        public string ItemId1 { get => ItemId; set => ItemId = value; }
        public int Piezas1 { get => Piezas; set => Piezas = value; }
        public decimal Peso1 { get => Peso; set => Peso = value; }
        public string Colada1 { get => Colada; set => Colada = value; }
        public int SucursalId1 { get => SucursalId; set => SucursalId = value; }
        public int AlmacenId1 { get => AlmacenId; set => AlmacenId = value; }
        public string CeldaId1 { get => CeldaId; set => CeldaId = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public int Correlativo1 { get => Correlativo; set => Correlativo = value; }
        public string Login1 { get => Login; set => Login = value; }
        public string Status1 { get => Status; set => Status = value; }
        public string CodPackList1 { get => CodPackList; set => CodPackList = value; }
        public decimal PesoNetoProveedor1 { get => PesoNetoProveedor; set => PesoNetoProveedor = value; }
        public decimal PesoBrutoProveedor1 { get => PesoBrutoProveedor; set => PesoBrutoProveedor = value; }
        public bool EsDeCliente1 { get => EsDeCliente; set => EsDeCliente = value; }
        public bool Sincronizado1 { get => Sincronizado; set => Sincronizado = value; }
        public DateTime FechaCaducidad1 { get => FechaCaducidad; set => FechaCaducidad = value; }
        public string Lote1 { get => sLote; set => sLote = value; }
        public CAnotacionDet()
        {
            this.sConnName = "SQLSERVER";
        }

        public int InsertAnotacionDet(out string sError,DbTransaction trnproxy )
        {
             sError = string.Empty;
            string sInsert = @"INSERT INTO tblAnotacionDet (CodigoBarra,AnotacionId,Fabricante,ItemId,Piezas,Peso,Colada,SucursalId,AlmacenId,CeldaId,Fecha,Correlativo,Login,Status,CodPackList,PesoNetoProveedor,PesoBrutoProveedor,EsDeCliente,Sincronizado,FechaCaducidad,sLote)
                             VALUES
                               ('{0}', '{1}', '{2}', '{3}',{4},{5}, '{6}',{7},{8}, '{9}', '{10}',{11}, '{12}', '{13}', '{14}',{15},{16}, '{17}', '{18}', '{19}', '{20}')";
            sInsert = string.Format(sInsert, CodigoBarra, AnotacionId, Fabricante, ItemId, Piezas, Peso, Colada, SucursalId, AlmacenId, CeldaId, Fecha.ToString("dd/MM/yyyy"), Correlativo, Login, Status, CodPackList, PesoNetoProveedor, PesoBrutoProveedor, EsDeCliente, Sincronizado, FechaCaducidad.ToString("dd/MM/yyyy"),sLote);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public int InsertAnotacionDet(out string sError)
        {
            using (DbTransaction trnSql = this.IniciarTransaccion("SQLSERVER"))
            {
                int a = 0;
                //DbTransaction trnfodo = this.IniciarTransaccion("FTODO");
                try
                {
                  
                    SysSecuencia osecuencia = new SysSecuencia();
                    sError = string.Empty;
                    string sPaquete = osecuencia.TraerSecuencia(SucursalId, "PAQUETE", trnSql);
                    string sInsert = @"INSERT INTO tblAnotacionDet (CodigoBarra,AnotacionId,Fabricante,ItemId,Piezas,Peso,Colada,SucursalId,AlmacenId,CeldaId,Fecha,Correlativo,Login,Status,CodPackList,PesoNetoProveedor,PesoBrutoProveedor,EsDeCliente,Sincronizado,FechaCaducidad)
                                     VALUES
                                       ('{0}', '{1}', '{2}', '{3}',{4},{5}, '{6}',{7},{8}, '{9}', '{10}',{11}, '{12}', '{13}', '{14}',{15},{16}, '{17}', '{18}', '{19}')";
                    sInsert = string.Format(sInsert, CodigoBarra, AnotacionId, Fabricante, ItemId, Piezas, Peso, Colada, SucursalId, AlmacenId, CeldaId, Fecha.ToString("dd/MM/yyyy"), Correlativo, Login, Status, CodPackList, PesoNetoProveedor, PesoBrutoProveedor, EsDeCliente, Sincronizado, FechaCaducidad.ToString("dd/MM/yyyy"));
                    a = ejecutar(ref sError, sInsert);
                    if(a>0)
                        a = osecuencia.ActualizarSecuencia(SucursalId, "PAQUETE", sPaquete, trnSql);
                    if (a > 0)
                        trnSql.Commit();
                    else
                        trnSql.Rollback();
                    trnSql.Dispose();
                    return a;
                }
                catch (Exception ex)
                {
                    throw ex;
                    return a;
                }
            }
        }

        public int UpdateAnotacionDet(string Paquete,string status)
        {
            string sError = string.Empty;
            string sInsert = @"update tblAnotacionDet  set  Status = '{0}' where CodigoBarra = '{1}'";
            sInsert = string.Format(sInsert, status, Paquete);
            return ejecutar(ref sError, sInsert);
        }
        public DataSet SelectAnotacionDet(string Paquete)
        {
            string sError = string.Empty;
            string sInsert = @"select * from tblAnotacionDet  where CodigoBarra = '{0}'";
            sInsert = string.Format(sInsert, Paquete);
            return consultar(sInsert);
        }
        public int VerificarColada(string Colada)
        {
            string sError = string.Empty;
            string sInsert = @"select * from tblAnotacionDet  where CodPackList = '{0}'";
            sInsert = string.Format(sInsert, Colada);
            DataSet dts = consultar(sInsert);
            if (dts.Tables[0].Rows.Count > 0)
                return 1;
            else
                return 0;

        }


       
        public DataSet CargarAnotacionesDet(string anotacion)
        {

            string sSelect = @"select CodigoBarra as  CodigoBarraid,	AnotacionId as AnotacionIddet,	Fabricante,	d.ItemId,	i.Descripcion,d.Piezas,	Peso as Pesoi,	Colada as Coladai,	SucursalId as SucursalIdi,	AlmacenId,	CeldaId,	Fecha as Fechai,	Correlativo as Correlativodet	,Login as Logini,Status as Statusi,	CodPackList,	PesoNetoProveedor,
	                PesoBrutoProveedor,	EsDeCliente as EsDeClientei,	Sincronizado,i.Calidad as Calidadi,FechaCaducidad,i.ItemFId,sLote
                 from tblAnotacionDet d inner join 
				 tblItem i on d.ItemId = i.ItemId
				 where AnotacionId = '{0}'";
            sSelect = string.Format(sSelect, anotacion);
            return this.consultar(sSelect);
        }
    }
}
