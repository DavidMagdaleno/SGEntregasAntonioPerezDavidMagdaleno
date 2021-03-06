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
    /// Lógica de interacción para Opciones.xaml
    /// </summary>
    public partial class Opciones : Window
    {
        
        public Opciones()
        {
            InitializeComponent();
        }

        private void GestionCliente_Click(object sender, RoutedEventArgs e)
        {
            frmClientesPC a = new frmClientesPC();
            a.ShowDialog();
        }

        private void GestionPedidos_Click(object sender, RoutedEventArgs e)
        {
            SelectClientePC s1 = new SelectClientePC();
            s1.ShowDialog();
            //frmPedidosPC a = new frmPedidosPC();
            //a.ShowDialog();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
