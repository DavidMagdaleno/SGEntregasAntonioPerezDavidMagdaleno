using SGEntregasAntonioPerezDavidMagdaleno.viewModel;
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

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    /// <summary>
    /// Lógica de interacción para SelectClientePC.xaml
    /// </summary>
    public partial class SelectClientePC : Window
    {
        CollectionViewModelClientes c;
        public SelectClientePC()
        {
            InitializeComponent();
            c = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            cargarClientes();
        }

        private void cargarClientes()
        {
            using (entregasEntities objBD = new entregasEntities())
            {
                this.cb_cliente.Items.Clear();
                var qclient = from c in objBD.clientes select c;
                foreach (var esp in qclient.ToList())
                {
                    this.cb_cliente.Items.Add(esp.apellidos+","+esp.nombre);
                }
                this.cb_cliente.SelectedIndex = 0;
            }
        }

        private void btAceptarClie_Click(object sender, RoutedEventArgs e)
        {
            frmPedidosPC f1 = new frmPedidosPC(c.ListaCliente[cb_cliente.SelectedIndex]);
            f1.ShowDialog();
        }

        private void btCancelarClie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
