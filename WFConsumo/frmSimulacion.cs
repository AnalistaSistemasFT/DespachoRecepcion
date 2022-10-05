using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CRN.Componentes;
using Entidades;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml.Linq;
using System.Xml;
using CRN.Entidades;

namespace WFConsumo
{
    public partial class frmSimulacion : Form
    {
        string strOrden,strPaquete,strCentro;
        int iSucursal;
        int i = 0, j = 0, pivotHr = 0, pivotTr = 0;
        CSucursal cSuc ;
        Sucursal oSuc;
        CMovProducido cProd;
        //CConsumido cCsmd;
        //Consumido csmd;
        CMovConsumido cCsmd;
        MovConsumido csmd;
        Orden oOrden;
        DataTable dtP,dtC;
        Consumo cons;
        public frmSimulacion(int Sucursal, string centro,string sOrden)
        {
            iSucursal = Sucursal;
            cSuc = new CSucursal();
            oSuc = cSuc.TraerSucursal(Sucursal);
            strOrden=sOrden;
            strCentro = centro;
            InitializeComponent();
        }

        private void CargarOrden()
        {
            //DataSet ds;
            //lblOrden.Text = strOrden;
            //cCsmd = new CConsumido();
            //ds = cCsmd.TraerTodosConsumido(strCentro,strOrden);
            //dtC = ds.Tables[0];
            //dgvConsumos.DataSource = dtC;
            //var sum = dtC.AsEnumerable().Sum(dr => dr.Field<decimal>("Cantidad"));
            //lblPesoConsumido.Text = sum.ToString();
            //cProd = new CProducido();
            //ds = cProd.TraerTodosProducido(strCentro,strOrden);
            //dtP = ds.Tables[0];
            ////BindingSource bindingSource1 = new BindingSource();
            ////bindingSource1.DataSource = dtP;
            ////dgvProductos.DataSource = bindingSource1;
            //dgvProductos.DataSource = dtP;
            //sum = dtP.AsEnumerable().Sum(dr => dr.Field<decimal>("Peso"));
            //lblPesoProducido.Text = sum.ToString();
           DataSet ds;
            lblOrden.Text = strOrden;
            cCsmd = new CMovConsumido();
            ds = cCsmd.TraerTodosMovConsumido(strCentro,strOrden);
            dtC = ds.Tables[0];
            dgvConsumos.DataSource = dtC;
            var sum = dtC.AsEnumerable().Sum(dr => dr.Field<decimal>("Cantidad_Consumida"));
            lblPesoConsumido.Text = sum.ToString();
            cProd = new CMovProducido();
            ds = cProd.TraerTodosMovProducido(strOrden);
            dtP = ds.Tables[0];
            //BindingSource bindingSource1 = new BindingSource();
            //bindingSource1.DataSource = dtP;
            //dgvProductos.DataSource = bindingSource1;
            dgvProductos.DataSource = dtP;
            sum = dtP.AsEnumerable().Sum(dr => dr.Field<decimal>("Peso"));
            lblPesoProducido.Text = sum.ToString();
            dgvProductos.Sort(dgvProductos.Columns["Posicion"], ListSortDirection.Ascending);
            Simulacion();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            //Simulacion();

        }
        void Simulacion()
        {
            oOrden = new Orden() { OrdenId = lblOrden.Text, Fecha = DateTime.Now };
            CargaConsumido();
            CargaProducido();
            ConsumirMalla();
            dgvConsumido.DataSource = oOrden.ConsumidoPartList;
            decimal sum = oOrden.ConsumidoPartList.Sum(x => x.Peso);
            lblTotalSimulacion.Text = sum.ToString();
            Serializar();
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "BOOMJournal.xml");
        }

        void Consumir()
        {
            IEnumerable<Paquete> ListaConsumo = from paq in oOrden.ConsumidoList
                                                    select paq;

            foreach (Paquete p in oOrden.ProducidoList)
            {
                if (ListaConsumo.Count() == i)
                {
                    MessageBox.Show("No existe suficiente materia prima para " + p.PaqueteId);
                }
                else
                {
                    Producir(1, p, p.Peso, ListaConsumo.ElementAt(pivotHr).Peso, ListaConsumo, pivotHr);
                }
            }
        }

