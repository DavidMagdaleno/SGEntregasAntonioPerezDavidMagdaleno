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
    /// Lógica de interacción para FirmaTablet.xaml
    /// </summary>
    public partial class FirmaTablet : Window
    {
        CollectionViewModel cvm;
        CollectionViewModelClientes cvc;
        private pedidos ped;
        private pedidos copiaped;

        public FirmaTablet(int pedido)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVMP"];
            var qPedido = from p in cvm.objBD.pedidos
                          where p.id_pedido==pedido
                          select p;
            var aux = qPedido.ToList();
            var qpedi = aux.FirstOrDefault();

            //Se hace una copia para que no se actualize la lista hasta que no se pulse aceptar
            copiaped = (pedidos)qpedi.Clone();
            this.DataContext = copiaped;
            this.ped = qpedi;
            cvc = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            txt_FechPedido.SelectedDate = ped.fecha_pedido;
            txt_Descripcion.Text = ped.descripcion;
            txt_FechEntrega.Text = DateTime.Today.Date.ToString();
            cargarClientes();
        }

        private void cargarClientes()
        {
            String aux = "";
            String aux2 = "";
            this.cb_cli.Items.Clear();
            var qClien = from c in cvc.objBD.clientes select c;
            foreach (var pr in qClien.ToList())
            {
                this.cb_cli.Items.Add(pr.apellidos + ", " + pr.nombre);
                if (ped.cliente.Equals(pr.dni))
                {
                    aux = pr.apellidos;
                    aux2 = pr.nombre;
                }
            }
            this.cb_cli.SelectedItem = aux + ", " + aux2;
        }

        private void btAceptarModPedi_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_FechPedido.SelectedDate.HasValue == true &&
                this.txt_Descripcion.Text.Trim() != "" &&
                cb_cli.SelectedIndex != -1 &&
                txt_Firma.Strokes.Count > 0
                )
            {
                this.copiaped.fecha_entrega = DateTime.Today.Date;
                ponerFirma();
                actualizar(copiaped, ped);
                this.Close();
                cvm.objBD.SaveChanges();
                MessageBox.Show("Modificado correctamente", "Exito");
            }
            else
            {
                MessageBox.Show("Introduce todos los campos", "Error");
            }
        }

        private void actualizar(pedidos pedidoOrigen, pedidos pedidoDestino)
        {
            pedidoDestino.cliente = pedidoOrigen.cliente;
            pedidoDestino.fecha_pedido = pedidoOrigen.fecha_pedido;
            pedidoDestino.descripcion = pedidoOrigen.descripcion;
            pedidoDestino.fecha_entrega = pedidoOrigen.fecha_entrega;
            pedidoDestino.firma = pedidoOrigen.firma;
        }

        private void ponerFirma()
        {
            
            MemoryStream ms =new MemoryStream();
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
