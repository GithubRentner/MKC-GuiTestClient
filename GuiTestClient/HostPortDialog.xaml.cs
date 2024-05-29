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

namespace GuiTestClient
{
    /// <summary>
    /// Interaktionslogik für HostPortDialog.xaml
    /// </summary>
    public partial class HostPortDialog : Window
    {
        public HostPortDialog()
        {
            InitializeComponent();
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string Host = HostTextBox.Text;
            if (!int.TryParse(PortTextBox.Text, out int Port))
            {
                MessageBox.Show("Please enter a valid port number.");
                return;
            }

            TestClient.SetConnectionParameters(Host, Port);
            DialogResult = true;
        }
    }
}
