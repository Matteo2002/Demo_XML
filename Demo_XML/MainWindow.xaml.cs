using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

namespace Demo_XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool flag = false;

        private void Btn_Aggiorna_Click(object sender, RoutedEventArgs e)
        {
            Lst_Persone.Items.Clear();
            flag = true;
            Task.Factory.StartNew(() => CaricaDati());
        }

        private void CaricaDati()
        {
            Persona persona = new Persona();
            string path = @"Documento.xml";
            XDocument xmlDoc = XDocument.Load(path);
            XElement xmlPersone = xmlDoc.Element("persone");
            var xmlPersona = xmlPersone.Elements("persona");

            foreach(var item in xmlPersona)
            {
                XElement xmlNome = item.Element("nome");
                XElement xmlCognome = item.Element("cognome");
                XElement xmlEta = item.Element("eta");
                XElement xmlDataNascita = item.Element("data");

                Persona p = new Persona();
                p.Nome = xmlNome.Value;
                p.Cognome = xmlCognome.Value;
                p.Eta = Convert.ToInt32(xmlEta.Value);
                p.DataNascita = Convert.ToDateTime(xmlDataNascita.Value);
                persona = p;

                Dispatcher.Invoke(() => Lst_Persone.Items.Add(persona));
                Thread.Sleep(300);
                if (!flag)
                {
                    break;
                }

            }
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
        }
    }
}
