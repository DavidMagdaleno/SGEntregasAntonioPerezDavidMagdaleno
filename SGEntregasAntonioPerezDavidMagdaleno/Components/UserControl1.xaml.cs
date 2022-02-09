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
        public static readonly DependencyProperty Usernameproperty =
            DependencyProperty.Register("Username", typeof(String), typeof(UserControl), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty Ageproperty =
            DependencyProperty.Register("Age", typeof(int), typeof(UserControl), new PropertyMetadata(0));
        public static readonly DependencyProperty FavoriteColorproperty =
            DependencyProperty.Register("FavoriteColor", typeof(Color), typeof(UserControl), new PropertyMetadata(Color.FromRgb(0, 0, 0)));
        public UserControl1()
        {
            InitializeComponent();
        }

        public String Username
        {
            get { return (String)GetValue(Usernameproperty); }
            set { SetValue(Usernameproperty, value); }
        }

        public int Age
        {
            get { return (int)GetValue(Ageproperty); }
            set { SetValue(Ageproperty, value); }
        }
        public Color FavoriteColor
        {
            get { return (Color)GetValue(FavoriteColorproperty); }
            set { SetValue(FavoriteColorproperty, value); }
        }
    }
}
