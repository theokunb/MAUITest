using MAUITest.Helpers;
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
            Filters = new ObservableCollection<Filter>();
            CommandAppearing = new Command(param => OnAppearing(param));
            CommandRefreshView = new Command(param => OnRefreshing(param));
        }


        private bool isRefreshingView;
        private Filter selectedFilter;


        public ObservableCollection<Filter> Filters { get; set; }
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
        public Filter SelectedFilter
        {
            get => selectedFilter;
            set
            {
                if (selectedFilter == value)
                    return;
                selectedFilter = value;
                IsRefreshingView = true;
                OnpropertyChnaged();
            }
        }



        private void OnAppearing(object param)
        {
            if (Filters.Count == 0)
                foreach (var element in FilterStore.Storage.GetFilters())
                    Filters.Add(element);
            if (Filters.Count != 0)
                SelectedFilter = Filters.First();

        }
        private async void OnRefreshing(object param)
        {
            if (Busy)
                return;
            Busy = true;

            Operations.Clear();
            var operationsHistory = await RealTimeDB.DataBase.GetOperationsAsync(SelectedFilter);
            foreach (var element in operationsHistory)
                Operations.Add(element);

            IsRefreshingView = false;
            Busy = false;
        }
    }
}
