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

namespace DatiCoronavirus_Muzi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CaricaDati()
        {
            string path = @"dati_covid19.xml";
            XDocument xmlDoc = XDocument.Load(path);
            XElement xmlVirus = xmlDoc.Element("coronavirus");
            var xmlGiornata = xmlVirus.Elements("giornata");
            foreach (var item in xmlGiornata)
            {
                XElement xmlData = item.Element("data");
                XElement xmlPositivi = item.Element("totale_positivi");
                XElement xmlNuoviPos = item.Element("nuovi_positivi");
                XElement xmlDimessi = item.Element("dimessi_guariti");
                XElement xmlDeceduti = item.Element("deceduti");
                XElement xmlTotCasi = item.Element("totale_casi");

                DatiGiornalieri dg = new DatiGiornalieri();
                dg.Data = Convert.ToDateTime(xmlData.Value);
                dg.TotPositivi = Convert.ToInt32(xmlPositivi.Value);
                dg.NuoviPositivi = Convert.ToInt32(xmlNuoviPos.Value);
                dg.DimessiGuariti = Convert.ToInt32(xmlDimessi.Value);
                dg.Deceduti = Convert.ToInt32(xmlDimessi.Value);
                dg.TotCasi = Convert.ToInt32(xmlTotCasi.Value);
                Dispatcher.Invoke(() => Lst_Lista.Items.Add(dg));
                Thread.Sleep(50);
            }
        }

        private void Btn_Visualizza_Click(object sender, RoutedEventArgs e)
        {
            Lst_Lista.Items.Clear();
            Task.Factory.StartNew(() => CaricaDati());
        }
    }
}
