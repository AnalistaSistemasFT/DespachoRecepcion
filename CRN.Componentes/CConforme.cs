using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CConforme
    {
        TAccion objaccion;
        NoConformidad objnconform;
        CADConforme objprinc=new CADConforme();
        CADNoConformeAccion objprinacc = new CADNoConformeAccion();
        public bool GuardarInformacion(List<TAccion> acc,NoConformidad nocon,List<int> resultadoObtuvido) 
        {
            string consulta = String.Empty;
            consulta = "SELECT TOP 1 inoconformidad_id FROM tblnoconformidad ORDER BY inoconformidad_id DESC";
            DataSet d = this.Ejecutarsentencias(consulta);
            int idprinc = 0;
            //obtenemos el ultimo id de la tabla tblnoconformidad
            foreach (DataRow item in d.Tables[0].Rows)
            {
                idprinc = int.Parse(item[0].ToString());
            }
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    objprinc.GuardarNoConforme(nocon);

                   // acc.INoconformidad_Id = idprinc+1;
                    foreach (TAccion item in acc)
                    {
                        //se truncarian
                        objprinacc.GuardarNoConformeAccion(item, (idprinc + 1));
                    }
                    //creamos la consulta simple para guardar finalmente los resultados obtenidos                    
                    if(resultadoObtuvido.Count>0)
                    {
                        consulta = "insert into dbo.tblResultado (inoconformidad_id,itiporesultado_id) values ";
                        foreach (var item in resultadoObtuvido)
                        {
                            consulta += String.Format("({0},{1}),", (idprinc + 1), item.ToString());
                        }
                        objprinc.EjecutaSentenciasInforme(consulta.Substring(0, consulta.Length - 1));
                    }                    
                    ts.Complete();
                }
                return true;
            }
            catch (Exception ww)
            {
                return false;
            }                  
        }                      
        public bool EditarInfo(List<TAccion> acc, NoConformidad nocon, List<int> resultadoObtuvido,int idformu) 
        {
            string consulta = String.Empty;                 
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    nocon.Id_Noconforme = idformu;
                    int res1=objprinc.EditarNoConforme(nocon);
                    // acc.INoconformidad_Id = idprinc+1;
                    if (objprinacc.EjecutaSentenciasAccion(String.Format("delete from dbo.tblaccion where  inoconformidad_id={0}", idformu)) == 1)
                    {
                     //verifcar porqu no borra los registros anteriores
                    }
                    else    //hola mundo
                    {                        
                    }
                    foreach (TAccion item in acc)
                    {
                        objprinacc.GuardarNoConformeAccion(item, (idformu));
                    }
                    //creamos la consulta simple para guardar finalmente los resultados obtenidos
                    int res = objprinc.EjecutaSentenciasInforme(String.Format("delete from dbo.tblResultado where inoconformidad_id={0}", idformu));
                    if (resultadoObtuvido.Count > 0)
                    {                       
                        consulta = "insert into dbo.tblResultado (inoconformidad_id,itiporesultado_id) values ";
                        foreach (var item in resultadoObtuvido)
                        {
                            consulta += String.Format("({0},{1}),", (idformu), item.ToString());
                        }
                        objprinc.EjecutaSentenciasInforme(consulta.Substring(0, consulta.Length - 1));
                    }
                    ts.Complete();
                }
                return true;
            }
            catch (Exception ww)
            {
                return false;
            }        
        }
        public DataSet Ejecutarsentencias(string sentencia) 
        {
            return objprinc.EjecutarXPrivado(sentencia);        
        }

        public bool Ejecutarconsulta(string consulta)
        {
            return objprinc.EjecutaSentenciasInforme(consulta)==1;        
        }
    }
}
