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
using System.Windows.Forms;
using System.Windows.Shapes;
using SGEntregasAntonioPerezDavidMagdaleno.viewModel;

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    /// <summary>
    /// Lógica de interacción para frmClientesPC.xaml
    /// </summary>
    public partial class frmClientesPC : Window
    {
        CollectionViewModelClientes cvm;
        public frmClientesPC()
        {
            InitializeComponent();
            cvm = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
        }

        private void ejecutarAnadir(object sender, ExecutedRoutedEventArgs e)
        {
            frmAnadir a = new frmAnadir(cvm);
            a.ShowDialog();
        }
        private void comprobarAnadir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }
        private void ejecutarModificar(object sender, ExecutedRoutedEventArgs e)
        {
            frmModificar m = new frmModificar(cvm.ListaCliente[listview.SelectedIndex]);
            m.ShowDialog();
        }
        private void comprobarModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listview.SelectedItem != null)
            {
                e.CanExecute = true;
            }
        }
        private void ejecutarEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult resp = new DialogResult();
            clientes objCliente = new clientes();
            if (cvm.ListaCliente[listview.SelectedIndex].pedidos.Count > 0)
            //if (objCliente.pedidos.Count>0)
            {
                resp = System.Windows.Forms.MessageBox.Show("Este cliente tiene pedidos, quieres continuar para borralo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    //while (objCliente.pedidos.Count > 0)
                    while (cvm.ListaCliente[listview.SelectedIndex].pedidos.Count > 0)
                    {
                        //var pedi = (pedidos)objCliente.pedidos.First();
                        var pedi = cvm.ListaCliente[listview.SelectedIndex].pedidos.ToList().First();
                        cvm.ListaCliente[listview.SelectedIndex].pedidos.Remove(pedi);
                        cvm.objBD.pedidos.Remove(pedi);
                    }
                    //se elimina la tabla de la bd
                    
                    cvm.objBD.clientes.Remove(cvm.ListaCliente[listview.SelectedIndex]);
                    cvm.ListaCliente.Remove(cvm.ListaCliente[listview.SelectedIndex]);
                    //se elimina de la lista
                    //cvm.ListaCliente.RemoveAt(listview.SelectedIndex);
                    cvm.objBD.SaveChanges();
                }
            }
            else
            {
                resp = System.Windows.Forms.MessageBox.Show("Estas seguro de quieres eliminarlo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    cvm.objBD.clientes.Remove(cvm.ListaCliente[listview.SelectedIndex]);
                    //cvm.ListaCliente.RemoveAt(listview.SelectedIndex);
                    cvm.ListaCliente.Remove(cvm.ListaCliente[listview.SelectedIndex]);
                    cvm.objBD.SaveChanges();

                }
            }
        }
        private void comprobarEliminar(object sender, CanExecuteRoutedEventArgs e)
        {
            //selectedIndex=-1
            if (listview.SelectedItem != null)
            {
                e.CanExecute = true;
            }
        }
        private void ejecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            //objBD.SaveChanges();
            cvm.guardarDatosClientes();
        }
        private void comprobarGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
