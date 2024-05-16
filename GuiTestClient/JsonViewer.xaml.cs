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
    /// Interaktionslogik für JsonViewer.xaml
    /// </summary>
    public partial class JsonViewer : Window
    {
        public string JsonString { get; set; }

        public JsonViewer(string jsonString)
        {
            InitializeComponent();
            JsonString = jsonString;
            DataContext = this;
            JsonString = jsonString;
        }
    }
}
