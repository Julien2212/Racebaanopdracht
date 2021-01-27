using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp
{
    public class DataContextMainWindow : INotifyPropertyChanged
    {
        public string HuidigeTrack
        {
            get
            {
                return Controller.Data.CurrentRace.Track.Name;
            }
            set
            {
                Controller.Data.CurrentRace.Track.Name = value;
            }
        }

        public DataContextMainWindow()
        {

            Controller.Data.CurrentRace.DriversChanged += OnDriversChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

    }
}

