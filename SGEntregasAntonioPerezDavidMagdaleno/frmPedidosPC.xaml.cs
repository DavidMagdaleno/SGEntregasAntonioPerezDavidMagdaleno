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
    /// Lógica de interacción para frmPedidosPC.xaml
    /// </summary>
    public partial class frmPedidosPC : Window
    {
        CollectionViewModel cvm;
        public frmPedidosPC()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVMP"];
        }

        private void ejecutarAnadir(object sender, ExecutedRoutedEventArgs e)
        {
            //frmAñadirPacientes a = new frmAñadirPacientes(cvm);
            //a.ShowDialog();
        }
        private void comprobarAnadir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }
        private void ejecutarModificar(object sender, ExecutedRoutedEventArgs e)
        {
            //frmModificar m = new frmModificar(cvm.ListaMedicos[listview.SelectedIndex]);
            //m.ShowDialog();
        }
        private void comprobarModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ejecutarEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            /*System.Windows.Forms.DialogResult resp = new System.Windows.Forms.DialogResult();
            medicos objMedico = new medicos();
            if (objMedico.atencsmedicas.Count > 0)
            {
                resp = System.Windows.Forms.MessageBox.Show("Este medico tiene atenciones medicas, quieres continuar para borralo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    while (objMedico.atencsmedicas.Count > 0)
                    {
                        var atencion = (atencsmedicas)objMedico.atencsmedicas.First();
                        cvm._objBD.atencsmedicas.Remove(atencion);
                    }
                    //se elimina la tabla de la bd
                    cvm._objBD.medicos.Remove(objMedico);
                    //se elimina de la lista
                    cvm.ListaMedicos.RemoveAt(listview.SelectedIndex);
                }
            }
            else
            {
                resp = System.Windows.Forms.MessageBox.Show("Estas seguro de quieres eliminarlo", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    cvm._objBD.medicos.Remove(objMedico);
                    cvm.ListaMedicos.RemoveAt(listview.SelectedIndex);
                }
            }*/
        }
        private void comprobarEliminar(object sender, CanExecuteRoutedEventArgs e)
        {
            //selectedIndex=-1
            //if (listview.SelectedItem != null)
            {
                //e.CanExecute = true;
            }
        }
        private void ejecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            //objBD.SaveChanges();
            cvm.guardarDatos();
        }
        private void comprobarGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
