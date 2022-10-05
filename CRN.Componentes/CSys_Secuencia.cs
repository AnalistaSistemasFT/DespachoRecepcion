using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CSys_Secuencia : oledb
    {
        public CSys_Secuencia()
        {
            this.sConnName = "SQLSERVER";
        }
        //static string cadenaConexion = @"Data Source=LocalHost;Initial Catalog=LYBK;Persist Security Info=True;user id=sa;password=Passw0rd;Connect Timeout=160";
        //TraerSecuencia
        public string TraerSecuencia(int Suscursal, string sTipo)
        {
            string sSelect = "select * from Sys_Secuencia where Operacion = '{0}' and sucursal={1}";
            sSelect = string.Format(sSelect, sTipo, Suscursal);
            DataTable dtsResult = consultar(sSelect).Tables[0];
            string sSecuencia = "";
            if (dtsResult.Rows.Count > 0)
            {
                string sContador = dtsResult.Rows[0]["Contador"].ToString();
                string sFijo = dtsResult.Rows[0]["Fijo"].ToString();
                int iSiguiente = 0;
                string year = "0";
                switch (dtsResult.Rows[0]["Reset"].ToString())
                {

                    case "y":
                        year = (sContador.Substring(2, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        iSiguiente = Convert.ToInt32(sContador.Substring(4, 6)) + 1;
                        sSecuencia = sFijo + year + (iSiguiente.ToString("D6"));
                        break;
                    case "m":
                        year = (sContador.Substring(0, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        string Mes = (sContador.Substring(2, 2));
                        if (Mes != DateTime.Now.Month.ToString())
                            Mes = DateTime.Now.Month.ToString("D2");
                        iSiguiente = Convert.ToInt32(sContador.Substring(6, 5)) + 1;
                        sSecuencia = year + Mes + sFijo + (iSiguiente.ToString("D5"));
                        break;
                }
            }
            return sSecuencia;
        }
        //public DataTable ejecutarConsulta1(string sentencia)
        //{
        //    //List<Parametro> listaEmpleados = new List<Parametro>();
        //    DataTable data = new DataTable();
        //    using (SqlConnection con = new SqlConnection(cadenaConexion))
        //    {
        //        con.Open();
        //        using (SqlCommand comando = new SqlCommand(sentencia, con))
        //        {
        //            using (SqlDataAdapter reader = new SqlDataAdapter(comando))
        //            {
        //                reader.Fill(data);
        //            }
        //        }
        //        con.Close();
        //        return data;
        //    }
        //}
        protected int ejecutar(ref string er, string csql, System.Data.SqlClient.SqlTransaction obtransaccion)
        {
            try
            {
                System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(csql, obtransaccion.Connection);
                comando.Transaction = obtransaccion;
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return 0;
            }
        }
    }
}
