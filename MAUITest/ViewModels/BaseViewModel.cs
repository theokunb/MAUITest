using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUITest.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected bool isBusy;
        protected bool isLoaded;


        public bool Busy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                    return;
                isBusy = value;
                OnpropertyChnaged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnpropertyChnaged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
