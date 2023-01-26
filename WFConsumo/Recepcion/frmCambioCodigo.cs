using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Componentes;
using DevExpress.ExpressApp; 
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.Recepcion
{
    public partial class frmCambioCodigo : DevExpress.XtraEditors.XtraForm
    {
        CCamion oCamion = new CCamion();
        CChofer oChofer = new CChofer();
        CFabricante oFabricante = new CFabricante();
        CCeldas oCelda = new CCeldas();
        CSucursal oSucursal = new CSucursal();
        CRecepcion oRecep = new CRecepcion();
        public int iOrden = 0;
        List<CRN.Entidades.RecepcionProducto> LisRecDetPrd = new List<CRN.Entidades.RecepcionProducto>();
        List<CRN.Entidades.RecepcionDetalle> LisRecDet = new List<CRN.Entidades.RecepcionDetalle>();
        //
        List<CRN.Entidades.RecepcionProducto> _LisRecDetPrdFiltrar = new List<CRN.Entidades.RecepcionProducto>();
        List<CRN.Entidades.RecepcionDetalle> _LisRecDetFiltrar = new List<CRN.Entidades.RecepcionDetalle>();

        public frmCambioCodigo()
        {
            InitializeComponent();
            CargarCombox();
        }
        private void CargarCombox()
        {
            DataSet dtsCamion = oCamion.SeleccionarCamion();
          
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
             
        }

        private void frmRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}