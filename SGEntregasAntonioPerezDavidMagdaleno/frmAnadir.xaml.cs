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
    /// Lógica de interacción para frmAnadir.xaml
    /// </summary>
    public partial class frmAnadir : Window
    {
        CollectionViewModelClientes cvm;
        public frmAnadir(CollectionViewModelClientes coleccion)
        {
            InitializeComponent();
            this.cvm = coleccion;
            cargarProvincias();
        }

        private void cargarProvincias()
        {
            //using (hospitalEntities objBD = new hospitalEntities()) {
            this.cb_provincia.Items.Clear();
            var qprovincia = from c in cvm.objBD.provincias select c;
            foreach (var pr in qprovincia.ToList())
            {
                this.cb_provincia.Items.Add(pr.nombre_provincia);
            }
            this.cb_provincia.SelectedIndex = 0;
            //}
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
                clientes objClientes = new clientes()
                //cvm.ListaMedicos.Add(new medicos()
                {
                    dni = txt_dni.Text,
                    apellidos = txt_apellidos.Text,
                    provincia = int.Parse(cb_provincia.SelectedItem.ToString()),
                    email = txt_email.Text,
                    nombre = txt_nombre.Text,
                    localidad = txt_localidad.Text,
                    domicilio = txt_domicilio.Text
                };
                cvm.objBD.clientes.Add(objClientes);
                cvm.ListaCliente.Add(objClientes);
                MessageBox.Show("Insertado Correctamente", "EXITO");
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
