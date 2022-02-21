using SGEntregasAntonioPerezDavidMagdaleno.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para ModificarPedidos.xaml
    /// </summary>
    public partial class ModificarPedidos : Window
    {
        CollectionViewModel cvm;
        CollectionViewModelClientes cvc;
        private pedidos ped;
        private pedidos copiaped;
        //byte[] firmabinario = null;
        public ModificarPedidos(pedidos pedido)
        {
            InitializeComponent();
            //Se hace una copia para que no se actualize la lista hasta que no se pulse aceptar
            copiaped = (pedidos)pedido.Clone();
            this.DataContext = copiaped;
            this.ped = pedido;
            cvc = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            cvm = (CollectionViewModel)this.Resources["ColeccionVMP"];
            txt_FechPedido.SelectedDate = ped.fecha_pedido;
            txt_Descripcion.Text = ped.descripcion;
            cargarClientes();
        }

        private void cargarClientes()
        {
            String aux="";
            String aux2 = "";
            this.cb_cli.Items.Clear();
            var qClien = from c in cvc.objBD.clientes select c;
            foreach (var pr in qClien.ToList())
            {
                this.cb_cli.Items.Add(pr.apellidos + ", " + pr.nombre);
                if (ped.cliente.Equals(pr.dni)) {
                    aux = pr.apellidos;
                    aux2 = pr.nombre;
                }
            }
            this.cb_cli.SelectedItem = aux+", "+ aux2;
        }

        private void btAceptarModPedi_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_FechPedido.SelectedDate.HasValue == true &&
                this.txt_Descripcion.Text.Trim() != "" &&
                cb_cli.SelectedIndex != -1 && 
                txt_FechEntrega.SelectedDate.HasValue==true &&
                txt_Firma.Strokes.Count>0
                )
            {
                this.copiaped.fecha_entrega = txt_FechEntrega.SelectedDate;
                this.copiaped.descripcion = txt_Descripcion.Text;
                ponerFirma();
                actualizar(copiaped, ped);
                cvm.objBD.SaveChanges();
                this.Close();
                MessageBox.Show("Modificado correctamente", "Exito");
            }
            else
            {
                MessageBox.Show("Introduce todos los campos", "Error");
            }
        }

        private void actualizar(pedidos pedidoOrigen, pedidos pedidoDestino)
        {
            //pedidoDestino.cliente = pedidoOrigen.cliente;
            //pedidoDestino.fecha_pedido = pedidoOrigen.fecha_pedido;
            //pedidoDestino.descripcion = pedidoOrigen.descripcion;
            pedidoDestino.fecha_entrega = pedidoOrigen.fecha_entrega;
            pedidoDestino.firma = pedidoOrigen.firma;
        }

        private void ponerFirma() {
            MemoryStream ms = new MemoryStream();
            txt_Firma.Strokes.Save(ms);
            byte[] bytes = ms.ToArray();
            this.copiaped.firma = bytes;
        }
        private void btCancelarModPedi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
