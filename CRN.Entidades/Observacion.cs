using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Observacion
{
	private int p_IdObservacion;
	private string p_Descripcion;

	public int IdObservacion
	{
		get { return p_IdObservacion; }
		set { p_IdObservacion = value; }
	}
	public string Descripcion
	{
		get { return p_Descripcion; }
		set { p_Descripcion = value; }
	}

}

