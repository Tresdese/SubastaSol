using ClienteSubastaNet.SubastaServicioRemoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteSubastaNet
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary> 

    [ CallbackBehavior(UseSynchronizationContext = false ) ]

    public partial class MainWindow : Window, ISubastaServicioCallback
    {

        private SubastaServicioClient conexion;
        private string nombre = "Cliente_1";
        public MainWindow()
        {
            InitializeComponent();
            ConectarAlServidor();
        }

        private void ConectarAlServidor()
        {
            InstanceContext contexto = new InstanceContext(this);

            conexion = new SubastaServicioClient(contexto);

            Application.Current.Dispatcher.BeginInvoke(new Action(() => { 
                conexion.EntrarSala(nombre);
            }));
        }
        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double miOferta = double.Parse(txtMiOferta.Text);
                Task.Run(() => {
                    conexion.EnviarOferta(nombre, miOferta);
                });
                txtMiOferta.Text = "";

            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void MensajeDelSistema(string mensaje)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(async () => {
                txtNotificaciones.Text += mensaje + "\n";
                txtNotificaciones.ScrollToEnd();
            }));
        }

        public void NotificarNuevaOfertaMax(string nombreUsuario, double nuevoMonto)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(async () => {
                txtLiderSubasta.Text = $"{nombreUsuario} va ganando con ${nuevoMonto}";
            }));
        }
    }
}
