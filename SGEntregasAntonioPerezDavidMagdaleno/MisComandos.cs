using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGEntregasAntonioPerezDavidMagdaleno
{
    class MisComandos
    {
        public static RoutedUICommand escapeSalir = new RoutedUICommand("accion cuando se pulsa algo", "Pulsar", typeof(MisComandos), new InputGestureCollection() { new KeyGesture(Key.Escape) });
        public static RoutedUICommand modoTablet = new RoutedUICommand("accion cuando se pulsa TabletMode", "Pulsar", typeof(MisComandos), new InputGestureCollection());
        public static RoutedUICommand modoPc = new RoutedUICommand("accion cuando se pulsa PcMode", "Pulsar", typeof(MisComandos), new InputGestureCollection());
        public static RoutedUICommand selectCliente = new RoutedUICommand("accion cuando se pulsa un cliente", "Pulsar", typeof(MisComandos), new InputGestureCollection());
        
        public static RoutedUICommand anadir = new RoutedUICommand("añadir", "anadir", typeof(MisComandos));
        public static RoutedUICommand modificar = new RoutedUICommand("Modificar", "modificar", typeof(MisComandos));
        public static RoutedUICommand eliminar = new RoutedUICommand("eliminar", "eliminar", typeof(MisComandos));
        public static RoutedUICommand guardar = new RoutedUICommand("guardar", "guardar", typeof(MisComandos));
    }
}
