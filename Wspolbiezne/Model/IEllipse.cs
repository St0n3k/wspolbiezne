using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Presentation.Model
{
    public interface IEllipse : INotifyPropertyChanged
    {
        int Width { get; set; }
        int Height { get; set; }
        int X { get; set; }
        int Y{ get; set; }
    }
}
