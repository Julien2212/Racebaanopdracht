using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class NewDriversChangedEventArgs : EventArgs
    {
        public Track track { get; set; }
    }
}
