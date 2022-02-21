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
    /// Lógica de interacción para AnadirPedidos.xaml
    /// </summary>
    public partial class AnadirPedidos : Window
    {
        CollectionViewModel cvm;
        CollectionViewModelClientes cvc;
        public AnadirPedidos(CollectionViewModel coleccion)
        {
            InitializeComponent();
            this.cvm = coleccion;
            cvc = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            cargarClientes();
        }

        private void cargarClientes()
        {
            this.cb_cli.Items.Clear();
            var qClien = from c in cvc.objBD.clientes orderby c.apellidos select c;
            foreach (var pr in qClien.ToList())
            {
                this.cb_cli.Items.Add(pr.apellidos+", "+pr.nombre);
            }
            this.cb_cli.SelectedIndex = 0;
        }

        private void btAceptarAnaPedi_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_FechPedido.SelectedDate.HasValue== true &&
                this.txt_Descripcion.Text.Trim() != "" &&
                cb_cli.SelectedIndex != -1
                )
            {
                pedidos objPedidos = new pedidos()
                //cvm.ListaMedicos.Add(new medicos()
                {
                    descripcion = txt_Descripcion.Text,
                    cliente = cvc.ListaCliente[cb_cli.SelectedIndex].dni,
                    fecha_pedido= (DateTime)txt_FechPedido.SelectedDate
                };

                cvm.objBD.pedidos.Add(objPedidos);
                cvm.ListaPedidos.Add(objPedidos);
                MessageBox.Show("Insertado Correctamente", "EXITO");
                this.Close();
            }
        }

        private void btCancelarAnaPedi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
