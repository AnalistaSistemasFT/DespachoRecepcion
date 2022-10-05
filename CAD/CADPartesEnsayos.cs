using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADPartesEnsayos : DBDAC
    {
        public CADPartesEnsayos()
            : base("SQLSERVER1", "dbo.tblTipoEnsayoParam")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@ParametroId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @ParametroId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        
        }
        public void GuardarPartesEnsayo(PartesEnsayos ensayo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@TipoId"].Value = ensayo.TipoId;
            cmdInsert.Parameters["@Nombre"].Value = ensayo.Nombre;
            cmdInsert.Parameters["@EsFormula"].Value = ensayo.Esformula;
            cmdInsert.Parameters["@Unidad"].Value = ensayo.Unidad;
            cmdInsert.Parameters["@HabilitaLimiteMin"].Value = ensayo.Habilitalimitemin;
            cmdInsert.Parameters["@LimiteMinAprob"].Value = ensayo.Limiteminaprob;
            cmdInsert.Parameters["@HabilitaLimiteMax"].Value = ensayo.Habilitelimitemax;
            cmdInsert.Parameters["@LimiteMaxAprob"].Value = ensayo.Limitemaxaprob;
            cmdInsert.Parameters["@Formula"].Value = ensayo.Formula;
            cmdInsert.Parameters["@Procedimiento"].Value = ensayo.Procedimiento;
            cmdInsert.Parameters["@HabilitaLimiteTabla"].Value = ensayo.Habilitalimitetabla;
            cmdInsert.Parameters["@TablaId"].Value = ensayo.TablaId;
            cmdInsert.Parameters["@tipodato"].Value = ensayo.Tipodato;
            cmdInsert.Parameters["@Obligatorio"].Value = ensayo.Obligatorio;
            cmdInsert.Parameters["@CampoTabla"].Value = ensayo.Campotabla;
            cmdInsert.Parameters["@Posicion"].Value = ensayo.Posicion;

            EjecutarComando(cmdInsert);
        }


        public void EliminarParteEnsayo(int idparteensayo)
        {
            DbCommand cmdDelete = Adapter.DeleteCommand;
            cmdDelete.Parameters["@Original_ParametroId"].Value = idparteensayo;
            EjecutarComando(cmdDelete);
        }

        public void ModificarParteEnsayo(PartesEnsayos ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Original_ParametroId"].Value = ensayo.ParametroID;
            cmdModificar.Parameters["@TipoId"].Value = ensayo.TipoId;
            cmdModificar.Parameters["@Nombre"].Value = ensayo.Nombre;
            cmdModificar.Parameters["@EsFormula"].Value = ensayo.Esformula;
            cmdModificar.Parameters["@Unidad"].Value = ensayo.Unidad;
            cmdModificar.Parameters["@HabilitaLimiteMin"].Value = ensayo.Habilitalimitemin;
            cmdModificar.Parameters["@LimiteMinAprob"].Value = ensayo.Limiteminaprob;
            cmdModificar.Parameters["@HabilitaLimiteMax"].Value = ensayo.Habilitelimitemax;
            cmdModificar.Parameters["@LimiteMaxAprob"].Value = ensayo.Limitemaxaprob;
            cmdModificar.Parameters["@Formula"].Value = ensayo.Formula;
            cmdModificar.Parameters["@Procedimiento"].Value = ensayo.Procedimiento;
            cmdModificar.Parameters["@HabilitaLimiteTabla"].Value = ensayo.Habilitalimitetabla;
            cmdModificar.Parameters["@TablaId"].Value = ensayo.TablaId;
            cmdModificar.Parameters["@tipodato"].Value = ensayo.Tipodato;
            cmdModificar.Parameters["@Obligatorio"].Value = ensayo.Obligatorio;
            cmdModificar.Parameters["@CampoTabla"].Value = ensayo.Campotabla;
            cmdModificar.Parameters["@Posicion"].Value = ensayo.Posicion;
            

            EjecutarComando(cmdModificar);
        } 
    }
}
