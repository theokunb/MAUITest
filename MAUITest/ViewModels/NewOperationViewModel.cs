using MAUITest.Helpers;
using MAUITest.Models;
using MAUITest.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUITest.ViewModels
{
    public class NewOperationViewModel : BaseViewModel
    {
        public NewOperationViewModel()
        {
            isLoaded = false;
            Busy = false;
            Categories = new ObservableCollection<Category>();
            Operations = new ObservableCollection<TypeOperation>();
            CommandAppearing = new Command(param => OnAppearing(param));
            CommandReset = new Command(param => ButtonResetTapped(param));
            CommandEdit = new Command(param => ButtonEditTapped(param));
        }


        private string amount;
        private TypeOperation selectedType;
        private Category selectedCategory;
        private string comment;


        public ICommand CommandReset { get; }
        public ICommand CommandEdit { get; }
        public ICommand CommandAppearing { get; }
        public ObservableCollection<TypeOperation> Operations { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public TypeOperation SelectedType
        {
            get => selectedType;
            set
            {
                if (selectedType == value)
                    return;
                selectedType = value;
                ReplaceCategories();
                OnpropertyChnaged();
            }
        }
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory == value)
                    return;
                selectedCategory = value;
                OnpropertyChnaged();
            }
        }
        public string Amount
        {
            get => amount;
            set
            {
                if (amount == value)
                    return;
                amount = value;
                OnpropertyChnaged();
            }
        }
        public string Comment
        {
            get => comment;
            set
            {
                if (comment == value)
                    return;
                comment = value;
                OnpropertyChnaged();
            }
        }


        private void OnAppearing(object param)
        {
            if (isLoaded)
                return;

            Busy = true;
            foreach (var element in TypeStore.Storage.GetTypeOperations())
                Operations.Add(element);
            SelectedType = Operations.First();

            isLoaded = true;
            Busy = false;
        }
        private void ReplaceCategories()
        {
            Categories.Clear();
            foreach (var element in CategoryStore.Storage.GetCategoties(SelectedType))
                Categories.Add(element);
            SelectedCategory = Categories.First();
        }

        private async void ButtonEditTapped(object param)
        {
            if (Busy)
                return;
            Busy = true;

            if (float.TryParse(Amount, out float sum))
            {
                if(sum <= 0)
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Введены не корректрые данные", "Оk");
                    Amount = string.Empty;
                    Busy = false;
                    return;
                }
                Operation operation = new()
                {
                    Amount = sum,
                    Category = SelectedCategory.Title,
                    TypeOperation = selectedType.Title,
                    Comment = Comment,
                    DateOperation = DateTime.Now
                };
                await RealTimeDB.DataBase.PostOperationAsync(operation);
            }
            else
            {
                await Shell.Current.DisplayAlert("Ошибка", "Введены не корректрые данные", "Оk");
                Amount = string.Empty;
            }
            Busy = false;
            CommandReset.Execute(null);
        }

        private void ButtonResetTapped(object param)
        {
            if (Busy)
                return;
            Busy = true;

            Amount = string.Empty;
            Comment = string.Empty;

            Busy = false;
        }
    }
}
