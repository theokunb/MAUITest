using MAUITest.Helpers;
using MAUITest.Models;
using MAUITest.Services;
using System.Windows.Input;

namespace MAUITest.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public AccountViewModel()
        {
            isLoaded = false;
            calculator = new Calculator();
            CommandAppearing = new Command(param => OnAppearing(param));
        }


        private float account;
        private Calculator calculator;

        public string DisplayAccount => $"${Account.ToString().CurrencyFormat()}";
        public float Account
        {
            get => account;
            set
            {
                if (account == value)
                    return;
                account = value;
                OnpropertyChnaged();
                OnpropertyChnaged(nameof(DisplayAccount));
            }
        }
        public ICommand CommandAppearing { get; }



        private async void OnAppearing(object param)
        {
            var dbAccount = await RealTimeDB.DataBase.GetAccountAsync();

            if (dbAccount == null)
            {
                float startCapital = 0;
                await RealTimeDB.DataBase.CreateNewAccountAsync(startCapital);
                Account = startCapital;
            }
            else
            {
                var history = await RealTimeDB.DataBase.GetOperationsAsync();
                Account = calculator.Sum((float)dbAccount, history);
            }
        }
        
    }
}
