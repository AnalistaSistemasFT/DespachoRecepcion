using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmStock: Form
    {
        CAD.CADPackingList oPaquete = new CAD.CADPackingList();
       
       
        public frmStock()
        {
            InitializeComponent();
            cargarItems();
        } 
        private void cargarItems()
        {
            try
            {
                int _IdSucursal = Convert.ToInt32(Entidades.utilitario.iSucursal);
                DataSet dtsAnotacion = oPaquete.TraerItemSucursal(_IdSucursal);
                this.gridPaquetes.DataSource = dtsAnotacion.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
    }
}
