using SGEntregasAntonioPerezDavidMagdaleno.Components;
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

namespace SGEntregasAntonioPerezDavidMagdaleno.views
{
    /// <summary>
    /// Lógica de interacción para UserCardControl.xaml
    /// </summary>
    public partial class UserCardControl : UserControl
    {
        //CollectionViewModel cvm = new CollectionViewModel();
        clientes cli;
        //pedidos ped;
        public UserCardControl(clientes cliSel)
        {
            InitializeComponent();
            this.cli = cliSel;
            this.DataContext = cli.pedidos;

            foreach (pedidos ped in cli.pedidos)
            {
                if (ped.fecha_entrega == null)
                {
                    var pcard = new UserControl1();
                    pcard.MaxHeight = 200;
                    pcard.IdPedido = ped.id_pedido;
                    pcard.FechaPedido = ped.fecha_pedido;
                    pcard.Descripcion = ped.descripcion;
                    this.panel.Children.Add(pcard);
                }

            }
        }
    }
}
