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
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private PedidoCollection _listaPedidos = new PedidoCollection();

        private entregasEntities objBD = new entregasEntities();

        public PedidoCollection ListaPedidos { 
            get { return _listaPedidos;}       
            set { _listaPedidos = value; NotificarPropertyChanged(); }
        }
        //comprobar las fechas de entrega
        private void cargarDatos() {
            ListaPedidos.Clear();

            var qPedidos = from ped in objBD.pedidos orderby ped.fecha_pedido select ped;
            foreach (var ped in qPedidos.ToList()) { 
                ListaPedidos.Add(ped);
            }
        }

        private void NotificarPropertyChanged([CallerMemberName] string propertyName="") {
            if (PropertyChanged != null) { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public entregasEntities _objBD { 
            get { return _objBD; }
            set { _objBD = value; NotificarPropertyChanged(); }
        }

        public void guardarDatos() { 
            objBD.SaveChanges();
        }
    }
}
