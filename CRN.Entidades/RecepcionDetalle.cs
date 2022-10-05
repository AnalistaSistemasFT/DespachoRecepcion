using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class RecepcionDetalle
{
	private string p_RecepcionId;
	private string p_ItemId;
	private decimal p_Cantidad;
	private string p_Unidad;
	private string p_Status;
	private int p_SucursalId;

	public string RecepcionId
	{
		get { return p_RecepcionId; }
		set { p_RecepcionId = value; }
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
	public string Status
	{
		get { return p_Status; }
		set { p_Status = value; }
	}
	public int SucursalId
	{
		get { return p_SucursalId; }
		set { p_SucursalId = value; }
	}

}

