using MAUITest.ViewModels;

namespace MAUITest.Views;

public partial class NewOperationPage : ContentPage
{
	public NewOperationPage(NewOperationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}