using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CRN.Entidades
{
     public class CentroTrabajo
    {
 	    private string p_CentroId;
	    private string p_Nombre;
	    private bool p_Sincronizacion;
	    private int p_SucursalId;
	    private int p_TipoCosteo;
	    private string p_Area;
	    private bool p_Localizacion;
	    private string p_CT_Operacion;
	    private DateTime p_FechaInicioSync;
	    private string p_SelectSQL;
	    private string p_WhereSQL;
	    private bool p_LocalizacionFija;
	    private string p_CeldaId;
	    private bool p_Revision;
	    private string p_SelectFuente;
	    private string p_WhereSinPlan;
	    private string p_WhereConPlan;
	    private bool p_Costeo;
	    private decimal p_PrecioTon;
        private int porcDispersion;

        #region Propiedades
        public string CentroId
	    {
		    get { return p_CentroId; }
		    set { p_CentroId = value; }
	    }
	    public string Nombre
	    {
		    get { return p_Nombre; }
		    set { p_Nombre = value; }
	    }
	    public bool Sincronizacion
	    {
		    get { return p_Sincronizacion; }
		    set { p_Sincronizacion = value; }
	    }
	    public int SucursalId
	    {
		    get { return p_SucursalId; }
		    set { p_SucursalId = value; }
	    }
	    public int TipoCosteo
	    {
		    get { return p_TipoCosteo; }
		    set { p_TipoCosteo = value; }
	    }
	    public string Area
	    {
		    get { return p_Area; }
		    set { p_Area = value; }
	    }
	    public bool Localizacion
	    {
		    get { return p_Localizacion; }
		    set { p_Localizacion = value; }
	    }
	    public string CT_Operacion
	    {
		    get { return p_CT_Operacion; }
		    set { p_CT_Operacion = value; }
	    }
	    public DateTime FechaInicioSync
	    {
		    get { return p_FechaInicioSync; }
		    set { p_FechaInicioSync = value; }
	    }
	    public string SelectSQL
	    {
		    get { return p_SelectSQL; }
		    set { p_SelectSQL = value; }
	    }
	    public string WhereSQL
	    {
		    get { return p_WhereSQL; }
		    set { p_WhereSQL = value; }
	    }
	    public bool LocalizacionFija
	    {
		    get { return p_LocalizacionFija; }
		    set { p_LocalizacionFija = value; }
	    }
	    public string CeldaId
	    {
		    get { return p_CeldaId; }
		    set { p_CeldaId = value; }
	    }
	    public bool Revision
	    {
		    get { return p_Revision; }
		    set { p_Revision = value; }
	    }
	    public string SelectFuente
	    {
		    get { return p_SelectFuente; }
		    set { p_SelectFuente = value; }
	    }
	    public string WhereSinPlan
	    {
		    get { return p_WhereSinPlan; }
		    set { p_WhereSinPlan = value; }
	    }
	    public string WhereConPlan
	    {
		    get { return p_WhereConPlan; }
		    set { p_WhereConPlan = value; }
	    }
	    public bool Costeo
	    {
		    get { return p_Costeo; }
		    set { p_Costeo = value; }
	    }
	    public decimal PrecioTon
	    {
		    get { return p_PrecioTon; }
		    set { p_PrecioTon = value; }
	    }
        public int PorcDispersion
        {
            get { return porcDispersion; }
            set { porcDispersion = value; }
        }

        #endregion
    }
}
