using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRN.Componentes;
using Entidades;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using CRN.Entidades;
using System.Globalization;

namespace WFConsumo
{
    public partial class frmVerDetalle : Form
    {
        const decimal tc = 6.96M;
        string strOrden, strPaquete, strCentro;
        int iSucursal;
        int i = 0, j = 0, pivotHr = 0, pivotTr = 0;
        Consumo cons;
        CSucursal cSuc;
        Sucursal oSuc;
        CMovProducido cProd;
        CMovConsumido cCsmd;
        MovConsumido csmd;
        Orden oOrden;
        DataTable dtP, dtC;
        CCentroTrabajo cc = new CCentroTrabajo();
        CentroTrabajo oC;
        bool EnvioOK = false;
        public frmVerDetalle(int Sucursal, string centro,string sOrden)
        {
            iSucursal = Sucursal;
            cSuc = new CSucursal();
            oSuc = cSuc.TraerSucursal(Sucursal);
            strOrden=sOrden;
            strCentro = centro;
            oC = cc.TraerCentroTrabajo(strCentro);
            InitializeComponent();
        }

        private void CargarOrden()
        {
            CargarConsumos();
            CargarProductos();
            Simulacion();
        }
        private void CargarConsumos()
        {
            DataSet ds;
            lblOrden.Text = strOrden;
            cCsmd = new CMovConsumido();
            ds = cCsmd.TraerTodosMovConsumido(strCentro, strOrden);
            dtC = ds.Tables[0];
            dgvConsumos.DataSource = dtC;
            var sum = dtC.AsEnumerable().Sum(dr => dr.Field<decimal>("Cantidad_Consumida"));
            lblPesoConsumido.Text = sum.ToString();
        }
        private void CargarProductos()
        {
            DataSet ds;
            cProd = new CMovProducido();
            ds = cProd.TraerTodosMovProducido(strOrden);
            dtP = ds.Tables[0];
            dgvProductos.DataSource = dtP;
            var sum = dtP.AsEnumerable().Sum(dr => dr.Field<decimal>("Peso"));
            var Costo = dtP.AsEnumerable().Sum(dr => dr.Field<decimal>("CostoTotal"));
            lblPesoProducido.Text = sum.ToString();
            lblTotCosto.Text = Costo.ToString();
            dgvProductos.Sort(dgvProductos.Columns["Posicion"], ListSortDirection.Ascending);
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Cells["STATUS"].Value.ToString() == "OPEN")
                    fila.DefaultCellStyle.BackColor = Color.White;
                else
                    fila.DefaultCellStyle.BackColor = Color.Wheat;
            }

        }
        private void frmVerDetalle_Load(object sender, EventArgs e)
        {
            ReDimensionar();
            CargarOrden();
            //Simulacion();
        }

        void Simulacion()
        {
            oOrden = new Orden() { OrdenId = lblOrden.Text, Fecha = DateTime.Now };
            CargaConsumido();
            CargaProducido();
            if (strCentro=="MALLA01")
                ConsumirMalla();
            else
                Consumir();
            dgvConsumido.DataSource = oOrden.ConsumidoPartList;
            decimal sum = oOrden.ConsumidoPartList.Sum(x => x.Peso);
            lblTotalSimulacion.Text = sum.ToString();
            CalculoCosto();
        }

        void CargaProducido()
        {
            oOrden.ProducidoList = null;
            oOrden.ProducidoList = new List<Paquete>();
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
                p.CostoPaquete  = Convert.ToDecimal(dr["CostoTotal"]);
                p.Status= dr["Status"].ToString();
                oOrden.ProducidoList.Add(p);
                p = null;
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

        void Consumir()
        {
            IEnumerable<Paquete> ListaConsumo = from paq in oOrden.ConsumidoList
                                                select paq;
            i = 0;
            pivotHr = 0;

            foreach (Paquete p in oOrden.ProducidoList)
            {
                if (ListaConsumo.Count() == i)
                {
                    MessageBox.Show("No existe suficiente materia prima para " + p.PaqueteId);
                    EnvioOK = false;
                }
                else
                {
                    Producir(1, p, p.Peso-Math.Round((p.Peso*oC.PorcDispersion/100),2), ListaConsumo.ElementAt(pivotHr).Peso,ref ListaConsumo, pivotHr);
                    EnvioOK = true;
                    //Producir(1, p, p.Peso, ListaConsumo.ElementAt(pivotHr).Peso, ref ListaConsumo, pivotHr);
                }
            }
            //MostrarListaMateriaPrima();
            IEnumerable<Paquete> ListaSobrantes = from paq in oOrden.ConsumidoList
                                                    where paq.Peso > 0
                                                    select paq;
            if (ListaSobrantes.Count() > 0)
            {
                Paquete p = oOrden.ProducidoList.Last();
                foreach (Paquete c in ListaSobrantes)
                {
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = c.Peso, Colada = c.Colada, NumSerie = c.NumSerie };
                    ListaConsumo.ElementAt(pivotHr).Peso = 0;
                    oOrden.ConsumidoPartList.Add(cons);
                }
            }
                 
        }

        void ConsumirMalla()
        {
            decimal TRPorc = 0.49M, HrPorc = 0.51M;

            IEnumerable<Paquete> ListaTransversal = from paq in oOrden.ConsumidoList
                                                    where paq.Machine == "TR"
                                                    select paq;
            IEnumerable<Paquete> ListaHorizontal = from paq in oOrden.ConsumidoList
                                                   where paq.Machine != "TR"
                                                   select paq;

            //var sortedPoints = ListaTransversal.OrderBy(paq => paq.PaqueteId);
            //foreach (var p in sortedPoints)
            //    Console.WriteLine(p.PaqueteId);
            pivotHr = 0;
            pivotTr = 0;

            foreach (Paquete p in oOrden.ProducidoList)
            {
                decimal porcHR = p.Peso * HrPorc;
                decimal porcTR = p.Peso * TRPorc;
                if (ListaHorizontal.Count() == pivotHr | ListaTransversal.Count() == pivotTr)
                {
                    MessageBox.Show("No existe suficiente materia prima para " + p.PaqueteId);
                    EnvioOK = false;
                }
                else
                {
                    Producir(1, p, porcHR, ListaHorizontal.ElementAt(pivotHr).Peso,ref ListaHorizontal, pivotHr);
                    Producir(2, p, porcTR, ListaTransversal.ElementAt(pivotTr).Peso,ref ListaTransversal, pivotTr);
                    EnvioOK = true;
                }
            }
            IEnumerable<Paquete> ListaSobrantesHr = from paq in ListaHorizontal
                                                    where paq.Peso > 0 && paq.Machine!="TR"
                                                  select paq;
            if (ListaSobrantesHr.Count() > 0)
            {
                Paquete p = ListaHorizontal.Last();
                foreach (Paquete c in ListaSobrantesHr)
                {
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = c.Peso, Colada = c.Colada, NumSerie = c.NumSerie };
                    ListaHorizontal.ElementAt(pivotHr).Peso = 0;
                    oOrden.ConsumidoPartList.Add(cons);
                }
            }
            IEnumerable<Paquete> ListaSobrantesTr = from paq in ListaTransversal
                                                    where paq.Peso > 0 && paq.Machine == "TR"
                                                    select paq;
            if (ListaSobrantesTr.Count() > 0)
            {
                Paquete p = oOrden.ProducidoList.Last();
                foreach (Paquete c in ListaSobrantesTr)
                {
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = c.Peso, Colada = c.Colada, NumSerie = c.NumSerie };
                    ListaTransversal.ElementAt(pivotTr).Peso = 0;
                    oOrden.ConsumidoPartList.Add(cons);
                }
            }

        }

        void MostrarListaMateriaPrima()
        {
            foreach (Paquete p in oOrden.ConsumidoList)
            {
                Console.WriteLine(p.PaqueteId + "," + p.Peso.ToString());
            }
        }

        void Producir(int tipo, Paquete p, decimal PesoProducto, decimal PesoConsumo,ref IEnumerable<Paquete> listaConsumo, int indiceLista)
        {
            i = indiceLista;
            //MostrarListaMateriaPrima();
            Paquete c = listaConsumo.ElementAt(i);
            Console.WriteLine(listaConsumo.ElementAt(i).ToString() + "," + PesoConsumo.ToString());
            if (PesoProducto > 0 && PesoConsumo > 0)
            {
                if (PesoProducto > PesoConsumo)
                {
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = PesoConsumo, Colada = c.Colada, NumSerie = c.NumSerie };
                    oOrden.ConsumidoPartList.Add(cons);
                    PesoProducto -= PesoConsumo;
                    PesoConsumo = 0;
                    listaConsumo.ElementAt(i).Peso = 0;

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
                    if (listaConsumo.Count() > i)
                    {
                        Producir(tipo, p, PesoProducto, listaConsumo.ElementAt(i).Peso, ref listaConsumo, i);
                    }
                }
                else
                {
                    listaConsumo.ElementAt(i).Peso -= PesoProducto;
                    cons = new Consumo() { Orden = oOrden.OrdenId, Item = c.Item, Ax_Item = c.Ax_Item + "|" + c.Unidad, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = PesoProducto, Colada = c.Colada, NumSerie = c.NumSerie };
                    oOrden.ConsumidoPartList.Add(cons);
                    PesoProducto = 0;
                    Console.WriteLine("Resto Consumo:" + listaConsumo.ElementAt(i).ToString());
                    ////Adicionar Linea Consumido
                    if (listaConsumo.ElementAt(i).Peso == 0)
                    {
                        i++;
                        pivotHr++;
                    }
                }

            }
            else
            {
                if (PesoConsumo > 0)
                    MessageBox.Show(PesoConsumo.ToString());
                return;
            }

        }

        public FTBOOMJournal Serializar(string paquete)
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
                iTrans.Qty = Convert.ToDecimal(string.Format("{0:F2}", c.Peso * -1));
                DateTime dt = DateTime.Today;
                string newDt = dt.ToString("yyyy-MM-dd");
                iTrans.TransDate = newDt;

                var iDim = new InventDim();
                iDim.InventBatchId = c.Colada;
                iDim.InventLocationId = oSuc.Id_AX;
                iDim.InventSerialId = c.NumSerie;
                iDim.InventSiteId = "FERR-PRO";
                iDim.InventStatusId = "Disponible";
                iDim.LicensePlateID = c.PaqConsumido;
                iDim.WMSLocationId = "CONSUMO";
                iTrans.InventDim = iDim;

                iTable.InventJournalTransList.Add(iTrans);
            }
            iTable.InventJournalTransList.Add(ObtenerCostoProducido(p, i));
            ft.InventJournalTable = iTable;
            return ft;

            //            PruebaXML2(ft);

            ////Enviar 

            //            Enviar(paquete);
        }

        private bool Enviar(string paquete, out string message)
        {
            bool blnOk = true;
            message = "";
            try
            {
                FTBomJournalSendXML.CallContext callContext = new FTBomJournalSendXML.CallContext();
                FTBomJournalSendXML.FTSendXmlBomJournalServiceClient servClient = new FTBomJournalSendXML.FTSendXmlBomJournalServiceClient();

                XmlDocument doc = new XmlDocument();

                string xmlFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "BOOMJournal.xml");
                doc.Load(xmlFilePath);

                //doc.Load(@"e:\tempax\temp1.xml");
                String XMLasString = doc.OuterXml;

                //SETEAMOS LA COMPANIA Y CREAMOS UN ID DE MSJ
                callContext.Company = "FERP";
                callContext.MessageId = Guid.NewGuid().ToString();
                servClient.SendXml(callContext, XMLasString);
                GuardarSincronizado(paquete);
                CargarProductos();
                blnOk = true;
                return true;
                ////GuardarPaquete(p);
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
                //MessageBox.Show(e.Message);
                //System.Console.WriteLine(e.Message);
                //System.Console.ReadLine();
            }
        }

        private InventJournalTrans ObtenerProducido(Paquete p)
        {
            var iTrans = new InventJournalTrans();
            iTrans.BOMLine = "NO";
            iTrans.CostAmount = 0.00M;
            iTrans.CostPrice = 0.00M;
            iTrans.ItemId = p.Ax_Item + "|" + p.Unidad;
            iTrans.LineNum = 1;
            iTrans.PriceUnit = 1.00M;
            if (p.Unidad == "kg")
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
            iDim.InventSiteId = "FERR-PRO";
            iDim.InventStatusId = "Disponible";
            iDim.LicensePlateID = p.PaqueteId;
            switch (strCentro)
            {
                case "SLI01":
                case "GRAF02":
                case "GRAF03":
                case "TREF02":
                case "TREF03":
                case "EKCLA02":
                case "EKCLA03":
                case "WACLA01":
                case "WAGRA01":
                case "PUL01":
                case "PUL02":
                case "TREF01":
                case "GRAF01":
                    iDim.WMSLocationId = "CONSUMO";
                    break;
                default:
                    iDim.WMSLocationId = "FINALIZADO";
                    break;
            }

            //if (strCentro=="SLI01")
            //    iDim.WMSLocationId = "CONSUMO";
            //else
            //    iDim.WMSLocationId = "FINALIZADO";
            iTrans.InventDim = iDim;
            return iTrans;
        }

        void CalculoCosto()
        {
            decimal PrecioTon=0;
            
            if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorCentroDeTrabajo)
                PrecioTon = oC.PrecioTon;
            else if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorProduccion)
            {
                COrdenSync cOrden=new COrdenSync();
                Decimal Diametro = cOrden.ObtenerDiametroOrden(strOrden);
                CMedidaPrecio cMP = new CMedidaPrecio();
                MedidaPrecio oMP;
                oMP = cMP.TraerMedidaPrecio(strCentro,Diametro);

                PrecioTon = oMP.PrecioTon;
            }
            else if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorProduccion)
                PrecioTon = 0;

            lblPrecioTonelada.Text = PrecioTon.ToString();
            decimal PrecioKg = PrecioTon / 1000;
            decimal sumaPeso = oOrden.ProducidoList.Sum(item => item.Peso);
            lblTotalPeso.Text = sumaPeso.ToString();

            decimal sumaPiezas = oOrden.ProducidoList.Sum(item => item.Piezas);
            lblTotalPiezas.Text = sumaPiezas.ToString();
            var query = from item in oOrden.ProducidoList
                        group item by new { calidad = item.Issue } into g
                        select new
                        {
                            Key = g.Key,
                            TotPiezas = g.Sum(x => x.Piezas),
                            TotPeso= g.Sum(x => x.Peso)
                        };
            decimal CostoTotal=0,CostoPrimera=0, CostoSegunda=0, TotalCostoSegunda=0;
            decimal KgsPrimera = 0;
            int PiezasPrimera=0;
            CostoTotal = PrecioKg * sumaPeso;

            foreach (var item in query)
            {
                if (item.Key.calidad == "GOOD")
                {
                    PiezasPrimera = item.TotPiezas;
                    KgsPrimera = item.TotPeso;
                }
                else
                {
                    CostoSegunda = (0.01M*item.TotPeso);
                    TotalCostoSegunda+= CostoSegunda;
                }
            }
            CostoPrimera = CostoTotal - TotalCostoSegunda;
            lblCostoTotal.Text = CostoTotal.ToString();
            lblPiezasPrimera.Text = PiezasPrimera.ToString();
            lblKgsPrimera.Text = KgsPrimera.ToString();
            lblCostoPrimera.Text = CostoPrimera.ToString();
            lblCostoSegunda.Text = TotalCostoSegunda.ToString();

        }
        
        private InventJournalTrans ObtenerCostoProducido(Paquete p, decimal Linea)
        {
            var iTrans = new InventJournalTrans();
            iTrans.BOMLine = "YES";
            iTrans.Qty = -1.00M;
            //iTrans.CostPrice = Convert.ToDecimal(string.Format("{0:F2}", PrecioPaq));
            //iTrans.CostAmount = iTrans.Qty * iTrans.CostPrice;
            iTrans.CostPrice = Convert.ToDecimal(string.Format("{0:F2}", p.CostoUnitario * tc));
            iTrans.CostAmount = Convert.ToDecimal(string.Format("{0:F2}",p.CostoPaquete * -tc));
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

        private void GuardarSincronizado(string Paquete)
        {
            cProd = new CMovProducido();
            MovProducido oProd;
            oProd = cProd.TraerMovProducido(Paquete);
            oProd.STATUS = "SYNC";
            cProd.ModificarMovProducido(oProd);
        }

        private void GuardarPaquete(Paquete p)
        {
            Paquetes oP = new Paquetes();
            CPaquetes cP;
            oP.AlmacenId = 1;
            oP.CeldaId = "";
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
            ElementTable.AppendChild(docXml.CreateTextNode(ft.InventJournalTable.NumOfLines.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
            InventJournalTable.AppendChild(ElementTable);
            int i = 0;
            foreach (InventJournalTrans tr in ft.InventJournalTable.InventJournalTransList)
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
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.CostAmount.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("CostPrice", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.CostPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("ItemId", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.ItemId));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("LineNum", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(i.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("PriceUnit", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.PriceUnit.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
                nodoInventJournalTrans.AppendChild(ElementTrans);
                ElementTrans = docXml.CreateElement("Qty", string.Empty + aw);
                ElementTrans.AppendChild(docXml.CreateTextNode(tr.Qty.ToString(CultureInfo.CreateSpecificCulture("en-US"))));
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
            string xmlFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "BOOMJournal.xml");
            docXml.Save(xmlFilePath);

            //docXml.Save(@"e:\tempax\temp1.xml");
        }

        string ConvertirUnidad(string u)
        {
            string unidad = "";
            switch (u)
            {
                case "KGS":
                    unidad = "kg";
                    break;
                case "PZA":
                    unidad = "pcs";
                    break;
                case "MTS":
                    unidad = "m";
                    break;
                default:
                    unidad = u;
                    break;
            }
            return unidad;
        }

        void ReDimensionar()
        {
            btnSalir.Left = this.Width - btnSalir.Width - 20;
            //lblPesoProducido.Left = dgvProductos.Width - lblPesoProducido.Width - 20;
            //lblPesoConsumido.Left = dgvConsumos.Width - lblPesoConsumido.Width - 20;
            lblTotalSimulacion.Left = dgvConsumido.Width - lblTotalSimulacion.Width - 50;
        }

        private void frmVerDetalle_Resize(object sender, EventArgs e)
        {
            ReDimensionar();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        try
                        {
                            //CPaquetes cP = new CPaquetes();
                            //Paquetes p = new Paquetes();

                            //if (cP.BuscarPaquetes(strPaquete))
                            if(this.dgvProductos.Rows[e.RowIndex].Cells["STATUS"].Value.ToString()=="SYNC")
                                throw new Exception("Paquete ya ha sido integrado");

                            FTBOOMJournal ft = Serializar(strPaquete);
                            PruebaXML2(ft);
                            string message;
                            if (!Enviar(strPaquete, out message))
                                MessageBox.Show(message);
                            else
                                MessageBox.Show("Enviado");

                            //webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "BOOMJournal.xml");
                            //webBrowser1.Navigate(@"d:\temp1.xml");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (EnvioOK)
            {
                CargaProducido();
                foreach (Paquete p in oOrden.ProducidoList)
                {
                    try
                    {
                        if (p.Status == "OPEN")
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            FTBOOMJournal ft = Serializar(p.PaqueteId);

                            PruebaXML2(ft);

                            ////Enviar 
                            string message;
                            string caption = "Desea Cancelar?";
                            if (!Enviar(p.PaqueteId, out message))
                            {
                                MessageBoxButtons mb = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, mb);
                                if (result == DialogResult.Yes)
                                {
                                    break;
                                }
                            }

                            Cursor.Current = Cursors.Default;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("No se puede sincronizar");

        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex != dgvProductos.NewRowIndex)
            //{
            //    if (e.ColumnIndex == dgvProductos.Columns["STATUS"].Index)
            //    {
            //        if (e.Value.ToString() == "SYNC")
            //        {
            //            dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            //        }
            //    }
            //}
            //if (this.dgvProductos.Columns[e.ColumnIndex].Name == "STATUS")
            //{
            //    if (e.Value != null)
            //    {
            //        // Check for the string "pink" in the cell.
            //        string stringValue = (string)e.Value;
            //        if (stringValue == "SYNC")
            //        {
            //            this.dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            //        }

            //        //stringValue = stringValue.ToLower();
            //        //if ((stringValue.IndexOf("sync") > -1))
            //        //{
            //        //    e.CellStyle.BackColor = Color.Pink;
            //        //}


            //    }
            //}
        }

        private void btnReprocesar_Click(object sender, EventArgs e)
        {
            Simulacion();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            int pos = 0;
            string paqOrigen="",paqDestino = "";
            if (this.dgvProductos.CurrentRow != null && this.dgvProductos.CurrentRow.Index > 0)
            {
                pos = this.dgvProductos.CurrentRow.Index;
                paqOrigen = this.dgvProductos.CurrentRow.Cells["PaqueteId"].Value.ToString();
                paqDestino=this.dgvProductos.Rows[pos-1].Cells["PaqueteId"].Value.ToString();
                ActualizaPosicion(strOrden, paqOrigen, paqDestino, pos);
                pos -= 1;
                this.dgvProductos.Rows[pos].Selected = true;
                this.dgvProductos.CurrentCell = this.dgvProductos.Rows[pos].Cells[0];
            }
        }

        void ActualizaPosicion(string orden,string paqOrigen,string paqDestino,int pos)
        {
            CMovProducido cProd=new CMovProducido();
            MovProducido oProd,oProd2;
            oProd = cProd.TraerMovProducido(paqOrigen);
            oProd2 = cProd.TraerMovProducido(paqDestino);
            int posTemp = oProd.POSICION;
            oProd.POSICION = oProd2.POSICION;
            oProd2.POSICION = posTemp;
            cProd.ModificarMovProducido(oProd);
            cProd.ModificarMovProducido(oProd2);
            CargarOrden();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            int pos = 0;
            string paqOrigen = "", paqDestino = "";
            if (this.dgvProductos.CurrentRow != null && this.dgvProductos.CurrentRow.Index < this.dgvProductos.Rows.Count - 1)
            {
                pos = this.dgvProductos.CurrentRow.Index;
                paqOrigen = this.dgvProductos.CurrentRow.Cells["PaqueteId"].Value.ToString();
                paqDestino = this.dgvProductos.Rows[pos + 1].Cells["PaqueteId"].Value.ToString();
                ActualizaPosicion(strOrden, paqOrigen, paqDestino, pos);
                pos += 1;
                this.dgvProductos.Rows[pos].Selected = true;
                this.dgvProductos.CurrentCell = this.dgvProductos.Rows[pos].Cells[0];
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count > 0)
            {

                strPaquete = dgvProductos.CurrentRow.Cells[1].Value.ToString();

                string Unidad =dgvProductos.CurrentRow.Cells["AXUNITMEASURE"].Value.ToString();
                string Calidad = dgvProductos.CurrentRow.Cells["Calidad"].Value.ToString();
                decimal CostoUnitario,CostoPaquete = 0;
                decimal PesoPaquete= (decimal)dgvProductos.CurrentRow.Cells["Peso"].Value;
                int PiezasPaquete = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Piezas"].Value);
                decimal CostoPrimera = Convert.ToDecimal(lblCostoPrimera.Text);
                decimal KgsPrimera = Convert.ToDecimal(lblKgsPrimera.Text);
                int PiezasPrimera = Convert.ToInt32(lblPiezasPrimera.Text);
                if (Calidad != "GOOD")
                {
                    CostoUnitario = 0.01M;
                    CostoPaquete = CostoUnitario * PesoPaquete;
                }
                else
                {
                    if (Unidad == "kg")
                    {
                        if (KgsPrimera > 0)
                            CostoUnitario = CostoPrimera / KgsPrimera;
                        else
                            CostoUnitario = 0;
                        CostoPaquete = CostoUnitario * PesoPaquete;
                    }
                    else
                    {
                        if (PiezasPrimera > 0)
                            CostoUnitario = CostoPrimera / PiezasPrimera;
                        else
                            CostoUnitario = 0;
                        CostoPaquete = CostoUnitario * PiezasPaquete;
                    }
                }
                lblCostoPaquete.Text = CostoPaquete.ToString();

            }
        } 
    }
}
