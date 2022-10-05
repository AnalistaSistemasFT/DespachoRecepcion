using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public  class CADCatTablaDetalle:DBDAC
    {
        public CADCatTablaDetalle()
            : base("SQLSERVER1", "dbo.tblCatTablaDetalle")
        {
           /*   DbParameter par = this.CrearParametro();
              par.ParameterName = "@TablaId";
              par.DbType = DbType.Int32;
              par.Direction = ParameterDirection.Output;
              Adapter.InsertCommand.CommandText += ";SELECT @TablaId=SCOPE_IDENTITY();";
              Adapter.InsertCommand.Parameters.Add(par);        */
        }
        public void GuardarCatTablaDetalle(CatTablaDetalle ensayo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Valor"].Value = ensayo.Nominal;
            cmdInsert.Parameters["@Maximo"].Value = ensayo.Max;
            cmdInsert.Parameters["@Minimo"].Value = ensayo.Min;
            cmdInsert.Parameters["@TablaId"].Value = ensayo.Tablaid;
            EjecutarComando(cmdInsert);
        }
        public void ModificarCatTablaDetalle(CatTablaDetalle ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            
            EjecutarComando(cmdModificar);
        }
        public int EliminarDespDetalle(int idt)
        {
            return EjecutarComando("DELETE FROM dbo.tblCatTablaDetalle WHERE TablaId=" +idt);
        }
        
    }
}
