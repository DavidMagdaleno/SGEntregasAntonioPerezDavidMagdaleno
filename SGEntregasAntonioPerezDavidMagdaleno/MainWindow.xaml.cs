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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CommandBinding_ComprobarSalir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_EjecutarSalir(object sender, ExecutedRoutedEventArgs e)
        {
            // MessageBox.Show("Mi comando personalizado Salir");
            this.Close();

        }
        private void CommandBinding_ComprobarPc(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_EjecutarPc(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Mi comando personalizado Pc");
        }
        private void CommandBinding_ComprobarTablet(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_EjecutarTablet(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("Mi comando personalizado Tablet");
            frmTablet f1=new frmTablet();
            f1.ShowDialog();
        }
    }
}
