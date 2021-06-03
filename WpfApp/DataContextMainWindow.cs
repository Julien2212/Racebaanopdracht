using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;

namespace WpfApp
{
    public class DataContextMainWindow : INotifyPropertyChanged
    {
        public string HuidigeTrack => Controller.Data.CurrentRace.Track.Name;

        public Timer timer = new Timer(2000);

        

        public DataContextMainWindow()
        {
            Controller.Data.CurrentRace.DriversChanged += OnPropertyChanged;
            timer.Elapsed += OnTimerVoorbij;
            timer.Start();
        }

        public void OnTimerVoorbij(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged("", new DriversChangedEventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(object sender, DriversChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        // currentrace dingen
        public string AantalParticipants => Controller.Data.CurrentRace.Participants.Count().ToString();
        public List<Kapot> Kapot => Controller.Data.CurrentRace.opslaanGegevensKapot.GetData()
         .Select(kapot => kapot as Kapot).ToList();
        public List<iHelikopterview> Speed => Controller.Data.CurrentRace.opslaanGegevensSpeed.GetData()
           .Select(speed => speed as iHelikopterview).ToList();

        public List<Tijd> Tijd => Controller.Data.CurrentRace.opslaanGegevensTijd.GetData()
         .Select(tijd => tijd as Tijd).ToList();

        // competition dingen
        public string TracksInRace => Controller.Data.competition.Tracks.Count().ToString();
        public List<Punten> Punten => Controller.Data.competition.gegevensPunten.GetData()
         .Select(punten => punten as Punten).ToList();
    }

}

