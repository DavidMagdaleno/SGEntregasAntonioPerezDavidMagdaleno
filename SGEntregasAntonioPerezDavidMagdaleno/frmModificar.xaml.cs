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
            this.DataContext = copiaclien;
            this.clien = cliente;
            cvc = (CollectionViewModelClientes)this.Resources["ColeccionVMCL"];
            cargarProvincias();
            this.txt_dni.Text = clien.dni;
            this.txt_nombre.Text = clien.nombre;
            this.txt_apellidos.Text = clien.apellidos;
            this.txt_domicilio.Text = clien.domicilio;
            this.txt_email.Text = clien.email;
            this.txt_localidad.Text = clien.localidad;
        }

        private void cargarProvincias()
        {
            using (entregasEntities objBD = new entregasEntities())
            {
                String aux = "";
                this.cb_provincia.Items.Clear();
                var qprovincia = from c in objBD.provincias select c;
                foreach (var pr in qprovincia.ToList())
                {
                    this.cb_provincia.Items.Add(pr.nombre_provincia);
                    if (clien.provincia == pr.id_provincia) {
                        aux = pr.nombre_provincia;
                    }
                }
                this.cb_provincia.SelectedItem = aux;
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
                this.copiaclien.nombre = txt_nombre.Text;
                this.copiaclien.apellidos = txt_apellidos.Text;
                this.copiaclien.domicilio = txt_domicilio.Text;
                this.copiaclien.email = txt_email.Text;
                this.copiaclien.localidad = txt_localidad.Text;
                this.copiaclien.provincia = cb_provincia.SelectedIndex+1;
                actualizar(copiaclien, clien);
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
