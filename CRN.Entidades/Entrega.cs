using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Entrega
{
	private string p_ID_Entrega;
	private DateTime p_FechaCreacion;
	private int p_Ejecutor;
	private int p_Id_DptoOrigen;
	private int p_Id_DptoDestino;
	private string p_TipoEntrega;
	private string p_Referencia;
	private string p_Obs;
	private string p_Status;
	private string p_CentroTrabajo;
	private string p_ItemId;
	private decimal p_Cantidad;
	private string p_Unidad;
	private int p_SucursalId;
	private int p_Correlativo;
	private DateTime p_FechaEjecucion;
	private DateTime p_FechaFinEjecucion;
	private DateTime p_FechaCierre;
	private int p_Duracion;

	public string ID_Entrega
	{
		get { return p_ID_Entrega; }
		set { p_ID_Entrega = value; }
	}
	public DateTime FechaCreacion
	{
		get { return p_FechaCreacion; }
		set { p_FechaCreacion = value; }
	}
	public int Ejecutor
	{
		get { return p_Ejecutor; }
		set { p_Ejecutor = value; }
	}
	public int Id_DptoOrigen
	{
		get { return p_Id_DptoOrigen; }
		set { p_Id_DptoOrigen = value; }
	}
	public int Id_DptoDestino
	{
		get { return p_Id_DptoDestino; }
		set { p_Id_DptoDestino = value; }
	}
	public string TipoEntrega
	{
		get { return p_TipoEntrega; }
		set { p_TipoEntrega = value; }
	}
	public string Referencia
	{
		get { return p_Referencia; }
		set { p_Referencia = value; }
	}
	public string Obs
	{
		get { return p_Obs; }
		set { p_Obs = value; }
	}
	public string Status
	{
		get { return p_Status; }
		set { p_Status = value; }
	}
	public string CentroTrabajo
	{
		get { return p_CentroTrabajo; }
		set { p_CentroTrabajo = value; }
	}
	public string ItemId
	{
		get { return p_ItemId; }
		set { p_ItemId = value; }
	}
	public decimal Cantidad
	{
		get { return p_Cantidad; }
		set { p_Cantidad = value; }
	}
	public string Unidad
	{
		get { return p_Unidad; }
		set { p_Unidad = value; }
	}
	public int SucursalId
	{
		get { return p_SucursalId; }
		set { p_SucursalId = value; }
	}
	public int Correlativo
	{
		get { return p_Correlativo; }
		set { p_Correlativo = value; }
	}
	public DateTime FechaEjecucion
	{
		get { return p_FechaEjecucion; }
		set { p_FechaEjecucion = value; }
	}
	public DateTime FechaFinEjecucion
	{
		get { return p_FechaFinEjecucion; }
		set { p_FechaFinEjecucion = value; }
	}
	public DateTime FechaCierre
	{
		get { return p_FechaCierre; }
		set { p_FechaCierre = value; }
	}
	public int Duracion
	{
		get { return p_Duracion; }
		set { p_Duracion = value; }
	}

}

