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

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class VistaAlmacenes : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        public VistaAlmacenes()
        {
            InitializeComponent();
            C_Celdas = new CCeldas();
            TraerData();
        }
        void TraerData()
        {
            try
            {
                //DataSet dataLista = C_Celdas.VistaAlmacenes();
                //vGridControl1.DataSource = dataLista.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ = " + err.ToString());
            }
        }
    }
}