using MAUITest.ViewModels;

namespace MAUITest.Views;

public partial class AccountPage : ContentPage
{
	public AccountPage(AccountViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}