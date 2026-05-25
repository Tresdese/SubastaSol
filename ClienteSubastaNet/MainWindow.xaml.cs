using ClienteSubastaNet.SubastaServicioRemoto;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteSubastaNet
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SubastaServicioClient conexion;
        private string nombre = "Cliente_1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            conexion.EntrarSala();
        }
    }
}
