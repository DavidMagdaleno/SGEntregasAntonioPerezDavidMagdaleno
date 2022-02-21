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
    /// Lógica de interacción para ListadoClientesTablet.xaml
    /// </summary>
    public partial class ListadoClientesTablet : Window
    {
        CollectionViewModelClientes c;
        public ListadoClientesTablet()
        {
            InitializeComponent();
            c = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            this.MouseLeftButtonUp += Cards_MouseLeftButtomUP;
            this.TouchDown += Cards_TouchDown;
        }

        //private void ejecutarSelectCliente(object sender, ExecutedRoutedEventArgs e)
        //{
        //    //MessageBox.Show(c.ListaCliente[listview.SelectedIndex].ToString());
        //    frmTablet a = new frmTablet(c.ListaCliente[listview.SelectedIndex]);
        //    a.ShowDialog();
        //}
        //private void comprobarSelectCliente(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    if (listview.SelectedItem != null)
        //    {
        //        e.CanExecute = true;
        //    }

        //}
        private void Cards_MouseLeftButtomUP(object sender, MouseButtonEventArgs e)
        {
            frmTablet a = new frmTablet(c.ListaCliente[listview.SelectedIndex]);
            a.ShowDialog();

            e.Handled = true;
        }

        private void Cards_TouchDown(object sender, TouchEventArgs e)
        {
            frmTablet a = new frmTablet(c.ListaCliente[listview.SelectedIndex]);
            a.ShowDialog();
            e.Handled = true;
        }
    }
}
