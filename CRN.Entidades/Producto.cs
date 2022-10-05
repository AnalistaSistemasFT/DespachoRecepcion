using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Producto
{
	private string p_LPR_PRODUCT_CODE;
	private string p_LPR_PRODUCT_VERSION;
	private string p_LPR_PRODUCT_DESC;
	private string p_LPR_MEAS_UNIT;
	private string p_LPR_PURCHASE_MEAS_UNIT;
	private string p_LPR_TECH_MEAS_UNIT;
	private double p_LPR_COEFF_PURCHASE_MEAS;
	private double p_LPR_COEFF_TECH_MEAS;
	private bool p_LPR_LOCATION_MNG;
	private bool p_LPR_BATCH_MNG;
	private DateTime p_LPR_INS_DATE;
	private bool p_LPR_ENABLED;
	private DateTime p_LPR_DATE;
	private string p_LPR_PLANT;
	private string p_LPR_ISSUES;

	public string LPR_PRODUCT_CODE
	{
		get { return p_LPR_PRODUCT_CODE; }
		set { p_LPR_PRODUCT_CODE = value; }
	}
	public string LPR_PRODUCT_VERSION
	{
		get { return p_LPR_PRODUCT_VERSION; }
		set { p_LPR_PRODUCT_VERSION = value; }
	}
	public string LPR_PRODUCT_DESC
	{
		get { return p_LPR_PRODUCT_DESC; }
		set { p_LPR_PRODUCT_DESC = value; }
	}
	public string LPR_MEAS_UNIT
	{
		get { return p_LPR_MEAS_UNIT; }
		set { p_LPR_MEAS_UNIT = value; }
	}
	public string LPR_PURCHASE_MEAS_UNIT
	{
		get { return p_LPR_PURCHASE_MEAS_UNIT; }
		set { p_LPR_PURCHASE_MEAS_UNIT = value; }
	}
	public string LPR_TECH_MEAS_UNIT
	{
		get { return p_LPR_TECH_MEAS_UNIT; }
		set { p_LPR_TECH_MEAS_UNIT = value; }
	}
	public double LPR_COEFF_PURCHASE_MEAS
	{
		get { return p_LPR_COEFF_PURCHASE_MEAS; }
		set { p_LPR_COEFF_PURCHASE_MEAS = value; }
	}
	public double LPR_COEFF_TECH_MEAS
	{
		get { return p_LPR_COEFF_TECH_MEAS; }
		set { p_LPR_COEFF_TECH_MEAS = value; }
	}
	public bool LPR_LOCATION_MNG
	{
		get { return p_LPR_LOCATION_MNG; }
		set { p_LPR_LOCATION_MNG = value; }
	}
	public bool LPR_BATCH_MNG
	{
		get { return p_LPR_BATCH_MNG; }
		set { p_LPR_BATCH_MNG = value; }
	}
	public DateTime LPR_INS_DATE
	{
		get { return p_LPR_INS_DATE; }
		set { p_LPR_INS_DATE = value; }
	}
	public bool LPR_ENABLED
	{
		get { return p_LPR_ENABLED; }
		set { p_LPR_ENABLED = value; }
	}
	public DateTime LPR_DATE
	{
		get { return p_LPR_DATE; }
		set { p_LPR_DATE = value; }
	}
	public string LPR_PLANT
	{
		get { return p_LPR_PLANT; }
		set { p_LPR_PLANT = value; }
	}
	public string LPR_ISSUES
	{
		get { return p_LPR_ISSUES; }
		set { p_LPR_ISSUES = value; }
	}

}

