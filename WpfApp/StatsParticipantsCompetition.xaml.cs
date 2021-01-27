using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for StatsParticipantsCompetition.xaml
    /// </summary>
    public partial class StatsParticipantsCompetition : Window
    {
        public StatsParticipantsCompetition()
        {
            InitializeComponent();
            StartTime.Content = $"{Controller.Data.CurrentRace.opslaanGegevensTijd}";
            Points.Content = $"Er doen {Controller.Data.CurrentRace.Participants.Count} Astronauten mee aan deze competitie";
        }
    }
}
