using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class AsignacionPosicion : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        CLocaliza C_Localiza; 
        string _NrOrden_ = string.Empty;
        string _NombreAlmacen = string.Empty;
        int _AreasAlmacen = 0;
        int _NavesAlmacen = 0;
        int _IdAlmacen = 0;
        public List<CeldaAlm> _celdas = new List<CeldaAlm>();
        int IdSucursal = 0;
        public List<CeldaConsulta> _celdaData = new List<CeldaConsulta>();
        public List<string> _centrosTrabajo = new List<string>();
        public List<string> _listMarcados = new List<string>();
        public List<EstanteConsulta> _estantesData = new List<EstanteConsulta>();

        public AsignacionPosicion(int _IdSucursal, string _NrOrden, string _Item, string _Descripcion, string _Fecha, string _Cantidad, string _Unidad, string _CentroTrabajo)
        {
            InitializeComponent();
            txtOrden.Text = _NrOrden;
            txtFecha.Text = _Fecha;
            txtCentroTrabajo.Text = _CentroTrabajo;
            txtItem.Text = _Item;
            txtKgs.Text = _Fecha;
            txtDescripcion.Text = _Descripcion;
            IdSucursal = _IdSucursal;
            C_Localiza = new CLocaliza();
            C_Celdas = new CCeldas();
            _NrOrden_ = _NrOrden;
            DatosAlmacen();
            TraerData();
            CrearCeldas();
            TraerDatos();
        }
        public void DatosAlmacen()
        {
            try
            {
                DataSet ListAlm = C_Celdas.DatosAlmacen(IdSucursal);
                foreach (DataRow item in ListAlm.Tables[0].Rows)
                {
                    if (IdSucursal == Convert.ToInt32(item[1]))
                    {
                        _IdAlmacen = Convert.ToInt32(item[0]);
                        _NombreAlmacen = item[2].ToString();
                        _AreasAlmacen = Convert.ToInt32(item[3]);
                        _NavesAlmacen = Convert.ToInt32(item[4]);
                    }
                }
                //labelTitulo.Text = _NombreAlmacen;

                if (IdSucursal == 12081)
                {
                    BandNave1.Visible = false;
                    BandNave2.Visible = false;
                    BandNave3.Visible = false;
                    BandNave4.Visible = false;
                    BandNave5.Visible = false;
                    BandNave11.Visible = false;
                    BandNave12.Visible = false;
                    BandNave13.Visible = false;
                    BandNave14.Visible = false;
                    BandNave15.Visible = false;
                    BandNave16.Visible = false;
                    BandNave17.Visible = false;
                }
                else if (IdSucursal == 12080)
                {
                    BandNave1.Visible = false;
                    BandNave2.Visible = false;
                    BandNave3.Visible = false;
                    BandNave4.Visible = false;
                    BandNave5.Visible = false;
                    BandNave6.Visible = false;
                    BandNave7.Visible = false;
                    BandNave8.Visible = false;
                    BandNave9.Visible = false;
                    BandNave10.Visible = false;
                    BandNave14.Visible = false;
                    BandNave15.Visible = false;
                    BandNave16.Visible = false;
                    BandNave17.Visible = false;
                }
                else if (IdSucursal == 12071)
                {
                    BandNave8.Visible = false;
                    BandNave9.Visible = false;
                    BandNave10.Visible = false;
                    BandNave11.Visible = false;
                    BandNave12.Visible = false;
                    BandNave13.Visible = false;
                    BandNave14.Visible = false;
                    BandNave15.Visible = false;
                    BandNave16.Visible = false;
                    BandNave17.Visible = false;
                }
                else if (IdSucursal == 12012 || IdSucursal == 12004 || IdSucursal == 12007 || IdSucursal == 12008)
                {
                    BandNave3.Visible = false;
                    BandNave4.Visible = false;
                    BandNave5.Visible = false;
                    BandNave6.Visible = false;
                    BandNave7.Visible = false;
                    BandNave8.Visible = false;
                    BandNave9.Visible = false;
                    BandNave10.Visible = false;
                    BandNave11.Visible = false;
                    BandNave12.Visible = false;
                    BandNave13.Visible = false;
                    BandNave14.Visible = false;
                    BandNave15.Visible = false;
                    BandNave16.Visible = false;
                    BandNave17.Visible = false;
                }
                else if (IdSucursal == 12086 || IdSucursal == 12097)
                {
                    BandNave2.Visible = false;
                    BandNave3.Visible = false;
                    BandNave4.Visible = false;
                    BandNave5.Visible = false;
                    BandNave6.Visible = false;
                    BandNave7.Visible = false;
                    BandNave8.Visible = false;
                    BandNave9.Visible = false;
                    BandNave10.Visible = false;
                    BandNave11.Visible = false;
                    BandNave12.Visible = false;
                    BandNave13.Visible = false;
                    BandNave14.Visible = false;
                    BandNave15.Visible = false;
                    BandNave16.Visible = false;
                    BandNave17.Visible = false;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("########################### = " + err.ToString());
            }
        }
        public void TraerDatos()
        {
            try
            {
                DataSet dataPlan = C_Localiza.TraerCantidadPlanificar(_NrOrden_);
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% = " + dataPlan.Tables[0].Rows.Count);
                foreach(DataRow item in dataPlan.Tables[0].Rows)
                {
                    txtUnidadAsignar.Text = item[0].ToString();
                    txtUnidEstimada.Text = item[0].ToString();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("########################## = " + err.ToString());
            }
        }
        public void CrearCeldas()
        {
            int NumSuc = _IdAlmacen;
            for (int i = 1; i <= _AreasAlmacen; i++)
            {
                //S1
                _celdas.Add(new CeldaAlm
                {
                    //AL3:1A-1S1
                    p_Area = i,
                    p_Segmento = "S1",
                    p_N1A = "AL" + NumSuc + ":1A-" + i + "S1",
                    p_N1B = "AL" + NumSuc + ":1B-" + i + "S1",
                    p_N1C = "AL" + NumSuc + ":1C-" + i + "S1",
                    p_N2A = "AL" + NumSuc + ":2A-" + i + "S1",
                    p_N2B = "AL" + NumSuc + ":2B-" + i + "S1",
                    p_N2C = "AL" + NumSuc + ":2C-" + i + "S1",
                    p_N3A = "AL" + NumSuc + ":3A-" + i + "S1",
                    p_N3B = "AL" + NumSuc + ":3B-" + i + "S1",
                    p_N3C = "AL" + NumSuc + ":3C-" + i + "S1",
                    p_N4A = "AL" + NumSuc + ":4A-" + i + "S1",
                    p_N4B = "AL" + NumSuc + ":4B-" + i + "S1",
                    p_N4C = "AL" + NumSuc + ":4C-" + i + "S1",
                    p_N5A = "AL" + NumSuc + ":5A-" + i + "S1",
                    p_N5B = "AL" + NumSuc + ":5B-" + i + "S1",
                    p_N5C = "AL" + NumSuc + ":5C-" + i + "S1",
                    p_N6A = "AL" + NumSuc + ":6A-" + i + "S1",
                    p_N6B = "AL" + NumSuc + ":6B-" + i + "S1",
                    p_N6C = "AL" + NumSuc + ":6C-" + i + "S1",
                    p_N7A = "AL" + NumSuc + ":7A-" + i + "S1",
                    p_N7B = "AL" + NumSuc + ":7B-" + i + "S1",
                    p_N7C = "AL" + NumSuc + ":7C-" + i + "S1",
                    p_N8A = "AL" + NumSuc + ":8A-" + i + "S1",
                    p_N8B = "AL" + NumSuc + ":8B-" + i + "S1",
                    p_N8C = "AL" + NumSuc + ":8C-" + i + "S1",
                    p_N9A = "AL" + NumSuc + ":9A-" + i + "S1",
                    p_N9B = "AL" + NumSuc + ":9B-" + i + "S1",
                    p_N9C = "AL" + NumSuc + ":9C-" + i + "S1",
                    p_N10A = "AL" + NumSuc + ":10A-" + i + "S1",
                    p_N10B = "AL" + NumSuc + ":10B-" + i + "S1",
                    p_N10C = "AL" + NumSuc + ":10C-" + i + "S1",
                    p_N11A = "AL" + NumSuc + ":11A-" + i + "S1",
                    p_N11B = "AL" + NumSuc + ":11B-" + i + "S1",
                    p_N11C = "AL" + NumSuc + ":11C-" + i + "S1",
                    p_N12A = "AL" + NumSuc + ":12A-" + i + "S1",
                    p_N12B = "AL" + NumSuc + ":12B-" + i + "S1",
                    p_N12C = "AL" + NumSuc + ":12C-" + i + "S1",
                    p_N13A = "AL" + NumSuc + ":13A-" + i + "S1",
                    p_N13B = "AL" + NumSuc + ":13B-" + i + "S1",
                    p_N13C = "AL" + NumSuc + ":13C-" + i + "S1",
                    p_N14A = "AL" + NumSuc + ":14A-" + i + "S1",
                    p_N14B = "AL" + NumSuc + ":14B-" + i + "S1",
                    p_N14C = "AL" + NumSuc + ":14C-" + i + "S1",
                    p_N15A = "AL" + NumSuc + ":15A-" + i + "S1",
                    p_N15B = "AL" + NumSuc + ":15B-" + i + "S1",
                    p_N15C = "AL" + NumSuc + ":15C-" + i + "S1",
                    p_N16A = "AL" + NumSuc + ":16A-" + i + "S1",
                    p_N16B = "AL" + NumSuc + ":16B-" + i + "S1",
                    p_N16C = "AL" + NumSuc + ":16C-" + i + "S1",
                    p_N17A = "AL" + NumSuc + ":17A-" + i + "S1",
                    p_N17B = "AL" + NumSuc + ":17B-" + i + "S1",
                    p_N17C = "AL" + NumSuc + ":17C-" + i + "S1"
                });
                //S2
                _celdas.Add(new CeldaAlm
                {
                    p_Area = i,
                    p_Segmento = "S2",
                    p_N1A = "AL" + NumSuc + ":1A-" + i + "S2",
                    p_N1B = "AL" + NumSuc + ":1B-" + i + "S2",
                    p_N1C = "AL" + NumSuc + ":1C-" + i + "S2",
                    p_N2A = "AL" + NumSuc + ":2A-" + i + "S2",
                    p_N2B = "AL" + NumSuc + ":2B-" + i + "S2",
                    p_N2C = "AL" + NumSuc + ":2C-" + i + "S2",
                    p_N3A = "AL" + NumSuc + ":3A-" + i + "S2",
                    p_N3B = "AL" + NumSuc + ":3B-" + i + "S2",
                    p_N3C = "AL" + NumSuc + ":3C-" + i + "S2",
                    p_N4A = "AL" + NumSuc + ":4A-" + i + "S2",
                    p_N4B = "AL" + NumSuc + ":4B-" + i + "S2",
                    p_N4C = "AL" + NumSuc + ":4C-" + i + "S2",
                    p_N5A = "AL" + NumSuc + ":5A-" + i + "S2",
                    p_N5B = "AL" + NumSuc + ":5B-" + i + "S2",
                    p_N5C = "AL" + NumSuc + ":5C-" + i + "S2",
                    p_N6A = "AL" + NumSuc + ":6A-" + i + "S2",
                    p_N6B = "AL" + NumSuc + ":6B-" + i + "S2",
                    p_N6C = "AL" + NumSuc + ":6C-" + i + "S2",
                    p_N7A = "AL" + NumSuc + ":7A-" + i + "S2",
                    p_N7B = "AL" + NumSuc + ":7B-" + i + "S2",
                    p_N7C = "AL" + NumSuc + ":7C-" + i + "S2",
                    p_N8A = "AL" + NumSuc + ":8A-" + i + "S2",
                    p_N8B = "AL" + NumSuc + ":8B-" + i + "S2",
                    p_N8C = "AL" + NumSuc + ":8C-" + i + "S2",
                    p_N9A = "AL" + NumSuc + ":9A-" + i + "S2",
                    p_N9B = "AL" + NumSuc + ":9B-" + i + "S2",
                    p_N9C = "AL" + NumSuc + ":9C-" + i + "S2",
                    p_N10A = "AL" + NumSuc + ":10A-" + i + "S2",
                    p_N10B = "AL" + NumSuc + ":10B-" + i + "S2",
                    p_N10C = "AL" + NumSuc + ":10C-" + i + "S2",
                    p_N11A = "AL" + NumSuc + ":11A-" + i + "S2",
                    p_N11B = "AL" + NumSuc + ":11B-" + i + "S2",
                    p_N11C = "AL" + NumSuc + ":11C-" + i + "S2",
                    p_N12A = "AL" + NumSuc + ":12A-" + i + "S2",
                    p_N12B = "AL" + NumSuc + ":12B-" + i + "S2",
                    p_N12C = "AL" + NumSuc + ":12C-" + i + "S2",
                    p_N13A = "AL" + NumSuc + ":13A-" + i + "S2",
                    p_N13B = "AL" + NumSuc + ":13B-" + i + "S2",
                    p_N13C = "AL" + NumSuc + ":13C-" + i + "S2",
                    p_N14A = "AL" + NumSuc + ":14A-" + i + "S2",
                    p_N14B = "AL" + NumSuc + ":14B-" + i + "S2",
                    p_N14C = "AL" + NumSuc + ":14C-" + i + "S2",
                    p_N15A = "AL" + NumSuc + ":15A-" + i + "S2",
                    p_N15B = "AL" + NumSuc + ":15B-" + i + "S2",
                    p_N15C = "AL" + NumSuc + ":15C-" + i + "S2",
                    p_N16A = "AL" + NumSuc + ":16A-" + i + "S2",
                    p_N16B = "AL" + NumSuc + ":16B-" + i + "S2",
                    p_N16C = "AL" + NumSuc + ":16C-" + i + "S2",
                    p_N17A = "AL" + NumSuc + ":17A-" + i + "S2",
                    p_N17B = "AL" + NumSuc + ":17B-" + i + "S2",
                    p_N17C = "AL" + NumSuc + ":17C-" + i + "S2"
                });
                //S3
                _celdas.Add(new CeldaAlm
                {
                    p_Area = i,
                    p_Segmento = "S3",
                    p_N1A = "AL" + NumSuc + ":1A-" + i + "S3",
                    p_N1B = "AL" + NumSuc + ":1B-" + i + "S3",
                    p_N1C = "AL" + NumSuc + ":1C-" + i + "S3",
                    p_N2A = "AL" + NumSuc + ":2A-" + i + "S3",
                    p_N2B = "AL" + NumSuc + ":2B-" + i + "S3",
                    p_N2C = "AL" + NumSuc + ":2C-" + i + "S3",
                    p_N3A = "AL" + NumSuc + ":3A-" + i + "S3",
                    p_N3B = "AL" + NumSuc + ":3B-" + i + "S3",
                    p_N3C = "AL" + NumSuc + ":3C-" + i + "S3",
                    p_N4A = "AL" + NumSuc + ":4A-" + i + "S3",
                    p_N4B = "AL" + NumSuc + ":4B-" + i + "S3",
                    p_N4C = "AL" + NumSuc + ":4C-" + i + "S3",
                    p_N5A = "AL" + NumSuc + ":5A-" + i + "S3",
                    p_N5B = "AL" + NumSuc + ":5B-" + i + "S3",
                    p_N5C = "AL" + NumSuc + ":5C-" + i + "S3",
                    p_N6A = "AL" + NumSuc + ":6A-" + i + "S3",
                    p_N6B = "AL" + NumSuc + ":6B-" + i + "S3",
                    p_N6C = "AL" + NumSuc + ":6C-" + i + "S3",
                    p_N7A = "AL" + NumSuc + ":7A-" + i + "S3",
                    p_N7B = "AL" + NumSuc + ":7B-" + i + "S3",
                    p_N7C = "AL" + NumSuc + ":7C-" + i + "S3",
                    p_N8A = "AL" + NumSuc + ":8A-" + i + "S3",
                    p_N8B = "AL" + NumSuc + ":8B-" + i + "S3",
                    p_N8C = "AL" + NumSuc + ":8C-" + i + "S3",
                    p_N9A = "AL" + NumSuc + ":9A-" + i + "S3",
                    p_N9B = "AL" + NumSuc + ":9B-" + i + "S3",
                    p_N9C = "AL" + NumSuc + ":9C-" + i + "S3",
                    p_N10A = "AL" + NumSuc + ":10A-" + i + "S3",
                    p_N10B = "AL" + NumSuc + ":10B-" + i + "S3",
                    p_N10C = "AL" + NumSuc + ":10C-" + i + "S3",
                    p_N11A = "AL" + NumSuc + ":11A-" + i + "S3",
                    p_N11B = "AL" + NumSuc + ":11B-" + i + "S3",
                    p_N11C = "AL" + NumSuc + ":11C-" + i + "S3",
                    p_N12A = "AL" + NumSuc + ":12A-" + i + "S3",
                    p_N12B = "AL" + NumSuc + ":12B-" + i + "S3",
                    p_N12C = "AL" + NumSuc + ":12C-" + i + "S3",
                    p_N13A = "AL" + NumSuc + ":13A-" + i + "S3",
                    p_N13B = "AL" + NumSuc + ":13B-" + i + "S3",
                    p_N13C = "AL" + NumSuc + ":13C-" + i + "S3",
                    p_N14A = "AL" + NumSuc + ":14A-" + i + "S3",
                    p_N14B = "AL" + NumSuc + ":14B-" + i + "S3",
                    p_N14C = "AL" + NumSuc + ":14C-" + i + "S3",
                    p_N15A = "AL" + NumSuc + ":15A-" + i + "S3",
                    p_N15B = "AL" + NumSuc + ":15B-" + i + "S3",
                    p_N15C = "AL" + NumSuc + ":15C-" + i + "S3",
                    p_N16A = "AL" + NumSuc + ":16A-" + i + "S3",
                    p_N16B = "AL" + NumSuc + ":16B-" + i + "S3",
                    p_N16C = "AL" + NumSuc + ":16C-" + i + "S3",
                    p_N17A = "AL" + NumSuc + ":17A-" + i + "S3",
                    p_N17B = "AL" + NumSuc + ":17B-" + i + "S3",
                    p_N17C = "AL" + NumSuc + ":17C-" + i + "S3"
                });
            }
            gridControl1.DataSource = _celdas; 
        }
        public void TraerData()
        {
            try
            {
                string _Segmento = string.Empty;
                int _Area = 0;
                string _Celda = string.Empty;
                int _Nave = 0;
                string _Columna = string.Empty;
                int cntArea = 1;
                int cntSegmento = 1;
                string compSegmento = string.Empty;

                DataSet dataLista = C_Celdas.VistaAlmacenes(IdSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    _celdaData.Add(new CeldaConsulta
                    {
                        p_Area = Convert.ToInt32(item[0]),
                        p_Segmento = item[1].ToString(),
                        p_Nave = Convert.ToInt32(item[2]),
                        p_Columna = item[3].ToString(),
                        p_CeldaId = item[4].ToString(),
                        p_ItemId = item[5].ToString(),
                        p_Unidades = Convert.ToInt32(item[6]),
                        p_UnidadesXCelda = Convert.ToInt32(item[7]),
                        p_Status = Convert.ToInt32(item[8].ToString())
                    });
                }
                //for (int i = 0; i < 66; i++)
                foreach (var item in _celdaData)
                {
                    _Nave = item.p_Nave;
                    switch (_Nave)
                    {
                        case 1:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1C = item.p_CeldaId;
                            }
                            break;
                        case 2:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2C = item.p_CeldaId;
                            }
                            break;
                        case 3:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3C = item.p_CeldaId;
                            }
                            break;
                        case 4:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4C = item.p_CeldaId;
                            }
                            break;
                        case 5:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5C = item.p_CeldaId;
                            }
                            break;
                        case 6:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6C = item.p_CeldaId;
                            }
                            break;
                        case 7:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7C = item.p_CeldaId;
                            }
                            break;
                        case 8:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8C = item.p_CeldaId;
                            }
                            break;
                        case 9:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9C = item.p_CeldaId;
                            }
                            break;
                        case 10:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10C = item.p_CeldaId;
                            }
                            break;
                        case 11:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11C = item.p_CeldaId;
                            }
                            break;
                        case 12:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12C = item.p_CeldaId;
                            }
                            break;
                        case 13:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13C = item.p_CeldaId;
                            }
                            break;
                        case 14:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14C = item.p_CeldaId;
                            }
                            break;
                        case 15:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15C = item.p_CeldaId;
                            }
                            break;
                        case 16:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16C = item.p_CeldaId;
                            }
                            break;
                        case 17:
                            if (item.p_Columna == "A")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17A = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17B = item.p_CeldaId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17C = item.p_CeldaId;
                            }
                            break;
                        default:
                            XtraMessageBox.Show("Switch - Default");
                            break;
                    }
                }
                gridControl1.DataSource = _celdas;
                //traer centros trabajo
                DataSet centLista = C_Celdas.VistaAlmacenesMaquinas(IdSucursal);
                foreach (DataRow item in centLista.Tables[0].Rows)
                {
                    _centrosTrabajo.Add(item[0].ToString());
                }
                
            }
            catch (Exception err)
            {
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ = " + err.ToString());
            }
        }
        private void txtUnidEstimada_TextChanged(object sender, EventArgs e)
        {
            txtUnidadAsignar.Text = txtUnidadAsignar.Text;
        }
        private void bandedGridView1_RowCellStyle_1(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                string _Cell = string.Empty;
                GridView view = sender as GridView;
                if (view == null) return;
                string _Col = string.Empty;
                int cont = 0;
                string _colCont = "A";
                string _rowName = string.Empty;

                //Hace el loop por las 17 naves, 
                for (int i = 0; i < 17; i++)
                {
                    try
                    {
                        //Convert.ToDecimal(drDatos["total"] is DBNull ? 0 : drDatos["total"])
                        //1
                        string _1A = (view.GetRowCellValue(e.RowHandle, "p_N1A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1A")).ToString();
                        if (e.Column.FieldName == "p_N1A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _1A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _1B = (view.GetRowCellValue(e.RowHandle, "p_N1B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1B")).ToString();
                        if (e.Column.FieldName == "p_N1B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _1B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _1C = (view.GetRowCellValue(e.RowHandle, "p_N1C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1C")).ToString();
                        if (e.Column.FieldName == "p_N1C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _1C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //2
                        string _2A = (view.GetRowCellValue(e.RowHandle, "p_N2A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2A")).ToString();
                        if (e.Column.FieldName == "p_N2A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _2A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _2B = (view.GetRowCellValue(e.RowHandle, "p_N2B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2B")).ToString();
                        if (e.Column.FieldName == "p_N2B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _2B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _2C = (view.GetRowCellValue(e.RowHandle, "p_N2C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2C")).ToString();
                        if (e.Column.FieldName == "p_N2C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _2C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //3
                        string _3A = (view.GetRowCellValue(e.RowHandle, "p_N3A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3A")).ToString();
                        if (e.Column.FieldName == "p_N3A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _3A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _3B = (view.GetRowCellValue(e.RowHandle, "p_N3B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3B")).ToString();
                        if (e.Column.FieldName == "p_N3B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _3B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _3C = (view.GetRowCellValue(e.RowHandle, "p_N3C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3C")).ToString();
                        if (e.Column.FieldName == "p_N3C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _3C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //4
                        string _4A = (view.GetRowCellValue(e.RowHandle, "p_N4A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4A")).ToString();
                        if (e.Column.FieldName == "p_N4A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _4A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _4B = (view.GetRowCellValue(e.RowHandle, "p_N4B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4B")).ToString();
                        if (e.Column.FieldName == "p_N4B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _4B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _4C = (view.GetRowCellValue(e.RowHandle, "p_N4C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4C")).ToString();
                        if (e.Column.FieldName == "p_N4C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _4C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //5
                        string _5A = (view.GetRowCellValue(e.RowHandle, "p_N5A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5A")).ToString();
                        if (e.Column.FieldName == "p_N5A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _5A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _5B = (view.GetRowCellValue(e.RowHandle, "p_N5B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5B")).ToString();
                        if (e.Column.FieldName == "p_N5B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _5B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _5C = (view.GetRowCellValue(e.RowHandle, "p_N5C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5C")).ToString();
                        if (e.Column.FieldName == "p_N5C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _5C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //6
                        //int _6A = view.GetRowCellValue(e.RowHandle, "p_N6A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6A").ToString().Length;
                        string _6A2 = (view.GetRowCellValue(e.RowHandle, "p_N6A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6A")).ToString();
                        if (e.Column.FieldName == "p_N6A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _6A2)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //int _6B = view.GetRowCellValue(e.RowHandle, "p_N6B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6B").ToString().Length;
                        string _6B = (view.GetRowCellValue(e.RowHandle, "p_N6B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6B")).ToString();
                        if (e.Column.FieldName == "p_N6B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _6B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _6C = (view.GetRowCellValue(e.RowHandle, "p_N6C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6C")).ToString();
                        if (e.Column.FieldName == "p_N6C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _6C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //7
                        string _7A = (view.GetRowCellValue(e.RowHandle, "p_N7A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7A")).ToString();
                        if (e.Column.FieldName == "p_N7A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _7A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _7B = (view.GetRowCellValue(e.RowHandle, "p_N7B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7B")).ToString();
                        if (e.Column.FieldName == "p_N7B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _7B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _7C = (view.GetRowCellValue(e.RowHandle, "p_N7C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7C")).ToString();
                        if (e.Column.FieldName == "p_N7C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _7C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //8
                        string _8A = (view.GetRowCellValue(e.RowHandle, "p_N8A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8A")).ToString();
                        if (e.Column.FieldName == "p_N8A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _8A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _8B = (view.GetRowCellValue(e.RowHandle, "p_N8B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8B")).ToString();
                        if (e.Column.FieldName == "p_N8B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _8B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _8C = (view.GetRowCellValue(e.RowHandle, "p_N8C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8C")).ToString();
                        if (e.Column.FieldName == "p_N8C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _8C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //9
                        string _9A = (view.GetRowCellValue(e.RowHandle, "p_N9A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9A")).ToString();
                        if (e.Column.FieldName == "p_N9A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _9A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _9B = (view.GetRowCellValue(e.RowHandle, "p_N9B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9B")).ToString();
                        if (e.Column.FieldName == "p_N9B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _9B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _9C = (view.GetRowCellValue(e.RowHandle, "p_N9C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9C")).ToString();
                        if (e.Column.FieldName == "p_N9C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _9C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //10
                        string _10A = (view.GetRowCellValue(e.RowHandle, "p_N10A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10A")).ToString();
                        if (e.Column.FieldName == "p_N10A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _10A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _10B = (view.GetRowCellValue(e.RowHandle, "p_N10B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10B")).ToString();
                        if (e.Column.FieldName == "p_N10B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _10B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _10C = (view.GetRowCellValue(e.RowHandle, "p_N10C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10C")).ToString();
                        if (e.Column.FieldName == "p_N10C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _10C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //11
                        string _11A = (view.GetRowCellValue(e.RowHandle, "p_N11A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11A")).ToString();
                        if (e.Column.FieldName == "p_N11A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _11A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _11B = (view.GetRowCellValue(e.RowHandle, "p_N11B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11B")).ToString();
                        if (e.Column.FieldName == "p_N11B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _11B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _11C = (view.GetRowCellValue(e.RowHandle, "p_N11C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11C")).ToString();
                        if (e.Column.FieldName == "p_N11C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _11C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //12
                        string _12A = (view.GetRowCellValue(e.RowHandle, "p_N12A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12A")).ToString();
                        if (e.Column.FieldName == "p_N12A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _12A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _12B = (view.GetRowCellValue(e.RowHandle, "p_N12B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12B")).ToString();
                        if (e.Column.FieldName == "p_N12B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _12B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _12C = (view.GetRowCellValue(e.RowHandle, "p_N12C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12C")).ToString();
                        if (e.Column.FieldName == "p_N12C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _6C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //13
                        string _13A = (view.GetRowCellValue(e.RowHandle, "p_N13A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13A")).ToString();
                        if (e.Column.FieldName == "p_N13A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _13A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _13B = (view.GetRowCellValue(e.RowHandle, "p_N13B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13B")).ToString();
                        if (e.Column.FieldName == "p_N13B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _13B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _13C = (view.GetRowCellValue(e.RowHandle, "p_N13C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13C")).ToString();
                        if (e.Column.FieldName == "p_N13C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _13C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //14
                        string _14A = (view.GetRowCellValue(e.RowHandle, "p_N14A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14A")).ToString();
                        if (e.Column.FieldName == "p_N14A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _14A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _14B = (view.GetRowCellValue(e.RowHandle, "p_N14B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14B")).ToString();
                        if (e.Column.FieldName == "p_N14B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _14B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _14C = (view.GetRowCellValue(e.RowHandle, "p_N14C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14C")).ToString();
                        if (e.Column.FieldName == "p_N14C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _14C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //15
                        string _15A = (view.GetRowCellValue(e.RowHandle, "p_N15A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15A")).ToString();
                        if (e.Column.FieldName == "p_N15A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _15A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _15B = (view.GetRowCellValue(e.RowHandle, "p_N15B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15B")).ToString();
                        if (e.Column.FieldName == "p_N15B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _15B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _15C = (view.GetRowCellValue(e.RowHandle, "p_N15C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15C")).ToString();
                        if (e.Column.FieldName == "p_N15C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _6C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //16
                        string _16A = (view.GetRowCellValue(e.RowHandle, "p_N16A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16A")).ToString();
                        if (e.Column.FieldName == "p_N16A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _16A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _16B = (view.GetRowCellValue(e.RowHandle, "p_N16B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16B")).ToString();
                        if (e.Column.FieldName == "p_N16B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _16B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _16C = (view.GetRowCellValue(e.RowHandle, "p_N16C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16C")).ToString();
                        if (e.Column.FieldName == "p_N16C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _16C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //17
                        string _17A = (view.GetRowCellValue(e.RowHandle, "p_N17A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17A")).ToString();
                        if (e.Column.FieldName == "p_N17A")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _17A)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _17B = (view.GetRowCellValue(e.RowHandle, "p_N17B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17B")).ToString();
                        if (e.Column.FieldName == "p_N17B")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _17B)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        string _17C = (view.GetRowCellValue(e.RowHandle, "p_N17C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17C")).ToString();
                        if (e.Column.FieldName == "p_N17C")
                        {
                            if (_centrosTrabajo.Contains(e.CellValue.ToString()))
                            {
                                e.Appearance.BackColor = Color.Black;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            {

                                int _cnt = 0;
                                int _cntxCeld = 0;
                                foreach (var itm in _celdaData)
                                {
                                    if (itm.p_CeldaId == _17C)
                                    {
                                        _cnt = itm.p_Unidades;
                                        _cntxCeld = itm.p_UnidadesXCelda;
                                    }
                                }
                                //Console.WriteLine("$$$$$$$$$$$$$$$ = CNT = " + _cnt + "   ///////////// CNTxCELDA = " + _cntxCeld);
                                if (_cnt <= 0)
                                {
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt < _cntxCeld && _cnt > 0)
                                {
                                    e.Appearance.BackColor = Color.Yellow;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else if (_cnt >= _cntxCeld)
                                {
                                    e.Appearance.BackColor = Color.Red;
                                    e.Appearance.ForeColor = Color.White;
                                }
                                else
                                {
                                    e.Appearance.BackColor = Color.White;
                                    e.Appearance.ForeColor = Color.White;
                                }
                            }
                        }
                        //////////////////////////////////////////////////////////////////////

                        if (_Col == "A")
                        {
                            _Col = "B";
                        }
                        else if (_Col == "B")
                        {
                            _Col = "C";
                        }
                        else if (_Col == "C")
                        {
                            _Col = "A";
                        }
                        if (i == 17)
                        {
                            cont++;
                            i = 0;
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("####################################### = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("################ = " + err.ToString());
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
            }
        }
        private void bandedGridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            string _Cell = view.GetRowCellValue(e.RowHandle, e.Column).ToString();
            txtCelda.Text = _Cell;
            //Traer cantidad en estantes de cada celda

        }
        public void GetEstantes(string colCaption)
        {
            string _CeldaId = colCaption;
            int _Fila = 1;
            try
            {
                DataSet dataEstante = C_Celdas.TraerEstantesCelda(IdSucursal, _CeldaId, _Fila);
                foreach (DataRow item in dataEstante.Tables[0].Rows)
                {
                    _estantesData.Add(new EstanteConsulta
                    {
                        p_CodigoEstante = item[0].ToString(),
                        p_Unidades = Convert.ToInt32(item[1]),
                        p_Kgs = Convert.ToDecimal(item[2]),
                        p_Max_Kgs = Convert.ToDecimal(item[3])
                    });
                }
                //
                foreach (var item in _estantesData)
                {
                    if (btnP1A1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP1A1.Appearance.BackColor = Color.Green;
                            btnP1A1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP1A1.Appearance.BackColor = Color.Red;
                            btnP1A1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP1A1.Appearance.BackColor = Color.Yellow;
                            btnP1A1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP2A1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP2A1.Appearance.BackColor = Color.Green;
                            btnP2A1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP2A1.Appearance.BackColor = Color.Red;
                            btnP2A1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP2A1.Appearance.BackColor = Color.Yellow;
                            btnP2A1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP3A1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP3A1.Appearance.BackColor = Color.Green;
                            btnP3A1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP3A1.Appearance.BackColor = Color.Red;
                            btnP3A1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP3A1.Appearance.BackColor = Color.Yellow;
                            btnP3A1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP4A1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP4A1.Appearance.BackColor = Color.Green;
                            btnP4A1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP4A1.Appearance.BackColor = Color.Red;
                            btnP4A1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP4A1.Appearance.BackColor = Color.Yellow;
                            btnP4A1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP5A1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP5A1.Appearance.BackColor = Color.Green;
                            btnP5A1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP5A1.Appearance.BackColor = Color.Red;
                            btnP5A1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP5A1.Appearance.BackColor = Color.Yellow;
                            btnP5A1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP1B1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP1B1.Appearance.BackColor = Color.Green;
                            btnP1B1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP1B1.Appearance.BackColor = Color.Red;
                            btnP1B1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP1B1.Appearance.BackColor = Color.Yellow;
                            btnP1B1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP2B1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP2B1.Appearance.BackColor = Color.Green;
                            btnP2B1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP2B1.Appearance.BackColor = Color.Red;
                            btnP2B1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP2B1.Appearance.BackColor = Color.Yellow;
                            btnP2B1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP3B1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP3B1.Appearance.BackColor = Color.Green;
                            btnP3B1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP3B1.Appearance.BackColor = Color.Red;
                            btnP3B1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP3B1.Appearance.BackColor = Color.Yellow;
                            btnP3B1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP4B1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP4B1.Appearance.BackColor = Color.Green;
                            btnP4B1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP4B1.Appearance.BackColor = Color.Red;
                            btnP4B1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP4B1.Appearance.BackColor = Color.Yellow;
                            btnP4B1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP5B1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP5B1.Appearance.BackColor = Color.Green;
                            btnP5B1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP5B1.Appearance.BackColor = Color.Red;
                            btnP5B1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP5B1.Appearance.BackColor = Color.Yellow;
                            btnP5B1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP1C1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP1C1.Appearance.BackColor = Color.Green;
                            btnP1C1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP1C1.Appearance.BackColor = Color.Red;
                            btnP1C1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP1C1.Appearance.BackColor = Color.Yellow;
                            btnP1C1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP2C1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP2C1.Appearance.BackColor = Color.Green;
                            btnP2C1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP2C1.Appearance.BackColor = Color.Red;
                            btnP2C1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP2C1.Appearance.BackColor = Color.Yellow;
                            btnP2C1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP3C1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP3C1.Appearance.BackColor = Color.Green;
                            btnP3C1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP3C1.Appearance.BackColor = Color.Red;
                            btnP3C1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP3C1.Appearance.BackColor = Color.Yellow;
                            btnP3C1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP4C1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP4C1.Appearance.BackColor = Color.Green;
                            btnP4C1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP4C1.Appearance.BackColor = Color.Red;
                            btnP4C1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP4C1.Appearance.BackColor = Color.Yellow;
                            btnP4C1.ForeColor = Color.White;
                        }
                    }
                    else if (btnP5C1.Text.Trim() == item.p_CodigoEstante.Trim())
                    {
                        if (item.p_Unidades == 0)
                        {
                            btnP5C1.Appearance.BackColor = Color.Green;
                            btnP5C1.ForeColor = Color.White;
                        }
                        else if (item.p_Kgs >= item.p_Max_Kgs)
                        {
                            btnP5C1.Appearance.BackColor = Color.Red;
                            btnP5C1.ForeColor = Color.White;
                        }
                        else
                        {
                            btnP5C1.Appearance.BackColor = Color.Yellow;
                            btnP5C1.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################## = " + err.ToString());
            }
        } 
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            //string _ubicacion = txtCelda.Text.Trim() + " - " + comboxPiso.Text + "-" + comboxColRack.Text + comBoxFila.Text;
            //_listMarcados.Add(_ubicacion);
            //listBoxSelected.DataSource = _listMarcados;
        }
        /// ///////////////////////////////////////////////////////////////////////////////
        public class CeldaAlm
        {
            private int Area;
            private string Segmento;
            //private int Nave;
            //private string Columna;
            private string N1A;
            private string N1B;
            private string N1C;
            private string N2A;
            private string N2B;
            private string N2C;
            private string N3A;
            private string N3B;
            private string N3C;
            private string N4A;
            private string N4B;
            private string N4C;
            private string N5A;
            private string N5B;
            private string N5C;
            private string N6A;
            private string N6B;
            private string N6C;
            private string N7A;
            private string N7B;
            private string N7C;
            private string N8A;
            private string N8B;
            private string N8C;
            private string N9A;
            private string N9B;
            private string N9C;
            private string N10A;
            private string N10B;
            private string N10C;
            private string N11A;
            private string N11B;
            private string N11C;
            private string N12A;
            private string N12B;
            private string N12C;
            private string N13A;
            private string N13B;
            private string N13C;
            private string N14A;
            private string N14B;
            private string N14C;
            private string N15A;
            private string N15B;
            private string N15C;
            private string N16A;
            private string N16B;
            private string N16C;
            private string N17A;
            private string N17B;
            private string N17C;

            public int p_Area
            {
                get { return Area; }
                set { Area = value; }
            }
            public string p_Segmento
            {
                get { return Segmento; }
                set { Segmento = value; }
            }
            //public int p_Nave
            //{
            //    get { return Nave; }
            //    set { Nave = value; }
            //}
            //public string p_Columna
            //{
            //    get { return Columna; }
            //    set { Columna = value; }
            //}
            public string p_N1A
            {
                get { return N1A; }
                set { N1A = value; }
            }
            public string p_N1B
            {
                get { return N1B; }
                set { N1B = value; }
            }
            public string p_N1C
            {
                get { return N1C; }
                set { N1C = value; }
            }
            public string p_N2A
            {
                get { return N2A; }
                set { N2A = value; }
            }
            public string p_N2B
            {
                get { return N2B; }
                set { N2B = value; }
            }
            public string p_N2C
            {
                get { return N2C; }
                set { N2C = value; }
            }
            public string p_N3A
            {
                get { return N3A; }
                set { N3A = value; }
            }
            public string p_N3B
            {
                get { return N3B; }
                set { N3B = value; }
            }
            public string p_N3C
            {
                get { return N3C; }
                set { N3C = value; }
            }
            public string p_N4A
            {
                get { return N4A; }
                set { N4A = value; }
            }
            public string p_N4B
            {
                get { return N4B; }
                set { N4B = value; }
            }
            public string p_N4C
            {
                get { return N4C; }
                set { N4C = value; }
            }
            public string p_N5A
            {
                get { return N5A; }
                set { N5A = value; }
            }
            public string p_N5B
            {
                get { return N5B; }
                set { N5B = value; }
            }
            public string p_N5C
            {
                get { return N5C; }
                set { N5C = value; }
            }
            public string p_N6A
            {
                get { return N6A; }
                set { N6A = value; }
            }
            public string p_N6B
            {
                get { return N6B; }
                set { N6B = value; }
            }
            public string p_N6C
            {
                get { return N6C; }
                set { N6C = value; }
            }
            public string p_N7A
            {
                get { return N7A; }
                set { N7A = value; }
            }
            public string p_N7B
            {
                get { return N7B; }
                set { N7B = value; }
            }
            public string p_N7C
            {
                get { return N7C; }
                set { N7C = value; }
            }
            public string p_N8A
            {
                get { return N8A; }
                set { N8A = value; }
            }
            public string p_N8B
            {
                get { return N8B; }
                set { N8B = value; }
            }
            public string p_N8C
            {
                get { return N8C; }
                set { N8C = value; }
            }
            public string p_N9A
            {
                get { return N9A; }
                set { N9A = value; }
            }
            public string p_N9B
            {
                get { return N9B; }
                set { N9B = value; }
            }
            public string p_N9C
            {
                get { return N9C; }
                set { N9C = value; }
            }
            public string p_N10A
            {
                get { return N10A; }
                set { N10A = value; }
            }
            public string p_N10B
            {
                get { return N10B; }
                set { N10B = value; }
            }
            public string p_N10C
            {
                get { return N10C; }
                set { N10C = value; }
            }
            public string p_N11A
            {
                get { return N11A; }
                set { N11A = value; }
            }
            public string p_N11B
            {
                get { return N11B; }
                set { N11B = value; }
            }
            public string p_N11C
            {
                get { return N11C; }
                set { N11C = value; }
            }
            public string p_N12A
            {
                get { return N12A; }
                set { N12A = value; }
            }
            public string p_N12B
            {
                get { return N12B; }
                set { N12B = value; }
            }
            public string p_N12C
            {
                get { return N12C; }
                set { N12C = value; }
            }
            public string p_N13A
            {
                get { return N13A; }
                set { N13A = value; }
            }
            public string p_N13B
            {
                get { return N13B; }
                set { N13B = value; }
            }
            public string p_N13C
            {
                get { return N13C; }
                set { N13C = value; }
            }
            public string p_N14A
            {
                get { return N14A; }
                set { N14A = value; }
            }
            public string p_N14B
            {
                get { return N14B; }
                set { N14B = value; }
            }
            public string p_N14C
            {
                get { return N14C; }
                set { N14C = value; }
            }
            public string p_N15A
            {
                get { return N15A; }
                set { N15A = value; }
            }
            public string p_N15B
            {
                get { return N15B; }
                set { N15B = value; }
            }
            public string p_N15C
            {
                get { return N15C; }
                set { N15C = value; }
            }
            public string p_N16A
            {
                get { return N16A; }
                set { N16A = value; }
            }
            public string p_N16B
            {
                get { return N16B; }
                set { N16B = value; }
            }
            public string p_N16C
            {
                get { return N16C; }
                set { N16C = value; }
            }
            public string p_N17A
            {
                get { return N17A; }
                set { N17A = value; }
            }
            public string p_N17B
            {
                get { return N17B; }
                set { N17B = value; }
            }
            public string p_N17C
            {
                get { return N17C; }
                set { N17C = value; }
            }
        }
        public class CeldaConsulta
        {
            private int Area;
            private string Segmento;
            private int Nave;
            private string Columna;
            private string CeldaId;
            private string ItemId;
            private int Unidades;
            private int UnidadesXCelda;
            private int Status;

            public int p_Area
            {
                get { return Area; }
                set { Area = value; }
            }
            public string p_Segmento
            {
                get { return Segmento; }
                set { Segmento = value; }
            }
            public int p_Nave
            {
                get { return Nave; }
                set { Nave = value; }
            }
            public string p_Columna
            {
                get { return Columna; }
                set { Columna = value; }
            }
            public string p_CeldaId
            {
                get { return CeldaId; }
                set { CeldaId = value; }
            }
            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public int p_Unidades
            {
                get { return Unidades; }
                set { Unidades = value; }
            }
            public int p_UnidadesXCelda
            {
                get { return UnidadesXCelda; }
                set { UnidadesXCelda = value; }
            }
            public int p_Status
            {
                get { return Status; }
                set { Status = value; }
            }
        }
        public class EstanteConsulta
        {
            private string CodigoEstante;
            //private string CeldaId;
            private int Unidades;
            private decimal Kgs;
            private decimal Max_Kgs;

            public string p_CodigoEstante
            {
                get { return CodigoEstante; }
                set { CodigoEstante = value; }
            }
            //public string p_CeldaId
            //{
            //    get { return CeldaId; }
            //    set { CeldaId = value; }
            //}
            public int p_Unidades
            {
                get { return Unidades; }
                set { Unidades = value; }
            }
            public decimal p_Kgs
            {
                get { return Kgs; }
                set { Kgs = value; }
            }
            public decimal p_Max_Kgs
            {
                get { return Max_Kgs; }
                set { Max_Kgs = value; }
            }
        }
    }
}