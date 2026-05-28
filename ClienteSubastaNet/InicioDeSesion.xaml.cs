using ClienteSubastaNet.InicioSesionServicio;
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

namespace ClienteSubastaNet
{
    /// <summary>
    /// Lógica de interacción para InicioDeSesion.xaml
    /// </summary>
    public partial class InicioDeSesion : Window
    {
        private InicioSesionServicioClient cliente = new InicioSesionServicioClient();
        private string nombre = "";

        public InicioDeSesion()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreUsuario = txtNombreUsuario.Text;
                Task.Run(() => {
                    bool sesionIniciada = cliente.IniciarSesion(nombreUsuario);
                    IrSubasta(nombreUsuario, sesionIniciada);
                });
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void IrSubasta(string nombreDeUsuario, bool haySesion)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (haySesion)
                {
                    MainWindow ventanaSubasta = new MainWindow(nombreDeUsuario);
                    ventanaSubasta.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre ya esta en uso.");
                    txtNombreUsuario.Clear();
                }
            }));
        }
    }
}
