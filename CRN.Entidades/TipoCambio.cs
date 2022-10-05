using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TipoCambio
{
	private DateTime p_Fecha;
	private double p_TC;

	public DateTime Fecha
	{
		get { return p_Fecha; }
		set { p_Fecha = value; }
	}
	public double TC
	{
		get { return p_TC; }
		set { p_TC = value; }
	}

}

