using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SGEntregasAntonioPerezDavidMagdaleno.Components;
using SGEntregasAntonioPerezDavidMagdaleno.viewModel;

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    /// <summary>
    /// Lógica de interacción para frmPedidosPC.xaml
    /// </summary>
    public partial class frmPedidosPC : Window
    {
        clientes cli;
        CollectionViewModel cvm;
        List<pedidos> auxi = new List<pedidos>();
        public frmPedidosPC(clientes cliSel)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVMP"];
            this.cli = cliSel;
            this.DataContext = cli.pedidos;
            

            foreach (pedidos ped in cli.pedidos)
            {
                if (ped.fecha_entrega == null)
                {
                    this.dgvPedido.ItemsSource = cli.pedidos;
                    auxi.Add(ped);
                }

            }
        }

        private void ejecutarAnadir(object sender, ExecutedRoutedEventArgs e)
        {
            AnadirPedidos a = new AnadirPedidos(cvm);
            a.ShowDialog();
        }
        private void comprobarAnadir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }
        private void ejecutarModificar(object sender, ExecutedRoutedEventArgs e)
        {
            ModificarPedidos m = new ModificarPedidos(auxi[dgvPedido.SelectedIndex]);
            m.ShowDialog();
        }
        private void comprobarModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ejecutarEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult resp = new System.Windows.Forms.DialogResult();
            pedidos objPedido = new pedidos();
            resp = System.Windows.Forms.MessageBox.Show("Estas seguro de quieres eliminarlo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                cvm._objBD.pedidos.Remove(objPedido);
                //cvm.ListaPedidos.RemoveAt(dgvPedido.SelectedIndex);
                cvm.ListaPedidos.Remove(auxi[dgvPedido.SelectedIndex]);
            }
        }
        private void comprobarEliminar(object sender, CanExecuteRoutedEventArgs e)
        {
            //selectedIndex=-1
            if (dgvPedido.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
        }
        private void ejecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            //objBD.SaveChanges();
            cvm.guardarDatos();
        }
        private void comprobarGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
