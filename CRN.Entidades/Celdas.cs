using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Celdas
{
	private int p_SucursalId;
	private string p_CeldaId;
	private int p_AlmacenId;
	private int p_Area;
	private string p_Segmento;
	private string p_Fila;
	private int p_Nave;
	private string p_Columna;
	private string p_ItemId;
	private int p_Unidades;
	private double p_Kgs;
	private int p_Status;
	private string p_Proceso;
	private int p_PreAsignado;
	private string p_CeldaTemp;

	public int SucursalId
	{
		get { return p_SucursalId; }
		set { p_SucursalId = value; }
	}
	public string CeldaId
	{
		get { return p_CeldaId; }
		set { p_CeldaId = value; }
	}
	public int AlmacenId
	{
		get { return p_AlmacenId; }
		set { p_AlmacenId = value; }
	}
	public int Area
	{
		get { return p_Area; }
		set { p_Area = value; }
	}
	public string Segmento
	{
		get { return p_Segmento; }
		set { p_Segmento = value; }
	}
	public string Fila
	{
		get { return p_Fila; }
		set { p_Fila = value; }
	}
	public int Nave
	{
		get { return p_Nave; }
		set { p_Nave = value; }
	}
	public string Columna
	{
		get { return p_Columna; }
		set { p_Columna = value; }
	}
	public string ItemId
	{
		get { return p_ItemId; }
		set { p_ItemId = value; }
	}
	public int Unidades
	{
		get { return p_Unidades; }
		set { p_Unidades = value; }
	}
	public double Kgs
	{
		get { return p_Kgs; }
		set { p_Kgs = value; }
	}
	public int Status
	{
		get { return p_Status; }
		set { p_Status = value; }
	}
	public string Proceso
	{
		get { return p_Proceso; }
		set { p_Proceso = value; }
	}
	public int PreAsignado
	{
		get { return p_PreAsignado; }
		set { p_PreAsignado = value; }
	}
	public string CeldaTemp
	{
		get { return p_CeldaTemp; }
        set { p_CeldaTemp = value; }
	}

	

}
