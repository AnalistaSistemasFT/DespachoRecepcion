using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class CausaCuarentena
{
	private int p_Id_Causa;
	private string p_Descripcion;

	public int Id_Causa
	{
		get { return p_Id_Causa; }
		set { p_Id_Causa = value; }
	}
	public string Descripcion
	{
		get { return p_Descripcion; }
		set { p_Descripcion = value; }
	}

}

