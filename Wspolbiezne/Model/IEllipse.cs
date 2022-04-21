using System.ComponentModel;

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
