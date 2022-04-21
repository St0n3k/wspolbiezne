using System.ComponentModel;

namespace Logic
{
    public interface IBall : INotifyPropertyChanged
    {
        int XPos { get; }
        int YPos { get; }
        int Radius { get; }
    }
}
