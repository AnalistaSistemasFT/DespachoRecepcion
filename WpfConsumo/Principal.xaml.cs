using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using CRN.Componentes;
using CRN.Entidades;

namespace WpfConsumo
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        COrdenSync cOrden;
        OrdenSync orden;
        public Principal()
        {
            InitializeComponent();
            CargaForm();
        }
        void CargaForm()
        {
            cOrden = new COrdenSync();
            string where = "status='OPEN'";
            DataSet ds= cOrden.TraerTodosOrdenSync("OPEN",12070);
            
            EnlazarCombo(ds.Tables[0],cmbOrdenes);

        }
        void EnlazarCombo(DataTable t,ComboBox cb)
        {
            cb.ItemsSource = t.DefaultView;
            cb.DisplayMemberPath = "OrdenId";
            cb.SelectedValuePath = "OrdenId";
            cb.SelectedValue = "Binding";
        }

        private void cmbOrdenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cmbOrdenes.SelectedItem as OrdenSync;
            MessageBox.Show(item.OrdenId.ToString());
        }
    }
}