        void ConsumirMalla()
        {
            decimal TRPorc = 0.49M, HrPorc = 0.51M;
 
            IEnumerable<Paquete> ListaTransversal = from paq in oOrden.ConsumidoList 
                           where paq.Machine  == "TR"
                           select paq;
            IEnumerable<Paquete> ListaHorizontal = from paq in oOrden.ConsumidoList
                           where paq.Machine != "TR"
                           select paq;
           
            //var sortedPoints = ListaTransversal.OrderBy(paq => paq.PaqueteId);
            //foreach (var p in sortedPoints)
            //    Console.WriteLine(p.PaqueteId);

            foreach (Paquete p in oOrden.ProducidoList)
            {
                decimal porcHR = p.Peso * HrPorc;
                decimal porcTR = p.Peso  * TRPorc;
                if (ListaHorizontal.Count() == pivotHr | ListaTransversal.Count() == pivotTr)
                {
                    MessageBox.Show ("No existe suficiente materia prima para "+p.PaqueteId);
                }
                else
                {
                    Producir(1, p, porcHR,ListaHorizontal.ElementAt(pivotHr).Peso, ListaHorizontal,pivotHr);
                    Producir(2, p, porcTR, ListaTransversal.ElementAt(pivotTr).Peso, ListaTransversal, pivotTr);
                }
            }
 
        }
        void Producir(int tipo,Paquete p, decimal Producto, decimal Consumo, IEnumerable<Paquete> lista, int indiceLista)
        {
            i = indiceLista;

            Paquete c = lista.ElementAt(i);
            Console.WriteLine(lista.ElementAt(i).ToString() + "," + Consumo.ToString());
            if (Producto > 0 && Consumo > 0)
            {
                if (Producto > Consumo)
                {
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = Consumo, Colada = c.Colada, NumSerie = c.NumSerie };
                    oOrden.ConsumidoPartList.Add(cons);
                    Producto -= Consumo;
                    Consumo = 0;
                    if (tipo == 1)
                    {
                        pivotHr++;
                    }
                    else
                    {
                        pivotTr++;
                    }
                    i++;
                    //Adicionar Linea Consumido
                    //Seleccionar siguiente Consumo
                    if (lista.Count() > i)
                        Producir(tipo, p, Producto, lista.ElementAt(i).Peso, lista, i);

                }
                else
                {
                    lista.ElementAt(i).Peso -= Producto;
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = Producto, Colada = c.Colada, NumSerie = c.NumSerie };
                    oOrden.ConsumidoPartList.Add(cons);

                    Producto = 0;
                    Console.WriteLine("Resto Consumo:" + lista.ElementAt(i).ToString());
                    //Adicionar Linea Consumido
                }

            }
            else
            {
                if (Consumo > 0)
                    MessageBox.Show(Consumo.ToString());
                return;
            }

        }

        void CargaConsumido()
        {
            //CProducido cProducto;
            //Producido producto;
            Paquete p;
            DataTable dt = (DataTable)dgvConsumos.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                p = new Paquete();
                p.PaqueteId = dr["FCS_BATCH_LABEL_1"].ToString();
                //cProducto = new CProducido();
                //producto = cProducto.TraerProducido(p.PaqueteId);

                p.Peso = Convert.ToDecimal(dr["Cantidad_Consumida"]);
                p.Item = dr["Item"].ToString();
                p.Unidad = ConvertirUnidad(dr["AXUnitMeasure"].ToString());
                p.Ax_Item = dr["AxCode"].ToString();
                p.Colada = dr["Colada"].ToString();
                p.Stock = Convert.ToDecimal(dr["Cantidad_consumida"]);
                p.Machine = Convert.ToString(dr["FCS_MACHINE"]);
                string Seguimiento = dr["AXTrackingType"].ToString();
                if (Seguimiento == "SE-LO")
                    p.NumSerie = dr["NumSerie"].ToString();
                else
                    p.NumSerie = string.Empty;
                oOrden.ConsumidoList.Add(p);
                p = null;
                //producto = null;
            }
        }
        //void CargaConsumido() 
        //{
        //    //CProducido cProducto;
        //    //Producido producto;
        //    Paquete p;
        //    DataTable dt=(DataTable)dgvConsumos.DataSource;
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        p = new Paquete();
        //        p.PaqueteId = dr["Origen"].ToString();
        //        //cProducto = new CProducido();
        //        //producto = cProducto.TraerProducido(p.PaqueteId);

        //        p.Peso = Convert.ToDecimal(dr["Cantidad"]);
        //        p.Item = dr["Item"].ToString();
        //        p.Unidad = ConvertirUnidad(dr["AXUnitMeasure"].ToString());
        //        p.Ax_Item = dr["AxCode"].ToString();
        //        p.Colada =dr["Colada"].ToString();
        //        p.Stock = Convert.ToDecimal(dr["Cantidad"]);
        //        p.Machine = Convert.ToString(dr["FCS_MACHINE"]);
        //        string Seguimiento=dr["AXTrackingType"].ToString();
        //        if (Seguimiento== "SE-LO")
        //            p.NumSerie = dr["NumSerie"].ToString();
        //        else
        //            p.NumSerie = string.Empty;
        //        oOrden.ConsumidoList.Add(p);
        //        p = null;
        //        //producto = null;
        //    }
        //}
        //void CargaProducido()
        //{
        //    Paquete p;
        //    for (int i=1;i<=dgvProductos.RowCount-1;i++)
        //    {
        //        dgvProductos.CurrentCell.Selected
        //        DataRow dr=dgvProductos.se
        //        p = new Paquete();
        //        p.PaqueteId = dr["Paquete"].ToString();
        //        p.Peso = Convert.ToDecimal(dr["Peso"]);
        //        p.Piezas = Convert.ToInt32(dr["Piezas"]);
        //        p.Item = dr["Item"].ToString();
        //        p.Unidad = dr["AXUnitMeasure"].ToString();
        //        p.Ax_Item = dr["AxCode"].ToString();
        //        p.Stock = Convert.ToDecimal(dr["Peso"]);
        //        oOrden.ProducidoList.Add(p);
        //        p = null;
        //    }
        //}
        void CargaProducido()
        {
            Paquete p;
            DataTable dt = (DataTable)dgvProductos.DataSource;
            //dt.DefaultView.Sort = "Posicion asc";
            foreach (DataRow dr in dt.Rows)
            {
                p = new Paquete();
                p.PaqueteId = dr["Paqueteid"].ToString();
                p.Peso = Convert.ToDecimal(dr["Peso"]);
                p.Piezas = Convert.ToInt32(dr["Piezas"]);
                p.Item = dr["Item"].ToString();
                p.Unidad = ConvertirUnidad(dr["AXUnitMeasure"].ToString());
                p.Ax_Item = dr["AxCode"].ToString();
                p.Colada = dr["Colada"].ToString();
                p.Stock = Convert.ToDecimal(dr["Peso"]);
                p.Centro = dr["Centro_trabajo"].ToString();
                p.Issue = dr["Calidad"].ToString();
                p.CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
                p.CostoPaquete = Convert.ToDecimal(dr["CostoTotal"]);
                oOrden.ProducidoList.Add(p);
                p = null;
            }
        }
        //void CargaProducido()
        //{
        //    Paquete p;
        //    DataTable dt = (DataTable)dgvProductos.DataSource;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        p = new Paquete();
        //        p.PaqueteId = dr["Paquete"].ToString();
        //        p.Peso = Convert.ToDecimal(dr["Peso"]);
        //        p.Piezas = Convert.ToInt32(dr["Piezas"]);
        //        p.Item =dr["Item"].ToString();
        //        p.Unidad = ConvertirUnidad (dr["AXUnitMeasure"].ToString());
        //        p.Ax_Item = dr["AxCode"].ToString();
        //        p.Colada = dr["Colada"].ToString();
        //        p.Stock = Convert.ToDecimal(dr["Peso"]);
        //        p.Centro=dr["Centro"].ToString();
        //        oOrden.ProducidoList.Add(p);
        //        p = null;
        //    }
        //}
        public void Serializar()
        {
            foreach (Paquete p in oOrden.ProducidoList)
            {
                var ft = new FTBOOMJournal() { DocPurpose = "Original", SenderId = "FERP" };
                var iTable = new InventJournalTable();
                iTable.Description = "Inventory Boom Journal";
                iTable.JournalNameId = "IBOM";
                iTable.NumOfLines = oOrden.ConsumidoPartList.Count + 1;
                iTable.InventJournalTransList.Add(ObtenerProducido(p));
                ////for (int i = 0; i <= dgvConsumido.Rows.Count - 1; i++)
                ////{
                ////    var iTrans = new InventJournalTrans();
                ////    iTrans.BOMLine = "YES";
                ////    iTrans.CostAmount = 0.00;
                ////    iTrans.CostPrice = 10.00;
                ////    iTrans.ItemId = "0001";
                ////    iTrans.LineNum = i + 1;
                ////    iTrans.PriceUnit = 1.00;
                ////    iTrans.Qty = (double)dgvConsumido.Rows[i + 1].Cells[6].Value;
                ////    iTrans.TransDate = DateTime.Now;
                ////    for (int j = 0; j <= 3; j++)
                ////    {
                ////        var iDim = new InventDim();
                ////        iDim.InventLocationId = "CONSUMO";
                ////        iDim.InventSiteId = "FERR-PRO";
                ////        iDim.InventStatusId = "Disponible";
                ////        iDim.LicensePlateID = "080916G2003";
                ////        iDim.WMSLocationId = "SCZ-PDV-PR";
                ////        iTrans.InventDimList.Add(iDim);
                ////    }
                ////    iTable.InventJournalTransList.Add(iTrans);
                ////}
                ft.InventJournalTable=iTable;
                //var stream = new FileStream("BOOMJournal.xml", FileMode.Create);
                //new XmlSerializer(typeof(FTBOOMJournal)).Serialize(stream, ft);
                //stream.Close();
                //webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "BOOMJournal.xml");
            }
        }

        public void Serializar(string paquete)
        {
            Paquete p = oOrden.ProducidoList.Find(x => x.PaqueteId == paquete);
            IEnumerable<Consumo> resultado = from prod in oOrden.ConsumidoPartList
                                                where prod.PaqProducido == paquete
                                                select prod;
            decimal i = 0;
            var ft = new FTBOOMJournal() { DocPurpose = "Original", SenderId = "FERP" };
            var iTable = new InventJournalTable();
            iTable.Description = "Inventory Boom Journal";
            iTable.JournalNameId = "IBOM";
            iTable.NumOfLines = resultado.Count() + 2;
            iTable.InventJournalTransList.Add(ObtenerProducido(p));
            i++;
            foreach (Consumo c in resultado)
            {
                i++;
                var iTrans = new InventJournalTrans();
                iTrans.BOMLine = "YES";
                iTrans.CostAmount = 0.00M;
                iTrans.CostPrice = 0.00M;
                iTrans.ItemId = c.Ax_Item;
                iTrans.LineNum = i;
                iTrans.PriceUnit = 1.00M;
                iTrans.Qty = Convert.ToDecimal(string.Format("{0:F2}", c.Peso*-1));
                DateTime dt = DateTime.Today;
                string newDt = dt.ToString("yyyy-MM-dd");
                iTrans.TransDate = newDt;
                //for (int j = 0; j <= 3; j++)
                //{
                var iDim = new InventDim();
                iDim.InventBatchId = c.Colada;
                iDim.InventLocationId = oSuc.Id_AX;
                iDim.InventSerialId = c.NumSerie;
                iDim.InventSiteId = "FERR-PRO";
                iDim.InventStatusId = "Disponible";
                iDim.LicensePlateID = c.PaqConsumido;
                iDim.WMSLocationId = "CONSUMO";
                iTrans.InventDim = iDim;
                //iTrans.InventDimList.Add(iDim);
                //}
                iTable.InventJournalTransList.Add(iTrans);
            }
            iTable.InventJournalTransList.Add(ObtenerCostoProducido (p,i));
            ft.InventJournalTable = iTable;
 
            PruebaXML2(ft);
            ////RECUPERAMOS EL XML

            //FTBomJournalSendXML.CallContext callContext = new FTBomJournalSendXML.CallContext();
            //FTBomJournalSendXML.FTSendXmlBomJournalServiceClient servClient = new FTBomJournalSendXML.FTSendXmlBomJournalServiceClient();

            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"d:\tempax\temp1.xml");
            //String XMLasString = doc.OuterXml;

            ////SETEAMOS LA COMPANIA Y CREAMOS UN ID DE MSJ
            //callContext.Company = "FERP";
            //callContext.MessageId = Guid.NewGuid().ToString(); 
            //try 
            //{
            //    //servClient.SendXml(callContext, XMLasString);
            //    GuardarPaquete(p);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    System.Console.WriteLine(e.Message);
            //    System.Console.ReadLine();
            //}
        }
        private InventJournalTrans ObtenerProducido(Paquete p)
        {
            var iTrans = new InventJournalTrans();
            iTrans.BOMLine = "NO";
            iTrans.CostAmount = 0.00M ;
            iTrans.CostPrice = 0.00M;
            iTrans.ItemId = p.Ax_Item+"|"+ p.Unidad;
            iTrans.LineNum = 1;
            iTrans.PriceUnit = 1.00M ;
            if (p.Unidad=="kg")
                iTrans.Qty = Convert.ToDecimal(string.Format("{0:F2}", p.Peso));
            else
                iTrans.Qty = Convert.ToDecimal(string.Format("{0:F2}", p.Piezas));
            DateTime dt = DateTime.Today;
            string newDt = dt.ToString("yyyy-MM-dd");

            iTrans.TransDate = newDt;
            var iDim = new InventDim();
            iDim.InventBatchId = p.Colada;
            iDim.InventLocationId = oSuc.Id_AX;
            iDim.InventSerialId = "";
			iDim.InventSiteId="FERR-PRO";
		    iDim.InventStatusId="Disponible";
			iDim.LicensePlateID=p.PaqueteId;
            iDim.WMSLocationId = "FINALIZADO";
            iTrans.InventDim=iDim;
            return iTrans;
        }

        private InventJournalTrans ObtenerCostoProducido(Paquete p,decimal Linea)
        {
            CCentroTrabajo cc=new CCentroTrabajo();
            CentroTrabajo oC;
            oC = cc.TraerCentroTrabajo(p.Centro);
            decimal PrecioKg = oC.PrecioTon / 1000;
            decimal PrecioPaq = 0;
            if (p.Unidad == "kg")
            {
                PrecioPaq = p.Peso * PrecioKg;
            }
            else
            {
                decimal kgxPza = p.Peso / p.Piezas;
                decimal PrecioPza = kgxPza * PrecioKg;
                PrecioPaq = PrecioPza * p.Piezas;
            }
            var iTrans = new InventJournalTrans();
            iTrans.BOMLine = "YES";
            iTrans.Qty = -1.00M;
            iTrans.CostPrice = Convert.ToDecimal(string.Format("{0:F2}", PrecioPaq));
            iTrans.CostAmount = iTrans.Qty*iTrans.CostPrice;
            iTrans.ItemId = "MO" + "|UND";
            iTrans.LineNum = Linea++;
            iTrans.PriceUnit = 1.00M;
            DateTime dt = DateTime.Today;
            string newDt = dt.ToString("yyyy-MM-dd");

            iTrans.TransDate = newDt;
            var iDim = new InventDim();
            iDim.InventBatchId = "";
            iDim.InventLocationId = oSuc.Id_AX;
            iDim.InventSerialId = "";
            iDim.InventSiteId = "FERR-PRO";
            iDim.InventStatusId = string.Empty;
            iDim.LicensePlateID = string.Empty;
            iDim.WMSLocationId = string.Empty;
            iTrans.InventDim = iDim;
            //iTrans.InventDimList.Add(iDim);
            return iTrans;
        }

        private void GuardarPaquete(Paquete p)
        {
            Paquetes oP = new Paquetes();
            CPaquetes cP;
            oP.AlmacenId = 1;
            oP.CeldaId="";
            oP.Centro = p.Centro;
            oP.Colada = p.Colada;
            oP.Contenedor = "";
            oP.Fecha = DateTime.Now;
            oP.ItemId = p.Item;
            oP.Login = "";
            oP.Nivel = 0;
            oP.OrdenId = strOrden;
            oP.PaqueteId = p.PaqueteId;
            oP.Peso = p.Peso;
            oP.Piezas = p.Piezas;
            oP.status = "ACTIVO";
            oP.SucursalId = iSucursal;
            cP = new CPaquetes();
            cP.GuardarPaquetes(oP);
        }

        string ConvertirUnidad(string u)
        {
            string unidad="";
            switch (u)
            {
                case "KGS": 
                    unidad="kg";
                    break;
                case "PZA":
                    unidad="pcs";
                    break;
                case "MTS":
                    unidad="m";
                    break;
            }
            return unidad;
        }

        //private InventJournalTrans ObtenerConsumido(Paquete p)
        //{
        //    var iTrans = new InventJournalTrans();
        //    iTrans.BOMLine = "NO";
        //    iTrans.CostAmount = 0.00M;
        //    iTrans.CostPrice = 1.00M;
        //    iTrans.ItemId = p.Ax_Item;
        //    iTrans.LineNum = Convert.ToDecimal(1);
        //    iTrans.PriceUnit = 1.00M;
        //    iTrans.Qty = Convert.ToDecimal(p.Peso);
        //    DateTime dt = DateTime.Today;
        //    string newDt = dt.ToString("yyyy-MM-dd");
        //    iTrans.TransDate = newDt;
        //    var iDim = new InventDim();
        //    iDim.InventBatchId = "";
        //    iDim.InventLocationId = "CONSUMO";
        //    iDim.InventSerialId = "";
        //    iDim.InventSiteId = "FERR-PRO";
        //    iDim.InventStatusId = "Disponible";
        //    iDim.LicensePlateID = p.PaqueteId;
        //    iDim.WMSLocationId = "SCZ-PDV-PR";
        //    iTrans.InventDim=iDim;
        //    //iTrans.InventDimList.Add(iDim);
        //    return iTrans;
        //}
        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow.Index > 1)
            {
                int filaActual = dgvProductos.CurrentRow.Index;
                int filaDestino = dgvProductos.CurrentRow.Index - 1;
                DataRow dr = dtP.NewRow();
                DataGridViewRow rw = dgvProductos.CurrentRow;
//                DataGridViewRow dgrDest = dgvProductos.Rows[dgvProductos.CurrentCell.RowIndex - 1];
                dgvProductos.Rows.RemoveAt(filaActual);
                dgvProductos.Rows.Insert(filaDestino, rw);
            }
        }
        void Mostrar()
        {
            DataTable dt = (DataTable)dgvProductos.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[2]);
            }
        }

        private void frmSimulacion_Load(object sender, EventArgs e)
        {
            //DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            //colBotones.Name = "colBotones";
            //colBotones.HeaderText = "XML";

            //this.dgvProductos.Columns.Add(colBotones);
            ReDimensionar();
            CargarOrden();
            //Simulacion();
        }

        private void frmSimulacion_Resize(object sender, EventArgs e)
        {
            ReDimensionar();
        }

        void ReDimensionar()
        {
            btnSalir.Left = this.Width - btnSalir.Width - 20;
            lblPesoProducido.Left = dgvProductos.Width - lblPesoProducido.Width - 20;
            lblPesoConsumido.Left = dgvConsumos.Width - lblPesoConsumido.Width - 20;
            lblTotalSimulacion.Left = dgvConsumido.Width - lblTotalSimulacion.Width - 50;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvProductos.Columns[e.ColumnIndex].Name == "colBotones" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgvProductos.Rows[e.RowIndex].Cells["colBotones"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\iconos\ok.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dgvProductos.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgvProductos.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        try
                        {
                            CPaquetes cP = new CPaquetes();
                            Paquetes p = new Paquetes();
                            if (cP.BuscarPaquetes(strPaquete))
                                throw new Exception("Paquete ya ha sido integrado");
                                
                            Serializar(strPaquete);
                            //webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "BOOMJournal.xml");
                            webBrowser1.Navigate(@"d:\temp1.xml");
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count > 0)
                strPaquete = dgvProductos.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //DataGridViewColumn selectedColumn = dgvProductos.Columns[e.ColumnIndex];
            
           //ListSortDirection direction;

           //if (sortedDescending == false)
           //{
           //   direction = ListSortDirection.Descending;
           //   sortedDescending = true;
           //}
           //else
           //{
           //   direction = ListSortDirection.Ascending;
           //   sortedDescending = false;
           //}

           //dgvProductos.Sort(selectedColumn, direction);

           //selectedColumn.HeaderCell.SortGlyphDirection =
           //direction == ListSortDirection.Ascending ?
           //SortOrder.Ascending : SortOrder.Descending;
        }
        public void PruebaXML2(FTBOOMJournal ft)
        {
            XNamespace aw = "http://schemas.microsoft.com/dynamics/2008/01/documents/FTBOOMJournal";
            XmlDocument docXml = new XmlDocument();
            XmlNode nodoDoc = docXml.CreateXmlDeclaration("1.0", "UTF-8", null);

            // Inserción del nodo reciénd creado al documento:
            docXml.AppendChild(nodoDoc);

            // Creación e inserción de nuevo nodo:
            XmlNode nodoFTBoomJournal = docXml.CreateElement(string.Empty, "FTBOOMJournal", string.Empty + aw);
            docXml.AppendChild(nodoFTBoomJournal);
            XmlNode ElementBoomJournal = docXml.CreateElement("DocPurpose", string.Empty + aw);
            ElementBoomJournal.AppendChild(docXml.CreateTextNode("Original"));
            nodoFTBoomJournal.AppendChild(ElementBoomJournal);
            ElementBoomJournal = docXml.CreateElement("SenderId", string.Empty + aw);
            ElementBoomJournal.AppendChild(docXml.CreateTextNode("FERP"));
            nodoFTBoomJournal.AppendChild(ElementBoomJournal);

            // Creación de un nodo anidado:
            XmlNode InventJournalTable = docXml.CreateElement("InventJournalTable", string.Empty + aw);
            XmlAttribute atributoInventJournalTable = docXml.CreateAttribute("class");
            atributoInventJournalTable.Value = "entity";
            InventJournalTable.Attributes.Append(atributoInventJournalTable);
            XmlNode ElementTable = docXml.CreateElement("Description", string.Empty + aw);
            ElementTable.AppendChild(docXml.CreateTextNode("Inventory Boom Journal"));
            InventJournalTable.AppendChild(ElementTable);
            ElementTable = docXml.CreateElement("JournalNameId", string.Empty + aw);
            ElementTable.AppendChild(docXml.CreateTextNode("IBOM"));
            InventJournalTable.AppendChild(ElementTable);
            ElementTable = docXml.CreateElement("NumOfLines", string.Empty + aw);
            ElementTable.AppendChild(docXml.CreateTextNode(ft.InventJournalTable.NumOfLines.ToString()));
            InventJournalTable.AppendChild(ElementTable);
            int i = 0;
            foreach(InventJournalTrans tr in ft.InventJournalTable.InventJournalTransList)
            {
                i++;
                XmlNode nodoInventJournalTrans = docXml.CreateElement("InventJournalTrans", string.Empty + aw);
                XmlAttribute atributoInventJournalTrans = docXml.CreateAttribute("class");
                atributoInventJournalTrans.Value = "entity";
                nodoInventJournalTrans.Attributes.Append(atributoInventJournalTrans);
                InventJournalTable.AppendChild(nodoInventJournalTrans);
                XmlNode ElementTrans = docXml.CreateElement("BOMLine", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.BOMLine));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("CostAmount", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.CostAmount.ToString()));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("CostPrice", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.CostPrice.ToString()));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("ItemId", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.ItemId));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("LineNum", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(i.ToString()));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("PriceUnit", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.PriceUnit.ToString()));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("Qty", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.Qty.ToString()));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("TransDate", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.TransDate));
                nodoInventJournalTrans.AppendChild(ElementTrans);

                XmlNode InventDim = docXml.CreateElement("InventDim", string.Empty + aw);
                XmlAttribute atributoInventDim = docXml.CreateAttribute("class");
                atributoInventDim.Value = "entity";
                InventDim.Attributes.Append(atributoInventDim);
                nodoInventJournalTrans.AppendChild(InventDim);
                XmlNode Element = docXml.CreateElement("InventBatchId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.InventBatchId));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "InventLocationId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.InventLocationId));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "InventSerialId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.InventSerialId));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "InventSiteId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.InventSiteId));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "InventStatusId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.InventStatusId));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "LicensePlateID", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.LicensePlateID));
                InventDim.AppendChild(Element);
                Element = docXml.CreateElement(string.Empty, "WMSLocationId", string.Empty + aw);
                Element.AppendChild(docXml.CreateTextNode(tr.InventDim.WMSLocationId));
                InventDim.AppendChild(Element);
                nodoFTBoomJournal.AppendChild(InventJournalTable);
            }
            // Muestra el contenido del archivo en la salida estándar:
            //docXml.Save(@"AppDomain.CurrentDomain.BaseDirectory + "BOOMJournal.xml"
            docXml.Save(@"d:\tempax\temp1.xml");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
