using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class EntregaDet
{
	private string p_Id_Entrega;
	private string p_PaqueteId;
	private int p_SucursalId;
	private int p_AlmacenId;
	private DateTime p_Fecha;
	private string p_CeldaId;
	private string p_ItemId;
	private string p_Status;
	private decimal p_Peso;
	private int p_Piezas;
	private string p_OrdenId;
	private string p_Contenedor;
	private string p_Colada;
	private string p_CentroTrabajo;
    private int  p_IdObservacion;

	public string Id_Entrega
	{
		get { return p_Id_Entrega; }
		set { p_Id_Entrega = value; }
	}
	public string PaqueteId
	{
		get { return p_PaqueteId; }
		set { p_PaqueteId = value; }
	}
	public int SucursalId
	{
		get { return p_SucursalId; }
		set { p_SucursalId = value; }
	}
	public int AlmacenId
	{
		get { return p_AlmacenId; }
		set { p_AlmacenId = value; }
	}
	public DateTime Fecha
	{
		get { return p_Fecha; }
		set { p_Fecha = value; }
	}
	public string CeldaId
	{
		get { return p_CeldaId; }
		set { p_CeldaId = value; }
	}
	public string ItemId
	{
		get { return p_ItemId; }
		set { p_ItemId = value; }
	}
	public string Status
	{
		get { return p_Status; }
		set { p_Status = value; }
	}
	public decimal Peso
	{
		get { return p_Peso; }
		set { p_Peso = value; }
	}
	public int Piezas
	{
		get { return p_Piezas; }
		set { p_Piezas = value; }
	}
	public string OrdenId
	{
		get { return p_OrdenId; }
		set { p_OrdenId = value; }
	}
	public string Contenedor
	{
		get { return p_Contenedor; }
		set { p_Contenedor = value; }
	}
	public string Colada
	{
		get { return p_Colada; }
		set { p_Colada = value; }
	}
	public string CentroTrabajo
	{
		get { return p_CentroTrabajo; }
		set { p_CentroTrabajo = value; }
	}
    public int IdObservacion
    {
        get { return p_IdObservacion; }
        set { p_IdObservacion = value; }
    }
}

