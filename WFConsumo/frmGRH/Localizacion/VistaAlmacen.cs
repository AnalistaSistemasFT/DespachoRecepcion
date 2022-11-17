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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class VistaAlmacen : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        public List<CeldaAlm> _celdas = new List<CeldaAlm>();
        public List<CeldaConsulta> _celdaData = new List<CeldaConsulta>();
        int _IdSucursal = 0;

        public VistaAlmacen()
        {
            InitializeComponent();
            C_Celdas = new CCeldas();
            //////////////////////////
            _IdSucursal = 12081;
            //////////////////////////
            CrearCeldas();
            TraerData();
        }
        public void CrearCeldas()
        {
            int NumSuc = 3;
            for (int i = 1; i < 23; i++)
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

                DataSet dataLista = C_Celdas.VistaAlmacenes(_IdSucursal);
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
                        p_Unidades = item[6].ToString(),
                        p_UnidadesXCelda = item[7].ToString()
                    });
                }
                //for (int i = 0; i < 66; i++)
                foreach (var item in _celdaData)
                {
                    //_celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1A = item.p_CeldaId;
                    _Nave = item.p_Nave;
                    switch (_Nave)
                    {
                        case 1:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N1A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N1B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N1C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N1C = item.p_ItemId;
                            }
                            break;
                        case 2:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N2A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N2B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N2C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N2C = item.p_ItemId;
                            }
                            break;
                        case 3:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N3A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N3B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N3C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N3C = item.p_ItemId;
                            }
                            break;
                        case 4:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N4A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N4B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N4C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N4C = item.p_ItemId;
                            }
                            break;
                        case 5:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N5A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N5B = item.p_CeldaId; return c; }).ToList();
                                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%% = " + item.p_CeldaId);
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N5C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N5C = item.p_ItemId;
                            }
                            break;
                        case 6:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N6A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N6B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N6C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N6C = item.p_ItemId;
                            }
                            break;
                        case 7:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N7A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N7B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N7C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N7C = item.p_ItemId;
                            }
                            break;
                        case 8:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N8A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N8B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N8C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N8C = item.p_ItemId;
                            }
                            break;
                        case 9:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N9A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N9B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N9C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N9C = item.p_ItemId;
                            }
                            break;
                        case 10:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N10A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N10B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N10C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N10C = item.p_ItemId;
                            }
                            break;
                        case 11:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N11A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N11B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N11C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N11C = item.p_ItemId;
                            }
                            break;
                        case 12:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N12A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N12B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N12C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N12C = item.p_ItemId;
                            }
                            break;
                        case 13:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N13A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N13B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N13C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N13C = item.p_ItemId;
                            }
                            break;
                        case 14:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N14A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N14B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N14C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N14C = item.p_ItemId;
                            }
                            break;
                        case 15:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N15A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N15B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N15C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N15C = item.p_ItemId;
                            }
                            break;
                        case 16:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N16A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N16B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N16C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N16C = item.p_ItemId;
                            }
                            break;
                        case 17:
                            if (item.p_Columna == "A")
                            {
                                //_celdas.Select(c => { c.p_N17A = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17A = item.p_ItemId;
                            }
                            else if (item.p_Columna == "B")
                            {
                                //_celdas.Select(c => { c.p_N17B = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17B = item.p_ItemId;
                            }
                            else if (item.p_Columna == "C")
                            {
                                //_celdas.Select(c => { c.p_N17C = item.p_CeldaId; return c; }).ToList();
                                _celdas.Find(p => p.p_Area == item.p_Area && p.p_Segmento == item.p_Segmento).p_N17C = item.p_ItemId;
                            }
                            break;
                        default:
                            XtraMessageBox.Show("Switch - Default");
                            break;
                    }
                }
                //Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& = " + _celdas.);
                gridControl1.DataSource = _celdas;
                //filtrar en el switch por la nave y luego por columna 
            }

            catch (Exception err)
            {
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ = " + err.ToString());
            }
        }
        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                //    //////////////////////////////////////////////
                //    //Hace el loop por las 17 naves, 
                for (int i = 0; i < 17; i++)
                {
                    try
                    {
                        //_Col = "A";
                        //if (_Col == "A")
                        //{
                        //    string _nomb = "p_N" + (i + 1) + "A";
                        //    int _CellA = (view.GetRowCellValue(cont, _nomb) is DBNull ? "0" : view.GetRowCellValue(cont, _nomb)).ToString().Length;
                        //    if (e.Column.FieldName == _nomb || e.RowHandle == cont)
                        //    {
                        //        if (_CellA > 6)
                        //        {
                        //            e.Appearance.BackColor = Color.Blue;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //        else
                        //        {
                        //            e.Appearance.BackColor = Color.ForestGreen;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        //
                        //    }
                        //}
                        //else if (_Col == "B")
                        //{
                        //    string _nomb = "p_N" + (i + 1) + "B";
                        //    string _CellB = (view.GetRowCellValue(cont, _nomb) is DBNull ? "0" : view.GetRowCellValue(cont, _nomb)).ToString();
                        //    if (e.Column.FieldName == _nomb || e.RowHandle == cont)
                        //    {
                        //        if (_CellB.ToLower().Contains(':'))
                        //        {
                        //            e.Appearance.BackColor = Color.Blue;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //        else
                        //        {
                        //            e.Appearance.BackColor = Color.ForestGreen;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        //
                        //    }
                        //}
                        //else if (_Col == "C")
                        //{
                        //    string _nomb = "p_N" + (i + 1) + "C";
                        //    string _CellC = (view.GetRowCellValue(cont, _nomb) is DBNull ? "0" : view.GetRowCellValue(cont, _nomb)).ToString();
                        //    if (e.Column.FieldName == _nomb || e.RowHandle == cont)
                        //    {
                        //        if (_CellC.ToLower().Contains(':'))
                        //        {
                        //            e.Appearance.BackColor = Color.Blue;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //        else
                        //        {
                        //            e.Appearance.BackColor = Color.ForestGreen;
                        //            e.Appearance.ForeColor = Color.White;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        //
                        //    }
                        //}
                        //else
                        //{
                        //    e.Appearance.BackColor = Color.White;
                        //}

                        //Convert.ToDecimal(drDatos["total"] is DBNull ? 0 : drDatos["total"])
                        //1
                        int _1A = view.GetRowCellValue(e.RowHandle, "p_N1A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1A").ToString().Length;
                        if(e.Column.FieldName == "p_N1A")
                        {
                            if(_1A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _1B = view.GetRowCellValue(e.RowHandle, "p_N1B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1B").ToString().Length;
                        if (e.Column.FieldName == "p_N1B")
                        {
                            if (_1B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _1C = view.GetRowCellValue(e.RowHandle, "p_N1C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N1C").ToString().Length;
                        if (e.Column.FieldName == "p_N1C")
                        {
                            if (_1C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //2
                        int _2A = view.GetRowCellValue(e.RowHandle, "p_N2A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2A").ToString().Length;
                        if (e.Column.FieldName == "p_N2A")
                        {
                            if (_2A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _2B = view.GetRowCellValue(e.RowHandle, "p_N2B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2B").ToString().Length;
                        if (e.Column.FieldName == "p_N2B")
                        {
                            if (_2B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _2C = view.GetRowCellValue(e.RowHandle, "p_N2C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N2C").ToString().Length;
                        if (e.Column.FieldName == "p_N2C")
                        {
                            if (_2C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //3
                        int _3A = view.GetRowCellValue(e.RowHandle, "p_N3A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3A").ToString().Length;
                        if (e.Column.FieldName == "p_N3A")
                        {
                            if (_3A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _3B = view.GetRowCellValue(e.RowHandle, "p_N3B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3B").ToString().Length;
                        if (e.Column.FieldName == "p_N3B")
                        {
                            if (_3B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _3C = view.GetRowCellValue(e.RowHandle, "p_N3C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N3C").ToString().Length;
                        if (e.Column.FieldName == "p_N3C")
                        {
                            if (_3C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //4
                        int _4A = view.GetRowCellValue(e.RowHandle, "p_N4A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4A").ToString().Length;
                        if (e.Column.FieldName == "p_N4A")
                        {
                            if (_4A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _4B = view.GetRowCellValue(e.RowHandle, "p_N4B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4B").ToString().Length;
                        if (e.Column.FieldName == "p_N4B")
                        {
                            if (_4B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _4C = view.GetRowCellValue(e.RowHandle, "p_N4C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N4C").ToString().Length;
                        if (e.Column.FieldName == "p_N4C")
                        {
                            if (_4C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //5
                        int _5A = view.GetRowCellValue(e.RowHandle, "p_N5A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5A").ToString().Length;
                        if (e.Column.FieldName == "p_N5A")
                        {
                            if (_5A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _5B = view.GetRowCellValue(e.RowHandle, "p_N5B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5B").ToString().Length;
                        if (e.Column.FieldName == "p_N5B")
                        {
                            if (_5B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _5C = view.GetRowCellValue(e.RowHandle, "p_N5C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N5C").ToString().Length;
                        if (e.Column.FieldName == "p_N5C")
                        {
                            if (_5C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //6
                        int _6A = view.GetRowCellValue(e.RowHandle, "p_N6A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6A").ToString().Length;
                        if (e.Column.FieldName == "p_N6A")
                        {
                            if (_6A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _6B = view.GetRowCellValue(e.RowHandle, "p_N6B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6B").ToString().Length;
                        if (e.Column.FieldName == "p_N6B")
                        {
                            if (_6B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _6C = view.GetRowCellValue(e.RowHandle, "p_N6C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N6C").ToString().Length;
                        if (e.Column.FieldName == "p_N6C")
                        {
                            if (_6C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //7
                        int _7A = view.GetRowCellValue(e.RowHandle, "p_N7A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7A").ToString().Length;
                        if (e.Column.FieldName == "p_N7A")
                        {
                            if (_7A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _7B = view.GetRowCellValue(e.RowHandle, "p_N7B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7B").ToString().Length;
                        if (e.Column.FieldName == "p_N7B")
                        {
                            if (_7B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _7C = view.GetRowCellValue(e.RowHandle, "p_N7C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N7C").ToString().Length;
                        if (e.Column.FieldName == "p_N7C")
                        {
                            if (_7C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //8
                        int _8A = view.GetRowCellValue(e.RowHandle, "p_N8A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8A").ToString().Length;
                        if (e.Column.FieldName == "p_N8A")
                        {
                            if (_8A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _8B = view.GetRowCellValue(e.RowHandle, "p_N8B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8B").ToString().Length;
                        if (e.Column.FieldName == "p_N8B")
                        {
                            if (_8B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _8C = view.GetRowCellValue(e.RowHandle, "p_N8C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N8C").ToString().Length;
                        if (e.Column.FieldName == "p_N8C")
                        {
                            if (_8C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //9
                        int _9A = view.GetRowCellValue(e.RowHandle, "p_N9A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9A").ToString().Length;
                        if (e.Column.FieldName == "p_N9A")
                        {
                            if (_9A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _9B = view.GetRowCellValue(e.RowHandle, "p_N9B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9B").ToString().Length;
                        if (e.Column.FieldName == "p_N9B")
                        {
                            if (_9B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _9C = view.GetRowCellValue(e.RowHandle, "p_N9C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N9C").ToString().Length;
                        if (e.Column.FieldName == "p_N9C")
                        {
                            if (_9C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //10
                        int _10A = view.GetRowCellValue(e.RowHandle, "p_N10A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10A").ToString().Length;
                        if (e.Column.FieldName == "p_N10A")
                        {
                            if (_10A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _10B = view.GetRowCellValue(e.RowHandle, "p_N10B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10B").ToString().Length;
                        if (e.Column.FieldName == "p_N10B")
                        {
                            if (_6B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _10C = view.GetRowCellValue(e.RowHandle, "p_N10C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N10C").ToString().Length;
                        if (e.Column.FieldName == "p_N10C")
                        {
                            if (_10C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //11
                        int _11A = view.GetRowCellValue(e.RowHandle, "p_N11A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11A").ToString().Length;
                        if (e.Column.FieldName == "p_N11A")
                        {
                            if (_11A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _11B = view.GetRowCellValue(e.RowHandle, "p_N11B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11B").ToString().Length;
                        if (e.Column.FieldName == "p_N11B")
                        {
                            if (_11B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _11C = view.GetRowCellValue(e.RowHandle, "p_N11C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N11C").ToString().Length;
                        if (e.Column.FieldName == "p_N11C")
                        {
                            if (_11C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //12
                        int _12A = view.GetRowCellValue(e.RowHandle, "p_N12A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12A").ToString().Length;
                        if (e.Column.FieldName == "p_N12A")
                        {
                            if (_12A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _12B = view.GetRowCellValue(e.RowHandle, "p_N12B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12B").ToString().Length;
                        if (e.Column.FieldName == "p_N12B")
                        {
                            if (_12B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _12C = view.GetRowCellValue(e.RowHandle, "p_N12C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N12C").ToString().Length;
                        if (e.Column.FieldName == "p_N12C")
                        {
                            if (_12C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //13
                        int _13A = view.GetRowCellValue(e.RowHandle, "p_N13A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13A").ToString().Length;
                        if (e.Column.FieldName == "p_N13A")
                        {
                            if (_13A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _13B = view.GetRowCellValue(e.RowHandle, "p_N13B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13B").ToString().Length;
                        if (e.Column.FieldName == "p_N13B")
                        {
                            if (_13B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _13C = view.GetRowCellValue(e.RowHandle, "p_N13C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N13C").ToString().Length;
                        if (e.Column.FieldName == "p_N13C")
                        {
                            if (_13C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //14
                        int _14A = view.GetRowCellValue(e.RowHandle, "p_N14A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14A").ToString().Length;
                        if (e.Column.FieldName == "p_N14A")
                        {
                            if (_14A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _14B = view.GetRowCellValue(e.RowHandle, "p_N14B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14B").ToString().Length;
                        if (e.Column.FieldName == "p_N14B")
                        {
                            if (_14B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _14C = view.GetRowCellValue(e.RowHandle, "p_N14C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N14C").ToString().Length;
                        if (e.Column.FieldName == "p_N14C")
                        {
                            if (_14C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //15
                        int _15A = view.GetRowCellValue(e.RowHandle, "p_N15A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15A").ToString().Length;
                        if (e.Column.FieldName == "p_N15A")
                        {
                            if (_15A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _15B = view.GetRowCellValue(e.RowHandle, "p_N15B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15B").ToString().Length;
                        if (e.Column.FieldName == "p_N15B")
                        {
                            if (_15B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _15C = view.GetRowCellValue(e.RowHandle, "p_N15C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N15C").ToString().Length;
                        if (e.Column.FieldName == "p_N15C")
                        {
                            if (_15C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //16
                        int _16A = view.GetRowCellValue(e.RowHandle, "p_N16A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16A").ToString().Length;
                        if (e.Column.FieldName == "p_N16A")
                        {
                            if (_16A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _16B = view.GetRowCellValue(e.RowHandle, "p_N16B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16B").ToString().Length;
                        if (e.Column.FieldName == "p_N16B")
                        {
                            if (_16B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _16C = view.GetRowCellValue(e.RowHandle, "p_N16C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N16C").ToString().Length;
                        if (e.Column.FieldName == "p_N16C")
                        {
                            if (_16C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        //17
                        int _17A = view.GetRowCellValue(e.RowHandle, "p_N17A") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17A").ToString().Length;
                        if (e.Column.FieldName == "p_N17A")
                        {
                            if (_17A > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _17B = view.GetRowCellValue(e.RowHandle, "p_N17B") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17B").ToString().Length;
                        if (e.Column.FieldName == "p_N17B")
                        {
                            if (_17B > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
                            }
                        }
                        int _17C = view.GetRowCellValue(e.RowHandle, "p_N17C") is DBNull ? 0 : view.GetRowCellValue(e.RowHandle, "p_N17C").ToString().Length;
                        if (e.Column.FieldName == "p_N17C")
                        {
                            if (_17C > 7)
                            {
                                e.Appearance.BackColor = Color.Blue;
                                e.Appearance.ForeColor = Color.White;
                            }
                            else
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.ForeColor = Color.Blue;
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
        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info == null && e.SelectedControl == gridControl1)
            {
                GridView view = gridControl1.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (info.InRowCell)
                {
                    string text = view.GetRowCellDisplayText(info.RowHandle, info.Column); 
                    string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                    
                    e.Info = new ToolTipControlInfo(cellKey, text);
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            private string Unidades;
            private string UnidadesXCelda;

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
            public string p_Unidades
            {
                get { return Unidades; }
                set { Unidades = value; }
            }
            public string p_UnidadesXCelda
            {
                get { return UnidadesXCelda; }
                set { UnidadesXCelda = value; }
            }
        }
    }
}