using MAUITest.Models;
using MAUITest.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUITest.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public HistoryViewModel()
        {
            Operations = new ObservableCollection<Operation>();
            CommandAppearing = new Command(param => OnAppearing(param));
            CommandRefreshView = new Command(param => OnRefreshing(param));
        }


        private bool isRefreshingView;


        public ObservableCollection<Operation> Operations { get; set; }
        public ICommand CommandAppearing { get; }
        public ICommand CommandRefreshView { get; }
        public bool IsRefreshingView
        {
            get => isRefreshingView;
            set
            {
                if (isRefreshingView == value)
                    return;
                isRefreshingView = value;
                OnpropertyChnaged();
            }
        }


        private void OnAppearing(object param)
        {
            IsRefreshingView = true;
        }
        private async void OnRefreshing(object param)
        {
            if (Busy)
                return;
            Busy = true;

            Operations.Clear();
            var operationsHistory = await RealTimeDB.DataBase.GetOperationsAsync();
            foreach (var element in operationsHistory)
                Operations.Add(element);

            IsRefreshingView = false;
            Busy = false;
        }
    }
}
