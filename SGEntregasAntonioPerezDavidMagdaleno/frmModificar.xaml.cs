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
using SGEntregasAntonioPerezDavidMagdaleno.viewModel;

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    /// <summary>
    /// Lógica de interacción para frmModificar.xaml
    /// </summary>
    public partial class frmModificar : Window
    {
        private clientes clien;
        private clientes copiaclien;
        CollectionViewModelClientes cvc;
        public frmModificar(clientes cliente)
        {
            InitializeComponent();
            //Se hace una copia para que no se actualize la lista hasta que no se pulse aceptar
            copiaclien = (clientes)cliente.Clone();
            cvc = (CollectionViewModelClientes)this.Resources["ColeccionVMC"];
            this.DataContext = copiaclien;
            this.clien = cliente;
            cargarProvincias();
        }

        private void cargarProvincias()
        {
            using (entregasEntities objBD = new entregasEntities())
            {
                this.cb_provincia.Items.Clear();
                var qprovincia = from c in objBD.provincias select c;
                foreach (var pr in qprovincia.ToList())
                {
                    this.cb_provincia.Items.Add(pr.nombre_provincia);
                }
                this.cb_provincia.SelectedIndex = 0;
            }
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_nombre.Text.Trim() != "" &&
                this.txt_apellidos.Text.Trim() != "" &&
                cb_provincia.SelectedIndex != -1 &&
                txt_email.Text.Trim() != "" &&
                txt_domicilio.Text.Trim() != "" &&
                txt_localidad.Text.Trim() != "" &&
                txt_dni.Text.Trim() != "")
            {

                actualizar(copiaclien, clien);
                //cvc.guardarDatosClientes();
                cvc.objBD.SaveChanges();
                this.Close();
                MessageBox.Show("Modificado correctamente", "Exito");
            }
            else
            {
                MessageBox.Show("Introduce todos los campos", "Error");
            }
        }

        private void actualizar(clientes clienteOrigen, clientes clienteDestino)
        {
            clienteDestino.nombre = clienteOrigen.nombre;
            clienteDestino.apellidos = clienteOrigen.apellidos;
            clienteDestino.email = clienteOrigen.email;
            //clienteDestino.dni = clienteOrigen.dni;
            clienteDestino.domicilio = clienteOrigen.domicilio;
            clienteDestino.provincia = clienteOrigen.provincia;

        }
        

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
