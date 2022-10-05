using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class MovProducido
{
	private string p_PAQUETEID;
	private string p_ITEM;
	private string p_ITEM_DESC;
	private string p_CENTRO_TRABAJO;
	private string p_NRO_ORDEN;
	private int p_POSICION;
	private decimal p_PESO;
	private int p_PIEZAS;
	private decimal p_METROS;
	private DateTime p_FECHA;
	private string p_CALIDAD;
	private string p_FBC_BATCH_LABEL_1;
	private string p_FBC_BATCH_LABEL_2;
	private string p_STATUS;
    private string p_AXUnitMeasure;
    private string p_AXCode;
    private string p_Colada;
    private DateTime p_FechaIntegracion;
    private decimal p_CostoUnitario;
    private decimal p_CostoTotal;

    public decimal CostoTotal
    {
        get { return p_CostoTotal; }
        set { p_CostoTotal = value; }
    }

    public decimal CostoUnitario
    {
        get { return p_CostoUnitario; }
        set { p_CostoUnitario = value; }
    }


    public DateTime FechaIntegracion
    {
        get { return p_FechaIntegracion; }
        set { p_FechaIntegracion = value; }
    }


    public string Colada
    {
        get { return p_Colada; }
        set { p_Colada = value; }
    }


    public string AXCode
    {
        get { return p_AXCode; }
        set { p_AXCode = value; }
    }


    public string AXUnitMeasure
    {
        get { return p_AXUnitMeasure; }
        set { p_AXUnitMeasure = value; }
    }


    public string PAQUETEID
	{
		get { return p_PAQUETEID; }
		set { p_PAQUETEID = value; }
	}
	public string ITEM
	{
		get { return p_ITEM; }
		set { p_ITEM = value; }
	}
	public string ITEM_DESC
	{
		get { return p_ITEM_DESC; }
		set { p_ITEM_DESC = value; }
	}
	public string CENTRO_TRABAJO
	{
		get { return p_CENTRO_TRABAJO; }
		set { p_CENTRO_TRABAJO = value; }
	}
	public string NRO_ORDEN
	{
		get { return p_NRO_ORDEN; }
		set { p_NRO_ORDEN = value; }
	}
	public int POSICION
	{
		get { return p_POSICION; }
		set { p_POSICION = value; }
	}
	public decimal PESO
	{
		get { return p_PESO; }
		set { p_PESO = value; }
	}
	public int PIEZAS
	{
		get { return p_PIEZAS; }
		set { p_PIEZAS = value; }
	}
	public decimal METROS
	{
		get { return p_METROS; }
		set { p_METROS = value; }
	}
	public DateTime FECHA
	{
		get { return p_FECHA; }
		set { p_FECHA = value; }
	}
	public string CALIDAD
	{
		get { return p_CALIDAD; }
		set { p_CALIDAD = value; }
	}
	public string FBC_BATCH_LABEL_1
	{
		get { return p_FBC_BATCH_LABEL_1; }
		set { p_FBC_BATCH_LABEL_1 = value; }
	}
	public string FBC_BATCH_LABEL_2
	{
		get { return p_FBC_BATCH_LABEL_2; }
		set { p_FBC_BATCH_LABEL_2 = value; }
	}
	public string STATUS
	{
		get { return p_STATUS; }
		set { p_STATUS = value; }
	}

}

