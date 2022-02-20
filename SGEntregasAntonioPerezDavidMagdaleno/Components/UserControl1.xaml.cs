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

namespace SGEntregasAntonioPerezDavidMagdaleno.Components
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty IdPedidoproperty =
            DependencyProperty.Register("IdPedido", typeof(int), typeof(UserControl1), new PropertyMetadata(0));
        public static readonly DependencyProperty Fechaproperty =
            DependencyProperty.Register("FechaPedido", typeof(DateTime), typeof(UserControl1), new PropertyMetadata());
        public static readonly DependencyProperty Descripcionproperty =
            DependencyProperty.Register("Descripcion", typeof(String), typeof(UserControl1), new PropertyMetadata(String.Empty));


        public UserControl1()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += Cards_MouseLeftButtomUP;
            this.TouchDown += Cards_TouchDown;
        }

        public int IdPedido
        {
            get { return (int)GetValue(IdPedidoproperty); }
            set { SetValue(IdPedidoproperty, value); }
        }

        public DateTime FechaPedido
        {
            get { return (DateTime)GetValue(Fechaproperty); }
            set { SetValue(Fechaproperty, value); }
        }
        public String Descripcion
        {
            get { return (String)GetValue(Descripcionproperty); }
            set { SetValue(Descripcionproperty, value); }
        }

        private void Cards_MouseLeftButtomUP(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Click con el raton");
            //MessageBox.Show(sender.ToString());
            //MessageBox.Show(((UserControl1)sender).IdPedido.ToString());
            FirmaTablet f1 = new FirmaTablet(((UserControl1)sender).IdPedido);
            f1.ShowDialog();
            e.Handled = true;
        }

        private void Cards_TouchDown(object sender, TouchEventArgs e)
        {
            //MessageBox.Show("Click con el dedo");
            //MessageBox.Show(((UserControl1)sender).IdPedido.ToString());
            FirmaTablet f1 = new FirmaTablet(((UserControl1)sender).IdPedido);
            f1.ShowDialog();
            e.Handled = true;
        }
    }
}
