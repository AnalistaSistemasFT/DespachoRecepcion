using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class MovConsumido
{
	private Guid p_FCS_ID;
	private string p_PAQUETEID;
	private string p_CENTRO_TRABAJO;
	private string p_NRO_ORDEN;
	private decimal p_CANTIDAD_CONSUMIDA;
	private string p_UNIDAD;
	private string p_STATUS;
	private DateTime p_FECHA;
	private string p_FCS_BATCH_LABEL_1;
    private string p_Item;
    private string p_Item_Desc;
    private string p_AXTrackingType ;
    private string p_AXUnitMeasure;
    private string p_AXCode;
    private string p_Colada;
    private string p_NumSerie;
    private DateTime p_FechaIntegracion;
    private string  p_FCS_MACHINE;

    public string  FCS_MACHINE
    {
        get { return p_FCS_MACHINE; }
        set { p_FCS_MACHINE = value; }
    }


    public DateTime FechaIntegracion
    {
        get { return p_FechaIntegracion; }
        set { p_FechaIntegracion = value; }
    }


    public string NumSerie
    {
        get { return p_NumSerie; }
        set { p_NumSerie = value; }
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

    public string AXTrackingType
    {
        get { return p_AXTrackingType; }
        set { p_AXTrackingType = value; }
    }


    public string Item_Desc
    {
        get { return p_Item_Desc; }
        set { p_Item_Desc = value; }
    }

    public string Item
    {
        get { return p_Item; }
        set { p_Item = value; }
    }


    public Guid FCS_ID
	{
		get { return p_FCS_ID; }
		set { p_FCS_ID = value; }
	}
	public string PAQUETEID
	{
		get { return p_PAQUETEID; }
		set { p_PAQUETEID = value; }
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
	public decimal CANTIDAD_CONSUMIDA
	{
		get { return p_CANTIDAD_CONSUMIDA; }
		set { p_CANTIDAD_CONSUMIDA = value; }
	}
	public string UNIDAD
	{
		get { return p_UNIDAD; }
		set { p_UNIDAD = value; }
	}
	public string STATUS
	{
		get { return p_STATUS; }
		set { p_STATUS = value; }
	}
	public DateTime FECHA
	{
		get { return p_FECHA; }
		set { p_FECHA = value; }
	}
	public string FCS_BATCH_LABEL_1
	{
		get { return p_FCS_BATCH_LABEL_1; }
		set { p_FCS_BATCH_LABEL_1 = value; }
	}

}

