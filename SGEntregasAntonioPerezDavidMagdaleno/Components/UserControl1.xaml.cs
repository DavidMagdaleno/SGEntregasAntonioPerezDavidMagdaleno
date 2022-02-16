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
            DependencyProperty.Register("IdPedido", typeof(int), typeof(UserControl), new PropertyMetadata(0));
        public static readonly DependencyProperty Ageproperty =
            DependencyProperty.Register("FechaPedido", typeof(DateTime), typeof(UserControl), new PropertyMetadata(0));
        public static readonly DependencyProperty FavoriteColorproperty =
            DependencyProperty.Register("Descripcion", typeof(String), typeof(UserControl), new PropertyMetadata(String.Empty));
        public UserControl1()
        {
            InitializeComponent();
        }

        public int IdPedido
        {
            get { return (int)GetValue(IdPedidoproperty); }
            set { SetValue(IdPedidoproperty, value); }
        }

        public DateTime FechaPedido
        {
            get { return (DateTime)GetValue(Ageproperty); }
            set { SetValue(Ageproperty, value); }
        }
        public String Descripcion
        {
            get { return (String)GetValue(FavoriteColorproperty); }
            set { SetValue(FavoriteColorproperty, value); }
        }
    }
}
