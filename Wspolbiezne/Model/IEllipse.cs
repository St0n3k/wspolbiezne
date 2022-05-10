using System.ComponentModel;

namespace Presentation.Model
{
    public interface IEllipse : INotifyPropertyChanged
    {
        double Width { get; set; }
        double Height { get; set; }
        double X { get; set; }
        double Y{ get; set; }
    }
}
