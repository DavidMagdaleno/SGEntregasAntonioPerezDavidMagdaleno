using SGEntregasAntonioPerezDavidMagdaleno.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SGEntregasAntonioPerezDavidMagdaleno.viewModel
{
    public class CollectionViewModelClientes : INotifyPropertyChanged
    {
        public CollectionViewModelClientes()
        {
            cargarDatos2();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private ClienteCollection _listaCliente = new ClienteCollection();
        private entregasEntities objBD = new entregasEntities();

        public ClienteCollection ListaCliente
        {
            get { return _listaCliente; }
            set { _listaCliente = value; NotificarPropertyChanged(); }
        }

        private void cargarDatos2()
        {
            ListaCliente.Clear();

            var qClientes = from cl in objBD.clientes orderby cl.apellidos select cl;
            foreach (var cli in qClientes.ToList())
            {
                ListaCliente.Add(cli);
                //System.Windows.MessageBox.Show(cli.dni.ToString());
            }
        }

        private void NotificarPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public entregasEntities _objBD
        {
            get { return objBD; }
            set {objBD = value; NotificarPropertyChanged(); }
        }

        public void guardarDatos()
        {
            objBD.SaveChanges();
        }
    }
}
