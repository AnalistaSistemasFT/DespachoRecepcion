using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CDespProg : oledb
    {
        public CDespProg()
        {
            this.sConnName = "SQLSERVER";
        }
        //InsertarProgCelda
        public int InsertProgCelda(DespProgCelda _progCelda, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO tblDespProgCelda ([DespachoId],[ItemId],[CeldaId],[Piezas],[Paquetes],[SucursalId])
                                VALUES ('{0}','{1}','{2}',{3},{4},{5})";
            sInsert = string.Format(sInsert, _progCelda.p_DespachoId, _progCelda.p_ItemId, _progCelda.p_CeldaId, _progCelda.p_Piezas, _progCelda.p_Paquetes, _progCelda.p_SucursalId);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        //InsertarProgSob
        public int InsertProgSob(DespProgSob _progSob, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO tblDespProgSob ([DespachoId],[ItemId],[PaqueteId],[CeldaId],[Piezas],[SucursalId])
                                VALUES ('{0}','{1}','{2}','{3}',{4},{5})";
            sInsert = string.Format(sInsert, _progSob.p_DespachoId, _progSob.p_ItemId, _progSob.p_PaqueteId, _progSob.p_CeldaId, _progSob.p_Piezas, _progSob.p_SucursalId);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        public int InsertarDespProg(DataTable dtCelda, DataTable dtSob)
        {
            int a = 0;
            try
            {
                using (DbTransaction trnSql = this.IniciarTransaccion())
                {
                    DespProgCelda _progCelda = new DespProgCelda();
                    DespProgSob _progSob = new DespProgSob();
                    if (dtCelda.Rows.Count == 0)
                    {
                        if (dtSob.Rows.Count == 0)
                        {
                            Console.WriteLine("################### dtCelda y dtSob = 0");
                        }
                        else
                        {
                            for (int i = 0; i < dtSob.Rows.Count; i++)
                            {
                                _progSob.p_DespachoId = dtSob.Rows[i][0].ToString();
                                _progSob.p_ItemId = dtSob.Rows[i][1].ToString();
                                _progSob.p_CeldaId = dtSob.Rows[i][2].ToString();
                                _progSob.p_Piezas = Convert.ToDecimal(dtSob.Rows[i][3]);
                                _progSob.p_PaqueteId = dtSob.Rows[i][4].ToString();
                                _progSob.p_SucursalId = Convert.ToInt32(dtSob.Rows[i][5]);
                                a = this.InsertProgSob(_progSob, trnSql);
                                if (a == 0)
                                {
                                    break;
                                }
                            }
                            if (a > 0)
                            {
                                trnSql.Commit();
                            }
                            else
                            {
                                trnSql.Rollback();
                                trnSql.Dispose();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtCelda.Rows.Count; i++)
                        {
                            _progCelda.p_DespachoId = dtCelda.Rows[i][0].ToString();
                            _progCelda.p_ItemId = dtCelda.Rows[i][1].ToString();
                            _progCelda.p_CeldaId = dtCelda.Rows[i][2].ToString();
                            _progCelda.p_Piezas = Convert.ToInt32(dtCelda.Rows[i][3]);
                            _progCelda.p_Paquetes = Convert.ToInt32(dtCelda.Rows[i][4]);
                            _progCelda.p_SucursalId = Convert.ToInt32(dtCelda.Rows[i][5]);
                            a = this.InsertProgCelda(_progCelda, trnSql);
                            if (a == 0)
                            {
                                break;
                            }
                        }
                        if (dtSob.Rows.Count == 0)
                        {
                            if (a > 0)
                            {
                                trnSql.Commit();
                            }
                            else
                            {
                                trnSql.Rollback();
                            }
                        }
                        else
                        {
                            if (a > 0)
                            {
                                for (int i = 0; i < dtSob.Rows.Count; i++)
                                {
                                    _progSob.p_DespachoId = dtSob.Rows[i][0].ToString();
                                    _progSob.p_ItemId = dtSob.Rows[i][1].ToString();
                                    _progSob.p_CeldaId = dtSob.Rows[i][2].ToString();
                                    _progSob.p_Piezas = Convert.ToInt32(dtSob.Rows[i][3]);
                                    _progSob.p_PaqueteId = dtSob.Rows[i][4].ToString();
                                    _progSob.p_SucursalId = Convert.ToInt32(dtSob.Rows[i][5]);
                                    a = this.InsertProgSob(_progSob, trnSql);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                }
                                if (a > 0)
                                {
                                    trnSql.Commit();
                                }
                                else
                                {
                                    trnSql.Rollback();
                                }
                            }
                            else
                            {
                                trnSql.Rollback();
                                trnSql.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
            }
            return a;
        }
    }
}
