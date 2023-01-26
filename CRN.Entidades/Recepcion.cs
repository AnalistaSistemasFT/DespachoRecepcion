using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CRN.Entidades
{
	public partial class Recepcion
	{
		private string p_RecepcionId;
		private DateTime p_Fecha;
		private string p_Chofer;
		private int p_Camion;
		private string p_Placa;
		private string p_CI;
		private string p_Propietario;
		private string p_Login;
		private string p_Obs;
		private int p_Correlativo;
		private string p_Status;
		private int p_SucursalId;
		private int p_SucOrigen;
		private string p_Documento;
		private int p_Fuente;
		private bool p_EsDeCliente;
		private string p_Manifiesto;
		private string p_Barco;
		private int p_Id_Pais;
		private string p_BL;
		private int p_ProveedorId;

		
		public string RecepcionId
		{
			get { return p_RecepcionId; }
			set { p_RecepcionId = value; }
		}
		public DateTime Fecha
		{
			get { return p_Fecha; }
			set { p_Fecha = value; }
		}
		public string Chofer
		{
			get { return p_Chofer; }
			set { p_Chofer = value; }
		}
		public int Camion
		{
			get { return p_Camion; }
			set { p_Camion = value; }
		}
		public string Placa
		{
			get { return p_Placa; }
			set { p_Placa = value; }
		}
		public string CI
		{
			get { return p_CI; }
			set { p_CI = value; }
		}
		public string Propietario
		{
			get { return p_Propietario; }
			set { p_Propietario = value; }
		}
		public string Login
		{
			get { return p_Login; }
			set { p_Login = value; }
		}
		public string Obs
		{
			get { return p_Obs; }
			set { p_Obs = value; }
		}
		public int Correlativo
		{
			get { return p_Correlativo; }
			set { p_Correlativo = value; }
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
		public int SucOrigen
		{
			get { return p_SucOrigen; }
			set { p_SucOrigen = value; }
		}
		public string Documento
		{
			get { return p_Documento; }
			set { p_Documento = value; }
		}
		public int Fuente
		{
			get { return p_Fuente; }
			set { p_Fuente = value; }
		}
		public bool EsDeCliente
		{
			get { return p_EsDeCliente; }
			set { p_EsDeCliente = value; }
		}
		public string Manifiesto
		{
			get { return p_Manifiesto; }
			set { p_Manifiesto = value; }
		}
		public string Barco
		{
			get { return p_Barco; }
			set { p_Barco = value; }
		}
		public int Id_Pais
		{
			get { return p_Id_Pais; }
			set { p_Id_Pais = value; }
		}
		public string BL
		{
			get { return p_BL; }
			set { p_BL = value; }
		}
		public int ProveedorId
		{
			get { return p_ProveedorId; }
			set { p_ProveedorId = value; }
		}

	}
}

