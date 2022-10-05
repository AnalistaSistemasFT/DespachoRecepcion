using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADTblEnsayoDetalle:DBDAC
    {
        public CADTblEnsayoDetalle()
            : base("SQLSERVER1", "dbo.tblEnsayoDetalle")
        {
           /* DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Ensayo";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Ensayo=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par); */       
        }
        public DataSet RetornarCattblEnsayoDetalle (string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarTblEnsayoDetalle(TblEnsayoDetalle ensayo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@ParametroId"].Value = ensayo.Param_ID;
            cmdInsert.Parameters["@EnsayoId"].Value = ensayo.Ensayo_ID;
            cmdInsert.Parameters["@Valor"].Value = ensayo.ValoR;
            cmdInsert.Parameters["@Status"].Value = ensayo.StatuS;
            cmdInsert.Parameters["@Limites"].Value = ensayo.Limite;
            cmdInsert.Parameters["@tipodato"].Value = ensayo.TipoDato;
            cmdInsert.Parameters["@Id_Ensayo"].Value = ensayo.ID_ensayo;
            EjecutarComando(cmdInsert);
        }
        public void ModificarTBLEnsayoDetalle(TblEnsayoDetalle ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@ParametroId"].Value = ensayo.Param_ID;
            cmdModificar.Parameters["@EnsayoId"].Value = ensayo.Ensayo_ID;
            cmdModificar.Parameters["@Valor"].Value = ensayo.ValoR;
            cmdModificar.Parameters["@Status"].Value = ensayo.StatuS;
            cmdModificar.Parameters["@Limites"].Value = ensayo.Limite;
            cmdModificar.Parameters["@tipodato"].Value = ensayo.TipoDato;
            cmdModificar.Parameters["@Id_Ensayo"].Value = ensayo.ID_ensayo;
            EjecutarComando(cmdModificar);
        }

        public int EliminarRegsDeta (int docId)
        {
            return EjecutarComando("DELETE FROM dbo.tblEnsayoDetalle WHERE  Id_Ensayo=" + docId);
        }

        public int EliminarTBLEnsayoDetalle(int iensayo)
        {
            DbCommand cmdModificar = Adapter.DeleteCommand;
            cmdModificar.Parameters["@Id_Ensayo"].Value = iensayo;
            return EjecutarComando(cmdModificar);
        }
    }
}
