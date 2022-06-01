using MAUITest.ViewModels;

namespace MAUITest.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}