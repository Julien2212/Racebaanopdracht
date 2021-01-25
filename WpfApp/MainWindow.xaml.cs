using Controller;
using Model;
using Racebaanopdracht;
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
using System.Windows.Threading;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler<Model.DriversChangedEventArgs> handler;
        public MainWindow()
        {
            InitializeComponent();
            Data.Initialize();
            Data.NextRace();
            //Visualisatie1.Initialize();
            Data.CurrentRace.DriversChanged += OnDriversChanged;
        }
        public void OnDriversChanged(object sender, EventArgs e)
        {
            //handler?.Invoke(this, new Model.DriversChangedEventArgs() { track = Data.CurrentRace.Track });
            this.Achtergrond.Dispatcher.BeginInvoke(
    DispatcherPriority.Render,
    new Action(() =>
    {
        this.Achtergrond.Source = null;
        this.Achtergrond.Source = Visualisatie.DrawTrack(Data.CurrentRace.Track);
    }));
        }
    }
}
