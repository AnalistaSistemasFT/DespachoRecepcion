using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;
namespace CAD
{
    public class CADRecursosUser:DBDAC
    {
        public CADRecursosUser()
            : base("SQLSERVER", "dbo.tblRecursosUser")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@RecursoId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @RecursoId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        //MovSync movSync;
        //public int GuardarArchivo(MovSync oMovSync)
        //{
        //    DbCommand cmdInsert = Adapter.InsertCommand;
        //    cmdInsert.Parameters["@OrdenId"].Value = oMovSync.p_OrdenId;
        //    cmdInsert.Parameters["@Fecha"].Value = oMovSync.p_Fecha;
        //    cmdInsert.Parameters["@CentroTrabajo"].Value = oMovSync.p_CentroTrabajo;
        //    cmdInsert.Parameters["@FechaCierre"].Value = oMovSync.p_FechaCierre;
        //    cmdInsert.Parameters["@Status"].Value = oMovSync.p_Status;
        //    cmdInsert.Parameters["@TipoOrden"].Value = oMovSync.p_TipoOrden;
        //    cmdInsert.Parameters["@SucursalId"].Value = oMovSync.p_SucursalId;
        //    cmdInsert.Parameters["@SucursalDestino"].Value = oMovSync.p_SucursalDestino;
        //    cmdInsert.Parameters["@OrdenLigada"].Value = oMovSync.p_OrdenLigada;
        //    cmdInsert.Parameters["@ItemFLigado"].Value = oMovSync.p_ItemLigado;
        //    cmdInsert.Parameters["@EsDeCliente"].Value = oMovSync.p_EsDeCliente;
        //    return EjecutarComando(cmdInsert);
        //}

        public DataSet TraerTodosLosArchivos()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodosLosRecursosUser(string where)
        {
            return this.Consultar(where);
        }
        public DataSet TraerTodosLoscontenidos(int idCarpeta)
        { 
            string consulta="SELECT d.docId,Id_Carpeta,codigoSig,version,fechaRegistro,estado,eliminado,tituloDocumento,fechaAprobacion,autor,comentario "+
                            ",contiene=case when a.nombre is null then 'false' else 'true' end "+
                            "FROM documentos d left join archivo a on d.docId =a.docId where d.eliminado='false' and d.Id_Carpeta="+idCarpeta.ToString();

            return this.EjecutarConsulta(consulta);
        }
        //public DataTable TraerArchivo(int docId)
        //{
        //    string cadena = "select d.docId as Documento,a.nombre as Titulo del Documento,d.codigoSig as Codigo Sig" +
        //                    "d.version as Version, from documentos d join archivo a ";
        //}

        //public Archivo TraerArchivo(int docId)
        //{
        //    //DataTable customerOrders=new DataTable();
            //DataSet ds = new DataSet();
            //DataSet ds = this.Consultar("docId=" + docId);
            //DataTable tArchivo = ds.Tables[0];

            //ds.Relations.Add("customerOrders",
            //    ds.Tables["Documentos"].Columns["docId"],
            //    ds.Tables["archivo"].Columns["docId"]);
            //customerOrders = ds.Tables[0];


            //DataSet ds = new DataSet();
            //ds.Tables["documentos"].Columns["docId"];
            //ds.Tables.Add("archivo");
            //DataRelation objRelation=new DataRelation("objRelation","documentos")

            //if (customerOrders.Rows.Count == 0)
            //{
            //    return null;
            //}
            //DataRow rArchivo = customerOrders.Rows[0];
            //Archivo oArchivo = new Archivo();
            //Importar oImportar = new Importar();
            //oArchivo.p_docId = docId;

            //oImportar.p_nombre = rArchivo["nombre"].ToString();
            //oImportar.p_extension = rArchivo["extension"].ToString();
            //oArchivo.p_Id_Carpeta = int.Parse(rArchivo["Id_Carpeta"].ToString());
            //oArchivo.p_codigoSig = rArchivo["codigoSig"].ToString();
            //oArchivo.p_version = int.Parse(rArchivo["version"].ToString());
            //oArchivo.p_fechaRegistro = DateTime.Parse(rArchivo["fechaRegistro"].ToString());
            //oArchivo.p_estado = rArchivo["estado"].ToString();

            //if (rArchivo["doc"] != DBNull.Value)
            //    oImportar.p_doc = (byte[])rArchivo["doc"];
            //return oArchivo;



            //if (tArchivo.Rows.Count == 0)
            //{
            //    return null;
            //}
            //DataRow rArchivo = tArchivo.Rows[0];
            //Archivo oArchivo = new Archivo();
            //Importar oImportar = new Importar();
            //oArchivo.p_docId = docId;
            
            //oImportar.p_nombre = rArchivo["nombre"].ToString();
            //oImportar.p_extension = rArchivo["extension"].ToString();
            //oArchivo.p_Id_Carpeta =int.Parse(rArchivo["Id_Carpeta"].ToString());
            //oArchivo.p_codigoSig = rArchivo["codigoSig"].ToString();
            //oArchivo.p_version = int.Parse(rArchivo["version"].ToString());
            //oArchivo.p_fechaRegistro =DateTime.Parse(rArchivo["fechaRegistro"].ToString());
            //oArchivo.p_estado = rArchivo["estado"].ToString();

            //if (rArchivo["doc"] != DBNull.Value)
            //    oImportar.p_doc = (byte[])rArchivo["doc"];
            //return oArchivo;
        //}
        //public int ModificarArchivos(MovSync oorden)
        //{
        //    DbCommand cmdModificar = Adapter.UpdateCommand;
        //    cmdModificar.Parameters["@OrdenId"].Value = oorden.OrdenId;
        //    cmdModificar.Parameters["@Fecha"].Value = oorden.Fecha;
        //    cmdModificar.Parameters["@CentroTrabajo"].Value = oorden.CentroTrabajo;
        //    cmdModificar.Parameters["@FechaCierre"].Value = oorden.FechaCierre;
        //    cmdModificar.Parameters["@Status"].Value = oorden.Status;
        //    cmdModificar.Parameters["@TipoOrden"].Value = oorden.TipoOrden;
        //    cmdModificar.Parameters["@SucursalId"].Value = oorden.SucursalId;
        //    cmdModificar.Parameters["@SucursalDestino"].Value = oorden.SucursalDestino;
        //    cmdModificar.Parameters["@OrdenLigada"].Value = oorden.OrdenLigada;
        //    cmdModificar.Parameters["@ItemFLigado"].Value = oorden.ItemLigado;
        //    cmdModificar.Parameters["@EsDeCliente"].Value = oorden.EsDeCliente;
        //    return EjecutarComando(cmdModificar);
        //}
        public int EliminarArchivosCarpetas(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }

        public int MarcarEliminado(int docId,int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = "+ Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet CargarComboSucursal()
        {
            string cadena = "select SucursalID,Nombre from Empleados.dbo.Sucursal where Adscrita='true'";
            return EjecutarConsulta(cadena);
       
        }
    }
}
