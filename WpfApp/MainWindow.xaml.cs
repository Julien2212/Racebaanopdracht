﻿using Controller;
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
        public void Initialize()
        {
            Data.CurrentRace.DriversChanged += OnDriversChanged;
            Data.CurrentRace.OnRaceFinishedHandler += OnRaceFinished;

        }
        public MainWindow()
        {

            Data.Initialize();
            Data.NextRace();
            InitializeComponent();
            DataContext = new DataContextMainWindow();
            Initialize();

        }
        public void OnDriversChanged(object sender, EventArgs e)
        {
            this.Achtergrond.Dispatcher.BeginInvoke(
            DispatcherPriority.Render,
            new Action(() =>
    {
        this.Achtergrond.Source = null;
        this.Achtergrond.Source = Visualisatie.DrawTrack(Data.CurrentRace.Track);
    }));
        }
        public void OnRaceFinished(object sender, DriversChangedEventArgs e)
        {
            Data.NextRace();
            Initialize();
            Data.CurrentRace.Start();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private StatsParticipantsCompetition statscompetition;
        private void MenuItem_CompStats_Click(object sender, RoutedEventArgs e)
        {
            statscompetition = new StatsParticipantsCompetition();
            statscompetition.Show();
        }
        private StatsCurrentRace statscurrentrace;
        private void MenuItem_RaceStats_Click(object sender, RoutedEventArgs e)
        {
            statscurrentrace = new StatsCurrentRace();
            statscurrentrace.Show();
        }
    }
}
