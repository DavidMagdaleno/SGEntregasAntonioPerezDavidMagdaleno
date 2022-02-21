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
            this.dgvPedido.ItemsSource = cli.pedidos;
            
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
            int indice = 0;
            int contador = 0;
            var qpedi = from c in cvm.objBD.pedidos orderby c.fecha_entrega select c;
            foreach (var pr in qpedi.ToList())
            {
                if (pr.id_pedido == ((pedidos)dgvPedido.SelectedItem).id_pedido)
                {
                    indice = contador;
                }
                else {
                    contador++;
                }
            }


            //System.Windows.MessageBox.Show(cvm.ListaPedidos[(((pedidos)dgvPedido.Items.CurrentItem).id_pedido) - 1].fecha_entrega.ToString());
            if (cvm.ListaPedidos[indice].fecha_entrega == null)
            {
                ModificarPedidos m = new ModificarPedidos(cvm.ListaPedidos[indice]);
                m.ShowDialog();
            }
            else {
                System.Windows.MessageBox.Show("Este pedido ya esta compleatado");
            }
        }
        private void comprobarModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ejecutarEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            int indice = 0;
            int contador = 0;
            var qpedi = from c in cvm.objBD.pedidos orderby c.fecha_entrega select c;
            foreach (var pr in qpedi.ToList())
            {
                if (pr.id_pedido == ((pedidos)dgvPedido.SelectedItem).id_pedido)
                {
                    indice = contador;
                }
                else
                {
                    contador++;
                }
            }

            System.Windows.Forms.DialogResult resp = new System.Windows.Forms.DialogResult();
            pedidos objPedido = new pedidos();
            resp = System.Windows.Forms.MessageBox.Show("Estas seguro de quieres eliminarlo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                cvm.objBD.pedidos.Remove(cvm.ListaPedidos[indice]);
                cvm.ListaPedidos.Remove(cvm.ListaPedidos[indice]);
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
            cvm.guardarDatosPedidos();
        }
        private void comprobarGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
