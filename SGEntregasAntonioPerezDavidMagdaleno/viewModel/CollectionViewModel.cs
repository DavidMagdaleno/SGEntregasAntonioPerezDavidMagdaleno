using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SGEntregasAntonioPerezDavidMagdaleno.Model;

namespace SGEntregasAntonioPerezDavidMagdaleno.viewModel
{
    public class CollectionViewModel : INotifyPropertyChanged
    {
        public CollectionViewModel() {
            cargarDatos();
            //cargarDatos2();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private PedidoCollection _listaPedidos = new PedidoCollection();
        //private ClienteCollection _listaCliente = new ClienteCollection();

        private entregasEntities objBD = new entregasEntities();

        public PedidoCollection ListaPedidos { 
            get { return _listaPedidos;}       
            set { _listaPedidos = value; NotificarPropertyChanged(); }
        }

        //public ClienteCollection ListaCliente
        //{
        //    get { return _listaCliente; }
        //    set { _listaCliente = value; NotificarPropertyChanged(); }
        //}
        
        private void cargarDatos() {
            ListaPedidos.Clear();

            var qPedidos = from ped in objBD.pedidos orderby ped.fecha_pedido select ped;
            foreach (var pedi in qPedidos.ToList())
            { 
                ListaPedidos.Add(pedi);
            }
        }

        //private void cargarDatos2()
        //{
        //    ListaCliente.Clear();

        //    var qClientes = from cl in objBD.clientes orderby cl.apellidos select cl;
        //    foreach (var cli in qClientes.ToList())
        //    {
        //        ListaCliente.Add(cli);
        //    }
        //}

        private void NotificarPropertyChanged([CallerMemberName] string propertyName="") {
            if (PropertyChanged != null) { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public entregasEntities _objBD { 
            get { return objBD; }
            set { objBD = value; NotificarPropertyChanged(); }
        }

        public void guardarDatos() { 
            objBD.SaveChanges();
        }
    }
}
