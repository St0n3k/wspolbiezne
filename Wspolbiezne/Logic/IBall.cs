using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logic
{
    public interface IBall : INotifyPropertyChanged
    {
        int XPos { get; }
        int YPos { get; }
        int Radius { get; }
    }
}
